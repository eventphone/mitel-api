using System;
using System;
using System.Net.Security;
using System.Threading;
using System.Threading.Tasks;
using mitelapi.Messages;
using mitelapi.Types;

namespace mitelapi
{
    public partial class OmmClient
    {
        /// <summary>
        /// This is the only request the OMM accepts on a freshly set up TCP link, which has the state new.
        /// If Open fails, the client may send additional Open messages with different ingredients
        /// (e. g. a different OM AXI protocol version or password) to try to set up a session.
        /// The link remains in the state new as long as Open was not successful.<para/>
        /// Open is not accepted by the OMM on an already opened session.
        /// </summary>
        /// <param name="username">User name for authentication</param>
        /// <param name="password">Password for authentication</param>
        /// <param name="userDeviceSync"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
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

        /// <summary>
        /// This request is sent from the client to the OMM to request the versions of requests/responses or events.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GetVersionsResp> GetVersionsAsync(CancellationToken cancellationToken)
        {
            var getversions = new GetVersions();
            return await SendAsync<GetVersions, GetVersionsResp>(getversions, cancellationToken);
        }

        /// <summary>
        /// This request is sent from the client to the OMM to request the limits of the OMM.
        /// </summary>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        public async Task<LimitsResp> LimitsAsync(CancellationToken cancellation)
        {
            return await SendAsync<Limits, LimitsResp>(new Limits(), cancellation);
        }
        
        /// <summary>
        /// This request can be sent to OM AXI to change events the client wants to be notified of.
        /// If the underlying TCP link gets closed by whatever reason, all notification subscriptions end automatically.
        /// The subscription mechanism remembers a flag for each possible event and for each possible element (e. g. DECT phone).
        /// The command “on” sets the corresponding flag in the OM AXI implementation for the given events. It can be reset by using “off”.
        /// </summary>
        public Task SubscribeAsync(EventType type, CancellationToken cancellationToken)
        {
            return SubscribeAsync(new SubscribeCmdType(type), cancellationToken);
        }
        
        /// <summary>
        /// This request can be sent to OM AXI to change events the client wants to be notified of.
        /// If the underlying TCP link gets closed by whatever reason, all notification subscriptions end automatically.
        /// The subscription mechanism remembers a flag for each possible event and for each possible element (e. g. DECT phone).
        /// The command “on” sets the corresponding flag in the OM AXI implementation for the given events. It can be reset by using “off”.
        /// </summary>
        public Task SubscribeAsync(SubscribeCmdType command, CancellationToken cancellationToken)
        {
            return SubscribeAsync(new[] {command}, cancellationToken);
        }

        /// <summary>
        /// This request can be sent to OM AXI to change events the client wants to be notified of.
        /// If the underlying TCP link gets closed by whatever reason, all notification subscriptions end automatically.
        /// The subscription mechanism remembers a flag for each possible event and for each possible element (e. g. DECT phone).
        /// The command “on” sets the corresponding flag in the OM AXI implementation for the given events. It can be reset by using “off”.
        /// </summary>
        /// <param name="commands">Up to 20 event commands to be executed at once atomically.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task SubscribeAsync(SubscribeCmdType[] commands, CancellationToken cancellationToken)
        {
            var subscribe = new Subscribe {Commands = commands};
            await SendAsync<Subscribe, SubscribeResp>(subscribe, cancellationToken);
        }

        /// <summary>
        /// With this request a client can keep the TCP link alive.
        /// If the request is sent before the 5 minutes timeout expires, the link is kept open.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task PingAsync(CancellationToken cancellationToken)
        {
            var ping = new Ping();
            var pong = await SendAsync<Ping, PingResp>(ping, cancellationToken);
            if (pong.TimeStamp.HasValue)
            {
                Rtt = TimeSpan.FromSeconds(ping.Timestamp - pong.TimeStamp.Value);
            }
        }

        /// <summary>
        /// With this requests the client can ask for information about the current OMM standby state.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GetStbStateResp> GetStbState(CancellationToken cancellationToken)
        {
            return await SendAsync<GetStbState, GetStbStateResp>(new GetStbState(), cancellationToken);
        }
    }
}
