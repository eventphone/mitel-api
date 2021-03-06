using System;
using System.Threading;
using System.Threading.Tasks;
using mitelapi;
using mitelapi.Events;
using mitelapi.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mitelapi.Types;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Runtime.InteropServices;

namespace mitel_api.test
{
    public class TestClient : OmmClient
    {
        public TestClient(string hostname, int port = 12622) : base(hostname, port)
        {
        }

        protected override bool CertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
    [TestClass]
    public class OmmClientTest
    {
        private OmmClient _client;

        [TestInitialize]
        public void Setup()
        {
            _client = new TestClient("localhost");
            _client.MessageLog += (s, e) => Console.WriteLine(e.Message);
        }

        [TestCleanup]
        public void TearDown()
        {
            _client.Dispose();
        }

        [TestMethod]
        public async Task CanLogin()
        {
            await _client.LoginAsync("omm", "omm");
        }

        [TestMethod]
        public async Task CanLoginAsMOM()
        {
            await _client.LoginAsync("omm", "omm", true);
        }

        [TestMethod]
        public async Task CanCancelMessage()
        {
            try
            {
                await _client.LoginAsync("omm", "omm");
                await _client.GetVersionsAsync(new CancellationToken(true));
            }
            catch(OperationCanceledException){}
            await Task.Delay(TimeSpan.FromSeconds(1));
            Assert.AreEqual(0, _client.ReceiveQueueSize);
        }

        [TestMethod]
        public async Task CanGetVersions()
        {
            await CanLogin();
            await _client.GetVersionsAsync(CancellationToken.None);
        }

        [TestMethod]
        public async Task CanDetachUser()
        {
            await CanLoginAsMOM();
            var pp = new PPDevType(){
                Uid = 0x0,
                RelType = PPRelTypeType.Unbound,
                Ppn = 0x25
            };
            var user = new PPUserType(){
                Ppn = 0x0,
                Uid = 0x15,
                RelType = PPRelTypeType.Unbound
            };
            await _client.SetPPAsync(pp,user,CancellationToken.None);
        }

        [TestMethod]
        public async Task CanCreateUser()
        {
            await CanLogin();
            var user = new PPUserType()
            {
                Name = "UnitTestUser1",
                Num = "9901",
                Hierarchy1 = "Beschreibung1",
                Hierarchy2 = "Beschreibung2",
                AddId = "9901",
                Pin = "1234",
                SipAuthId = "9901",
                SipPw = "9901"
            };
            await _client.CreatePPUserAsync(user, CancellationToken.None);
        }

        [TestMethod]
        public async Task CanGetUser()
        {
            await CanLoginAsMOM();
            await _client.GetPPAsync(3, 0, CancellationToken.None);
        }

        [TestMethod]
        public async Task EmptyPasswordThrowsException()
        {
            try
            {
                await _client.LoginAsync("omm", String.Empty);
                Assert.Fail("expected exception not thrown");
            }
            catch (OmmException ex)
            {
                Assert.AreEqual(OmmError.EAuth, ex.ErrorCode);
            }
        }

        [TestMethod]
        public async Task InvalidPasswordThrowsException()
        {
            try
            {
                await _client.LoginAsync("omm", "invalid password");
                Assert.Fail("expected exception not thrown");
            }
            catch (OmmException ex)
            {
                Assert.AreEqual(OmmError.EAuth, ex.ErrorCode);
            }
        }

        [TestMethod]
        public async Task CanPing()
        {
            await CanLogin();
            await _client.PingAsync(CancellationToken.None);
            Console.WriteLine(_client.Rtt);
        }

        [TestMethod]
        public async Task CanSubscribe()
        {
            await CanLogin();
            await _client.SubscribeAsync(EventType.DECTSubscriptionMode, CancellationToken.None);
            var resetEvent = new ManualResetEventSlim();
            _client.DECTSubscriptionModeChanged += (s, e) =>
            {
                var data = e.Event;
                Console.WriteLine($"{data.Mode}");
                resetEvent.Set();
            };
            resetEvent.Wait(TimeSpan.FromSeconds(5));
            Assert.IsTrue(resetEvent.IsSet);
        }

        [TestMethod]
        public async Task CanSubscribeAlarmCallProgress()
        {
            await CanLogin();
            await _client.SubscribeAsync(new SubscribeCmdType(EventType.AlarmCallProgress){Ppn = -1, Trigger = "*"}, CancellationToken.None);
            var resetEvent = new ManualResetEventSlim();
            _client.AlarmCallProgress += (s, e) =>
            {
                var data = e.Event;
                Console.WriteLine($"{data.Id}: {data.Ppn} - {data.Destination} ({data.State}) ({data.Trigger})");
                resetEvent.Set();
            };
            resetEvent.Wait();
            Assert.IsTrue(resetEvent.IsSet);
        }

        [TestMethod]
        public async Task CanSubscribePPDevCnf()
        {
            await CanLogin();
            await _client.SubscribeAsync(new SubscribeCmdType(EventType.PPDevCnf) { Ppn = -1 }, CancellationToken.None);
            var resetEvent = new ManualResetEventSlim();
            _client.PPDevCnf += (s, e) =>
            {
                var data = e.Event;
                Console.WriteLine($"Encrypt: {data.PP.Encrypt}");
                Console.WriteLine($"IPEI: {data.PP.Ipei}");
                resetEvent.Set();
            };
            resetEvent.Wait(TimeSpan.FromSeconds(5));
            Assert.IsTrue(resetEvent.IsSet);
        }

        [TestMethod]
        public async Task CanRequestReEnrollment()
        {
            await CanLogin();
            await _client.RequestRFPEnrollmentAsync(23, CancellationToken.None);
        }

        [TestMethod]
        public async Task CanGetRFP()
        {
            await CanLogin();
            var rfp = await _client.GetRFPAsync(23, true, true, CancellationToken.None);
        }
    }
}
