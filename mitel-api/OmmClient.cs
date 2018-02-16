using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using mitelapi.Events;
using mitelapi.Messages;

namespace mitelapi
{
    public class OmmClient:IDisposable
    {
        private readonly TcpClient _client;
        private int _port;
        private string _hostname;
        private SslStream _ssl;
        private bool _closed = false;
        private Thread _reader;
        private int _seq;
        private readonly OmmSerializer _serializer;
        private ConcurrentDictionary<int, ReceiveContainer> _receiveQueue = new ConcurrentDictionary<int, ReceiveContainer>();
        private Timer _pingTimer;

        public OmmClient(string hostname, int port = 12622)
        {
            _hostname = hostname;
            _port = port;
            _client = new TcpClient(AddressFamily.InterNetworkV6) {Client = {DualMode = true}};
            _serializer = new OmmSerializer();
            _pingTimer = new Timer(SendPing);
        }
        
        public DateTime LastMessage { get; private set; }

        public TimeSpan Rtt { get; private set; }

        public async Task LoginAsync(string username, string password, CancellationToken cancellationToken = default(CancellationToken))
        {
            await _client.ConnectAsync(_hostname, _port).ConfigureAwait(false);
            _ssl = new SslStream(_client.GetStream());
            await _ssl.AuthenticateAsClientAsync(_hostname);
            cancellationToken.ThrowIfCancellationRequested();
            _reader = new Thread(Read) {IsBackground = true, Name = "OmmClientReader"};
            MessageReceived += MessageRecievedHandler;
            _reader.Start();
            var open = new Open {Username = username, Password = password, OmpClient = true};
            await SendAsync<Open, OpenResp>(open, cancellationToken);
            _pingTimer.Change(TimeSpan.FromSeconds(60), TimeSpan.FromSeconds(60));
        }

        private async void SendPing(object state)
        {
            await Ping(CancellationToken.None);
        }

        public async Task Ping(CancellationToken cancellationToken)
        {
            var ping = new Ping();
            var pong = await SendAsync<Ping, PingResp>(ping, cancellationToken);
            if (pong.TimeStamp.HasValue)
            {
                Rtt = TimeSpan.FromSeconds(ping.Timestamp - pong.TimeStamp.Value);
            }
        }

        public Task Subscribe(EventType type, CancellationToken cancellationToken)
        {
            return Subscribe(new SubscribeCmd(type), cancellationToken);
        }

        public Task Subscribe(SubscribeCmd command, CancellationToken cancellationToken)
        {
            return Subscribe(new[] {command}, cancellationToken);
        }

        public async Task Subscribe(SubscribeCmd[] commands, CancellationToken cancellationToken)
        {
            var subscribe = new Subscribe {Commands = commands};
            await SendAsync<Subscribe, SubscribeResp>(subscribe, cancellationToken);
        }

        public async Task<GetRFPSummaryResp> GetRFPSummary(CancellationToken cancellationToken)
        {
            var request = new GetRFPSummary();
            var response = await SendAsync<GetRFPSummary, GetRFPSummaryResp>(request, cancellationToken);
            return response;
        }

        public async Task<GetPPDevSummaryResp> GetPPDevSummary(CancellationToken cancellationToken)
        {
            var request = new GetPPDevSummary();
            var response = await SendAsync<GetPPDevSummary, GetPPDevSummaryResp>(request, cancellationToken);
            return response;
        }

        public async Task<GetPPUserSummaryResp> GetPPUserSummary(CancellationToken cancellationToken)
        {
            var request = new GetPPUserSummary();
            var response = await SendAsync<GetPPUserSummary, GetPPUserSummaryResp>(request, cancellationToken);
            return response;
        }

        private async Task<TResponse> SendAsync<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken) where TRequest:BaseRequest where TResponse:BaseResponse
        {
            var sequence = Interlocked.Increment(ref _seq);
            request.Seq = sequence;
            using (var container = new ReceiveContainer(sequence))
            {
                _receiveQueue.AddOrUpdate(sequence, container, (i, o) => container);
                await _serializer.Serialize(request, _ssl);
                return (TResponse) await container.GetResponseAsync(cancellationToken);
            }
        }

        private void MessageRecievedHandler(object sender, MessageReceivedEventArgs e)
        {
            if (e.IsHandled) return;
            if (e.Message.Seq.HasValue)
            {
                if (_receiveQueue.TryRemove(e.Message.Seq.Value, out var container))
                {
                    e.IsHandled = true;
                    container.Response = e.Message;
                }
            }
        }

        private event EventHandler<MessageReceivedEventArgs> MessageReceived;

        public event EventHandler<OmmEventArgs<EventDECTSubscriptionMode>> DECTSubscriptionModeChanged;
        public event EventHandler<OmmEventArgs<EventAlarmCallProgress>> AlarmCallProgress;
        public event EventHandler<OmmEventArgs<EventRFPSummary>> RfpSummary;
        public event EventHandler<OmmEventArgs<EventPPDevSummary>> PPDevSummary;
        public event EventHandler<OmmEventArgs<EventPPUserSummary>> PPUserSummary;

        private void Read()
        {
            byte[] buffer = new byte[1024];
            int offset = 0;
            while (!_closed)
            {
                try
                {
                    var read = _ssl.Read(buffer, offset, buffer.Length - offset);
                    if (read != 0)
                    {
                        offset += read;
                    }
                    var nullIndex = buffer.AsSpan().Slice(0, offset).IndexOf(0);
                    if (nullIndex >= 0)
                    {
                        if (nullIndex > 0)
                        {
                            var message = Encoding.UTF8.GetString(buffer, 0, nullIndex);
                            var response = _serializer.DeserializeWrapper(message);
                            LastMessage = DateTime.Now;
                            OnMessageReceived(response.Response);
                            OnEventReceived(response.Event);
                        }
                        Buffer.BlockCopy(buffer, nullIndex + 1, buffer, 0, offset - (nullIndex +1));
                        offset -= (nullIndex + 1);
                    }
                    if (read != 0)
                    {
                        if (offset >= buffer.Length)
                        {
                            Array.Resize(ref buffer, buffer.Length + 1024);
                        }
                    }
                }
                catch (IOException ex)
                {
                    var socketExept = ex.InnerException as SocketException;
                    if (socketExept == null || socketExept.ErrorCode != 10004)
                        throw;
                }
            }
        }

        private void OnMessageReceived(BaseResponse message)
        {
            if (message == null) return;
            MessageReceived?.Invoke(this, new MessageReceivedEventArgs(message));
        }

        private void OnEventReceived(BaseEvent ommEvent)
        {
            if (ommEvent == null) return;
            if (ommEvent is EventDECTSubscriptionMode dectSubscriptionMode)
            {
                DECTSubscriptionModeChanged?.Invoke(this, new OmmEventArgs<EventDECTSubscriptionMode>(dectSubscriptionMode));
            }
            else if (ommEvent is EventAlarmCallProgress alarmCallProgress)
            {
                AlarmCallProgress?.Invoke(this, new OmmEventArgs<EventAlarmCallProgress>(alarmCallProgress));
            }
            else if (ommEvent is EventRFPSummary rfpSummary)
            {
                RfpSummary?.Invoke(this, new OmmEventArgs<EventRFPSummary>(rfpSummary));
            }
            else if (ommEvent is EventPPDevSummary ppDevSummary)
            {
                PPDevSummary?.Invoke(this, new OmmEventArgs<EventPPDevSummary>(ppDevSummary));
            }
            else if (ommEvent is EventPPUserSummary ppUserSummary)
            {
                PPUserSummary?.Invoke(this, new OmmEventArgs<EventPPUserSummary>(ppUserSummary));
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _closed = true;
                if (_ssl != null)
                {
                    _ssl.Dispose();
                    _reader.Join();
                }
                else
                {
                    _client?.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
