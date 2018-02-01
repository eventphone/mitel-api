using System.Threading.Tasks;
using mitelapi;
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
    }
}
