using System;
using System.Threading;
using System.Threading.Tasks;
using mitelapi;
using mitelapi.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace mitel_api.test
{
    [TestClass]
    public class OmmClientTest
    {
        private OmmClient _client;

        [TestInitialize]
        public void Setup()
        {
            _client = new OmmClient("localhost");
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
            await _client.Ping();
            Console.WriteLine(_client.Rtt);
        }
    }
}
