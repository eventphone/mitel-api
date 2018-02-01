using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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

        public OmmClient(string hostname, int port = 12622)
        {
            _hostname = hostname;
            _port = port;
            _client = new TcpClient(AddressFamily.InterNetworkV6) {Client = {DualMode = true}};
            _serializer = new OmmSerializer();
        }

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
            var resp = await SendAsync<Open, OpenResp>(open, cancellationToken);
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
                            var response = _serializer.Deserialize(message);
                            OnMessageRecieved(response);
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

        private void OnMessageRecieved(BaseResponse message)
        {
            MessageReceived?.Invoke(this, new MessageReceivedEventArgs(message));
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
