using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using mitelapi.Messages;
using mitelapi.Types;

namespace mitelapi
{
    public partial class OmmClient:IDisposable
    {
        private readonly TcpClient _client;
        private readonly int _port;
        private readonly string _hostname;
        private SslStream _ssl;
        private bool _closed = false;
        private Task _reader;
        private int _seq;
        private readonly OmmSerializer _serializer;
        private readonly ConcurrentDictionary<int, ReceiveContainer> _receiveQueue = new ConcurrentDictionary<int, ReceiveContainer>();
        private readonly Timer _pingTimer;
        private string _modulus;
        private string _exponent;

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

        public int ReceiveQueueSize => _receiveQueue.Count;

        protected virtual bool CertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return sslPolicyErrors == SslPolicyErrors.None;
        }

        private async void SendPing(object state)
        {
            await PingAsync(CancellationToken.None).ConfigureAwait(false);
        }

        public async Task<GetPPDevSummaryResp> GetPPDevSummaryAsync(CancellationToken cancellationToken)
        {
            var request = new GetPPDevSummary();
            var response = await SendAsync<GetPPDevSummary, GetPPDevSummaryResp>(request, cancellationToken).ConfigureAwait(false);
            return response;
        }

        public async Task<GetPPUserSummaryResp> GetPPUserSummaryAsync(CancellationToken cancellationToken)
        {
            var request = new GetPPUserSummary();
            var response = await SendAsync<GetPPUserSummary, GetPPUserSummaryResp>(request, cancellationToken).ConfigureAwait(false);
            return response;
        }

        public async Task<PPUserType> CreatePPUserAsync(PPUserType user, CancellationToken cancellationToken)
        {
            var request = new CreatePPUser()
            {
                User = user
            };
            if (request.User.Pin != null)
                request.User.Pin = PPUserType.EncryptData(_modulus, _exponent, request.User.Pin);
            if (request.User.SipPw != null)
                request.User.SipPw = PPUserType.EncryptData(_modulus, _exponent, request.User.SipPw);
            var response = await SendAsync<CreatePPUser, CreatePPUserResp>(request, cancellationToken).ConfigureAwait(false);
            return response.User;
        }

        public async Task<SetPPResp> SetPPAsync(PPDevType pp, PPUserType user, CancellationToken cancellationToken)
        {
            var request = new SetPP() {
                PortablePart = pp,
                User = user 
            };
            var response = await SendAsync<SetPP, SetPPResp>(request, cancellationToken).ConfigureAwait(false);
            return response;
        }

        public async Task<GetPPResp> GetPPAsync(int ppn, int uid, CancellationToken cancellationToken)
        {
            var request = new GetPP()
            {
                uid = uid,
                ppn = ppn
            };
            var response = await SendAsync<GetPP, GetPPResp>(request, cancellationToken).ConfigureAwait(false);
            return response;
        }

        public async Task<PPUserType> GetPPUserAsync(int uid, CancellationToken cancellationToken)
        {
            var response = await SendAsync<GetPPUser, GetPPUserResp>(new GetPPUser { Uid = uid }, cancellationToken).ConfigureAwait(false);
            return response.Users[0];
        }

        public async Task<PPUserType> GetPPUserByNumberAsync(string num, CancellationToken cancellationToken)
        {
            var response = await SendAsync<GetPPUserByNumber, GetPPUserByNumberResp>(new GetPPUserByNumber {Num = num}, cancellationToken).ConfigureAwait(false);
            return response.User;
        }

        public async Task<List<PPUserType>> GetPPAllUserAsync(CancellationToken cancellationToken)
        {
            var uid = 0;
            var result = new List<PPUserType>();
            while (true)
            {
                try
                {
                    var users = await SendAsync<GetPPUser, GetPPUserResp>(new GetPPUser { Uid = uid, MaxRecords = 20 }, cancellationToken).ConfigureAwait(false);
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

        public async Task DeletePPUserAsync(int uid, CancellationToken cancellationToken)
        {
            await SendAsync<DeletePPUser, DeletePPUserResp>(new DeletePPUser { Uid = uid }, cancellationToken).ConfigureAwait(false);
        }

        public async Task<PPDevType[]> GetPPDevAsync(int ppn, int maxRecords, CancellationToken cancellationToken)
        {
            var response = await SendAsync<GetPPDev, GetPPDevResp>(new GetPPDev { Ppn = ppn, MaxRecords = maxRecords }, cancellationToken).ConfigureAwait(false);
            return response.Devices;
        }

        public async Task<PPDevType> GetPPDevAsync(int ppn, CancellationToken cancellationToken)
        {
            var response = await SendAsync<GetPPDev, GetPPDevResp>(new GetPPDev { Ppn = ppn }, cancellationToken).ConfigureAwait(false);
            return response.Devices[0];
        }

        public async Task<PPDevType> GetPPDevByIPEIAsync(string ipei, CancellationToken cancellationToken)
        {
            var response = await SendAsync<GetPPDevByIPEI, GetPPDevByIPEIResp>(new GetPPDevByIPEI { Ipei = ipei }, cancellationToken).ConfigureAwait(false);
            return response.Device;
        }

        public async Task<PPDevType> CreatePPDevAsync(PPDevType pp, CancellationToken cancellationToken)
        {
            var request = new CreatePPDev {
                PortablePart = pp,
            };
            var response = await SendAsync<CreatePPDev, CreatePPDevResp>(request, cancellationToken).ConfigureAwait(false);
            return response.PortablePart;
        }

        public async Task<PPDevType> SetPPDevAsync(PPDevType pp, CancellationToken cancellationToken)
        {
            var request = new SetPPDev {
                PortablePart = pp,
            };
            var response = await SendAsync<SetPPDev, SetPPDevResp>(request, cancellationToken).ConfigureAwait(false);
            return response.PortablePart;
        }

        public async Task DeletePPDevAsync(int ppn, CancellationToken cancellationToken)
        {
            await SendAsync<DeletePPDev, DeletePPDevResp>(new DeletePPDev {Ppn = ppn}, cancellationToken).ConfigureAwait(false);
        }

        public async Task<List<PPDevType>> GetPPAllDevAsync(CancellationToken cancellationToken)
        {
            var ppn = 0;
            var result = new List<PPDevType>();
            while (true)
            {
                try
                {
                    var devices = await SendAsync<GetPPDev, GetPPDevResp>(new GetPPDev { Ppn = ppn, MaxRecords = 20 }, cancellationToken).ConfigureAwait(false);
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

        public async Task<bool> GetDevAutoCreateAsync(CancellationToken cancellationToken)
        {
            var resp = await SendAsync<GetDevAutoCreate, GetDevAutoCreateResp>(new GetDevAutoCreate(), cancellationToken).ConfigureAwait(false);
            return resp.Enable;
        }

        public async Task<SetDevAutoCreateResp> SetDevAutoCreateAsync(bool enabled, CancellationToken cancellationToken)
        {
            return await SendAsync<SetDevAutoCreate, SetDevAutoCreateResp>(new SetDevAutoCreate() { Enable = enabled}, cancellationToken).ConfigureAwait(false);
        }

        public async Task<DECTSubscriptionModeType> GetDECTSubscriptionModeAsync(CancellationToken cancellationToken)
        {
            var resp = await SendAsync<GetDECTSubscriptionMode, GetDECTSubscriptionModeResp>(new GetDECTSubscriptionMode(), cancellationToken).ConfigureAwait(false);
            return resp.Mode;
        }

        public Task<SetDECTSubscriptionModeResp> SetDECTSubscriptionModeAsync(DECTSubscriptionModeType mode, CancellationToken cancellationToken)
        {
            return SetDECTSubscriptionModeAsync(mode, 3, cancellationToken);
        }

        public async Task<SetDECTSubscriptionModeResp> SetDECTSubscriptionModeAsync(DECTSubscriptionModeType mode, int timeout, CancellationToken cancellationToken)
        {
            return await SendAsync<SetDECTSubscriptionMode, SetDECTSubscriptionModeResp>(new SetDECTSubscriptionMode() { Mode = mode, Timeout = timeout}, cancellationToken).ConfigureAwait(false);
        }

        public async Task UploadFileAsync(string filename, Stream file, CancellationToken cancellationToken)
        {
            var buffer = new byte[500];
            int read;
            int offset = 0;
            while ((read = await file.ReadAsync(buffer, 0, buffer.Length, cancellationToken).ConfigureAwait(false)) != -1)
            {
                var request = new PutFile
                {
                    Name = filename,
                    Offset =  offset,
                    Data = Convert.ToBase64String(buffer, 0, read),
                };
                await SendAsync<PutFile, PutFileResp>(request, cancellationToken).ConfigureAwait(false);
                offset += read;
            }
            var eof = new PutFile
            {
                Name = filename,
                Offset = offset,
                Eof = true
            };
            await SendAsync<PutFile, PutFileResp>(eof, cancellationToken).ConfigureAwait(false);
        }

        public async Task<GetLicenseResp> GetLicenseAsync(CancellationToken cancellationToken)
        {
            var response = await SendAsync<GetLicense, GetLicenseResp>(new GetLicense(), cancellationToken).ConfigureAwait(false);
            return response;
        }

        public async Task<GetPPStateResp> GetPPStateAsync(int ppn, CancellationToken cancellationToken)
        {
            var request = new GetPPState{Ppn = ppn};
            var response = await SendAsync<GetPPState, GetPPStateResp>(request, cancellationToken).ConfigureAwait(false);
            return response;
        }

        public async Task<PPUserType> SetPPUserAsync(PPUserType user, CancellationToken cancellationToken)
        {
            var request = new SetPPUser {User = user};
            if (request.User.Pin != null)
                request.User.Pin = PPUserType.EncryptData(_modulus, _exponent, request.User.Pin);
            if (request.User.SipPw != null)
                request.User.SipPw = PPUserType.EncryptData(_modulus, _exponent, request.User.SipPw);
            var response = await SendAsync<SetPPUser, SetPPUserResp>(request, cancellationToken).ConfigureAwait(false);
            return response.User;
        }

        private async Task<TResponse> SendAsync<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken) where TRequest:BaseRequest where TResponse:BaseResponse
        {
            var sequence = Interlocked.Increment(ref _seq);
            request.Seq = sequence;
            using (var container = new ReceiveContainer(sequence))
            {
                _receiveQueue.AddOrUpdate(sequence, container, (i, o) => container);
                var message = await _serializer.SerializeAsync(request, _ssl, cancellationToken).ConfigureAwait(false);
                OnMessageLog(message, MessageDirection.Out);
                return (TResponse) await container.GetResponseAsync(message, cancellationToken).ConfigureAwait(false);
            }
        }
        
        private void MessageReceivedHandler(object sender, MessageReceivedEventArgs e)
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

        private async Task ReadAsync(CancellationToken cancellationToken)
        {
            byte[] buffer = new byte[1024];
            int offset = 0;
            while (!_closed)
            {
                try
                {
                    var read = await _ssl.ReadAsync(buffer, offset, buffer.Length - offset, cancellationToken);
                    if (read != 0)
                    {
                        offset += read;
                    }
                    var nullIndex = buffer.AsSpan().Slice(0, offset).IndexOf((byte)0);
                    while (nullIndex >= 0)
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
                        nullIndex = buffer.AsSpan().Slice(0, offset).IndexOf((byte)0);
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
                    var socketException = ex.InnerException as SocketException;
                    if (socketException == null || socketException.ErrorCode != 10004)
                        throw;
                }
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
