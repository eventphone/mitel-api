using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using mitelapi.Events;
using mitelapi.Messages;
using mitelapi.Types;

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
        private string _modulus;
        private string _exponent;
        private ConcurrentDictionary<string, int> _uidMapping = new ConcurrentDictionary<string, int>();

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

        public int ReceiveQueueSize
        {
            get { return _receiveQueue.Count; }
        }

        public async Task LoginAsync(string username, string password, bool userDeviceSync = false,  CancellationToken cancellationToken = default(CancellationToken))
        {
            await _client.ConnectAsync(_hostname, _port).ConfigureAwait(false);
            _ssl = new SslStream(_client.GetStream());
            await _ssl.AuthenticateAsClientAsync(_hostname);
            cancellationToken.ThrowIfCancellationRequested();
            _reader = new Thread(Read) {IsBackground = true, Name = "OmmClientReader"};
            MessageReceived += MessageRecievedHandler;
            _reader.Start();
            var open = new Open {Username = username, Password = password, UserDeviceSyncClient = userDeviceSync};
            var response = await SendAsync<Open, OpenResp>(open, cancellationToken);
            _pingTimer.Change(TimeSpan.FromSeconds(60), TimeSpan.FromSeconds(60));
            _exponent = response.PublicKey.Exponent;
            _modulus = response.PublicKey.Modulus;
            await LoadUsersAsync(cancellationToken);
        }

        private async Task LoadUsersAsync(CancellationToken cancellationToken)
        {
            var uid = 0;
            while (true)
            {
                try
                {
                    var users = await SendAsync<GetPPUser, GetPPUserResp>(new GetPPUser { Uid = uid, MaxRecords = 20 }, cancellationToken);
                    uid = users.Users.Max(x => x.Uid) + 1;
                    foreach(var user in users.Users)
                    {
                        _uidMapping.TryAdd(user.Num, user.Uid);
                    }
                }
                catch (OmmNoEntryException)
                {
                    break;
                }
            }
            this.PPUserCnf += UpdateUserCache;
            this.PPCnf += UpdateUserCache;
            await Subscribe(new SubscribeCmd(EventType.PPUserCnf) { Uid = -1 }, cancellationToken);
        }

        private void UpdateUserCache(object sender, OmmEventArgs<EventPPCnf> e)
        {
            if (e.Event.User != null)
                UpdateUserCache(e.Event.DeletedUser, e.Event.User.Uid, e.Event.User.Num);
        }

        private void UpdateUserCache(object sender, OmmEventArgs<EventPPUserCnf> e)
        {
            UpdateUserCache(e.Event.Deleted, e.Event.User.Uid, e.Event.User.Num);
        }

        private void UpdateUserCache(bool deleted, int uid, string num)
        {
            if (deleted)
            {
                var oldNum = _uidMapping.Where(x => x.Value == uid).Select(x => x.Key).FirstOrDefault();
                _uidMapping.TryRemove(oldNum, out int unused);
            }
            else
            {
                if (String.IsNullOrEmpty(num)) return;
                var oldNum = _uidMapping.Where(x => x.Value == uid).Select(x => x.Key).FirstOrDefault();
                if (oldNum != null)
                    _uidMapping.TryRemove(oldNum, out int unused);
                _uidMapping.TryAdd(num, uid);
            }
        }

        public bool TryLookupExtension(string extension, out int uid)
        {
            return _uidMapping.TryGetValue(extension, out uid);
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

        public async Task GetVersions(CancellationToken cancellationToken)
        {
            var getversions = new GetVersions();
            await SendAsync<GetVersions, GetVersionsResp>(getversions, cancellationToken);
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

        public async Task<CreatePPUserResp> CreatePPUser(PPUserType user, CancellationToken cancellationToken)
        {
            var request = new CreatePPUser()
            {
                User = user
            };
            if (request.User.Pin != null)
                request.User.Pin = PPUserType.EncryptData(_modulus, _exponent, request.User.Pin);
            if (request.User.SipPw != null)
                request.User.SipPw = PPUserType.EncryptData(_modulus, _exponent, request.User.SipPw);
            var response = await SendAsync<CreatePPUser, CreatePPUserResp>(request, cancellationToken);
            return response;
        }

        public async Task<SetPPResp> SetPP(PPDevType pp, PPUserType user, CancellationToken cancellationToken)
        {
            var request = new SetPP() {
                PortablePart = pp,
                User = user 
            };
            var response = await SendAsync<SetPP, SetPPResp>(request, cancellationToken);
            return response;
        }

        public async Task<GetPPResp> GetPP(int ppn, int uid, CancellationToken cancellationToken)
        {
            var request = new GetPP()
            {
                uid = uid,
                ppn = ppn
            };
            var response = await SendAsync<GetPP, GetPPResp>(request, cancellationToken);
            return response;
        }

        public async Task<PPUserType> GetPPUser(int uid, CancellationToken cancellationToken)
        {
            var response = await SendAsync<GetPPUser, GetPPUserResp>(new GetPPUser { Uid = uid }, cancellationToken);
            return response.Users[0];
        }

        public async Task<List<PPUserType>> GetPPAllUser(CancellationToken cancellationToken)
        {
            var uid = 0;
            var result = new List<PPUserType>();
            while (true)
            {
                try
                {
                    var users = await SendAsync<GetPPUser, GetPPUserResp>(new GetPPUser { Uid = uid, MaxRecords = 20 }, cancellationToken);
                    uid = users.Users.Max(x => x.Uid) + 1;
                    foreach (var user in users.Users)
                    {
                        result.Add(user);
                    }
                }
                catch (OmmNoEntryException)
                {
                    break;
                }
            }
            return result;
        }

        public async Task DeletePPUser(int uid, CancellationToken cancellationToken)
        {
            await SendAsync<DeletePPUser, DeletePPUserResp>(new DeletePPUser { Uid = uid }, cancellationToken);
        }

        public async Task<PPDevType> GetPPDev(int ppn, CancellationToken cancellationToken)
        {
            var response = await SendAsync<GetPPDev, GetPPDevResp>(new GetPPDev { Ppn = ppn }, cancellationToken);
            return response.Devices[0];
        }

        public async Task<PPDevType> SetPPDev(PPDevType pp, CancellationToken cancellationToken)
        {
            var request = new SetPPDev {
                PortablePart = pp,
            };
            var response = await SendAsync<SetPPDev, SetPPDevResp>(request, cancellationToken);
            return response.PortablePart;
        }

        public async Task DeletePPDev(int ppn, CancellationToken cancellationToken)
        {
            await SendAsync<DeletePPDev, DeletePPDevResp>(new DeletePPDev {Ppn = ppn}, cancellationToken);
        }

        public async Task<List<PPDevType>> GetPPAllDev(CancellationToken cancellationToken)
        {
            var ppn = 0;
            var result = new List<PPDevType>();
            while (true)
            {
                try
                {
                    var devices = await SendAsync<GetPPDev, GetPPDevResp>(new GetPPDev { Ppn = ppn, MaxRecords = 20 }, cancellationToken);
                    ppn = devices.Devices.Max(x => x.Ppn) + 1;
                    foreach (var device in devices.Devices)
                    {
                        result.Add(device);
                    }
                }
                catch (OmmNoEntryException)
                {
                    break;
                }
            }
            return result;
        }

        public async Task<bool> GetDevAutoCreate(CancellationToken cancellationToken)
        {
            var resp = await SendAsync<GetDevAutoCreate, GetDevAutoCreateResp>(new GetDevAutoCreate(), cancellationToken);
            return resp.Enable;
        }

        public async Task<SetDevAutoCreateResp> SetDevAutoCreate(bool enabled, CancellationToken cancellationToken)
        {
            return await SendAsync<SetDevAutoCreate, SetDevAutoCreateResp>(new SetDevAutoCreate() { Enable = enabled}, cancellationToken);
        }

        public async Task<bool> GetRFPCapture(CancellationToken cancellationToken)
        {
            var resp = await SendAsync<GetRFPCapture, GetRFPCaptureResp>(new GetRFPCapture(), cancellationToken);
            return resp.Enable;
        }

        public async Task<DeleteRFPCaptureListElemResp> DeleteRFPCaptureListElem(string mac, CancellationToken cancellationToken)
        {
            return await SendAsync<DeleteRFPCaptureListElem, DeleteRFPCaptureListElemResp>(new DeleteRFPCaptureListElem() {EthAddr = mac }, cancellationToken);
        }

        public async Task<DeleteRFPCaptureListResp> DeleteRFPCaptureList(CancellationToken cancellationToken)
        {
            return await SendAsync<DeleteRFPCaptureList, DeleteRFPCaptureListResp>(new DeleteRFPCaptureList(), cancellationToken);
        }

        public async Task<SetRFPCaptureResp> SetRFPCapture(bool enabled, CancellationToken cancellationToken)
        {
            return await SendAsync<SetRFPCapture, SetRFPCaptureResp>(new SetRFPCapture() { Enable = enabled }, cancellationToken);
        }

        public async Task<GetRFPCaptureListResp> GetRFPCaptureList(CancellationToken cancellationToken)
        {
            return await SendAsync<GetRFPCaptureList, GetRFPCaptureListResp>(new GetRFPCaptureList(), cancellationToken);
        }

        public async Task<DECTSubscriptionModeType> GetDECTSubscriptionMode(CancellationToken cancellationToken)
        {
            var resp = await SendAsync<GetDECTSubscriptionMode, GetDECTSubscriptionModeResp>(new GetDECTSubscriptionMode(), cancellationToken);
            return resp.Mode;
        }

        public async Task<SetDECTSubscriptionModeResp> SetDECTSubscriptionMode(DECTSubscriptionModeType mode, CancellationToken cancellationToken, int timeout = 3)
        {
            return await SendAsync<SetDECTSubscriptionMode, SetDECTSubscriptionModeResp>(new SetDECTSubscriptionMode() { Mode = mode, Timeout = timeout}, cancellationToken);
        }

        public async Task<GetRFPSyncResp> GetRFPSync(int id, CancellationToken cancellationToken)
        {
            return await SendAsync<GetRFPSync, GetRFPSyncResp>(new GetRFPSync { Id = id }, cancellationToken);
        }

        public async Task<GetRFPSyncQualityResp> GetRFPSyncQuality(int id, int maxRecords, CancellationToken cancellationToken)
        {
            return await SendAsync<GetRFPSyncQuality, GetRFPSyncQualityResp>(new GetRFPSyncQuality { Id = id, MaxRecords = maxRecords }, cancellationToken);
        }

        public async Task<RFPType> GetRFP(int id, bool withDetails, bool withState, CancellationToken cancellationToken)
        {
            var response = await SendAsync<GetRFP, GetRFPResp>(new GetRFP { Id = id, WithDetails=withDetails, WithState=withState, MaxRecords=1 }, cancellationToken);
            return response.RFPs[0];
        }

        public async Task SetRFP(RFPType rfp, CancellationToken cancellationToken)
        {
            await SendAsync<SetRFP, SetRFPResp>(new SetRFP { Rfp = rfp}, cancellationToken);
        }

        public async Task DeleteRFP(int id, CancellationToken cancellationToken)
        {
            await SendAsync<DeleteRFP, DeleteRFPResp>(new DeleteRFP { Id = id }, cancellationToken);
        }

        public async Task CreateRFP(RFPType rfp, CancellationToken cancellationToken)
        {
            await SendAsync<CreateRFP, CreateRFPResp>(new CreateRFP { Rfp = rfp }, cancellationToken);
        }

        public async Task<List<RFPType>> GetRFPAll(bool withDetails, bool withState, CancellationToken cancellationToken)
        {
            var id = 0;
            var result = new List<RFPType>();
            while (true)
            {
                try
                {
                    var rfps = await SendAsync<GetRFP, GetRFPResp>(new GetRFP { Id = id, MaxRecords = 20, WithDetails=withDetails, WithState=withState }, cancellationToken);
                    id = rfps.RFPs.Max(x => x.Id.GetValueOrDefault()) + 1;
                    foreach (var rfp in rfps.RFPs)
                    {
                        result.Add(rfp);
                    }
                }
                catch (OmmNoEntryException)
                {
                    break;
                }
            }
            return result;
        }

        public async Task UploadFile(string filename, Stream file, CancellationToken cancellationToken)
        {
            var buffer = new byte[500];
            int read;
            int offset = 0;
            while ((read = await file.ReadAsync(buffer, 0, buffer.Length, cancellationToken)) != -1)
            {
                var request = new PutFile
                {
                    Name = filename,
                    Offset =  offset,
                    Data = Convert.ToBase64String(buffer, 0, read),
                };
                await SendAsync<PutFile, PutFileResp>(request, cancellationToken);
                offset += read;
            }
            var eof = new PutFile
            {
                Name = filename,
                Offset = offset,
                Eof = true
            };
            await SendAsync<PutFile, PutFileResp>(eof, cancellationToken);
        }

        public async Task<GetRFPStatisticConfigResp> GetRFPStatisticConfig(CancellationToken cancellationToken)
        {
            var response = await SendAsync<GetRFPStatisticConfig, GetRFPStatisticConfigResp>(new GetRFPStatisticConfig(), cancellationToken);
            return response;
        }

        /// <summary>
        /// With this request the client can query the statistic counter of an RFP.
        /// </summary>
        /// <param name="id">Unique RFP identifier. The numbering starts at 0</param>
        /// <param name="maxRecord">Maximal number of records to return. Not more than 20 allowed.
        /// If maxRecord is equal 0, only the record of the RFP addressed by id should be fetched</param>
        /// <param name="recordSet">Record set to read
        /// Record 0 identifies the overall counter, 1 the current week, 2 the week before the current week and so on.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<GetRFPStatisticResp> GetRFPStatistic(int id, int maxRecord, int recordSet, CancellationToken cancellationToken)
        {
            var request = new GetRFPStatistic {Id = id, MaxRecords = maxRecord, RecordSet = recordSet};
            return GetRFPStatistic(request, cancellationToken);
        }

        public async Task<GetRFPStatisticResp> GetRFPStatistic(GetRFPStatistic request, CancellationToken cancellationToken)
        {
            var response = await SendAsync<GetRFPStatistic, GetRFPStatisticResp>(request, cancellationToken);
            return response;
        }

        private async Task<TResponse> SendAsync<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken) where TRequest:BaseRequest where TResponse:BaseResponse
        {
            var sequence = Interlocked.Increment(ref _seq);
            request.Seq = sequence;
            using (var container = new ReceiveContainer(sequence))
            {
                _receiveQueue.AddOrUpdate(sequence, container, (i, o) => container);
                var message = await _serializer.Serialize(request, _ssl);
                OnMessageLog(message, MessageDirection.Out);
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
        public event EventHandler<OmmEventArgs<EventPPDevCnf>> PPDevCnf;
        public event EventHandler<OmmEventArgs<EventPPUserCnf>> PPUserCnf;
        public event EventHandler<OmmEventArgs<EventPPCnf>> PPCnf;
        public event EventHandler<OmmEventArgs<EventAlarmCallProgress>> AlarmCallProgress;
        public event EventHandler<OmmEventArgs<EventRFPSummary>> RfpSummary;
        public event EventHandler<OmmEventArgs<EventPPDevSummary>> PPDevSummary;
        public event EventHandler<OmmEventArgs<EventPPUserSummary>> PPUserSummary;
        public event EventHandler<OmmEventArgs<EventRFPState>> RFPState;
        public event EventHandler<OmmEventArgs<EventRFPSyncRel>> RFPSyncRel;
        public event EventHandler<OmmEventArgs<EventRFPSyncQuality>> RFPSyncQuality;

        public event EventHandler<LogMessageEventArgs> MessageLog;

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
                    var nullIndex = buffer.AsSpan().Slice(0, offset).IndexOf((byte)0);
                    if (nullIndex >= 0)
                    {
                        if (nullIndex > 0)
                        {
                            var message = Encoding.UTF8.GetString(buffer, 0, nullIndex);
                            OnMessageLog(message, MessageDirection.In);
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

        private void OnMessageLog(string message, MessageDirection direction)
        {
            if (String.IsNullOrEmpty(message)) return;
            MessageLog?.Invoke(this, new LogMessageEventArgs(message, direction));
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
            else if (ommEvent is EventPPDevCnf ppDevCnf)
            {
                PPDevCnf?.Invoke(this, new OmmEventArgs<EventPPDevCnf>(ppDevCnf));
            }
            else if (ommEvent is EventPPUserCnf ppUserCnf)
            {
                PPUserCnf?.Invoke(this, new OmmEventArgs<EventPPUserCnf>(ppUserCnf));
            }
            else if (ommEvent is EventPPCnf ppCnf)
            {
                PPCnf?.Invoke(this, new OmmEventArgs<EventPPCnf>(ppCnf));
            }
            else if (ommEvent is EventRFPState rfpState)
            {
                RFPState?.Invoke(this, new OmmEventArgs<EventRFPState>(rfpState));
            }
            else if (ommEvent is EventRFPSyncRel rfpSyncRel)
            {
                RFPSyncRel?.Invoke(this, new OmmEventArgs<EventRFPSyncRel>(rfpSyncRel));
            }
            else if (ommEvent is EventRFPSyncQuality rfpSyncQuality)
            {
                RFPSyncQuality?.Invoke(this, new OmmEventArgs<EventRFPSyncQuality>(rfpSyncQuality));
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
