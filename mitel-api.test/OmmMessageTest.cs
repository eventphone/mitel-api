using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;
using mitelapi;
using mitelapi.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace mitel_api.test
{
    [TestClass]
    public class OmmMessageTest
    {
        private OmmSerializer _serializer;

        [TestInitialize]
        public void Setup()
        {
            _serializer = new OmmSerializer();
        }

        [TestMethod]
        public void CanSerializeOpen()
        {
            var open = new Open
            {
                ProtocolVersion = 45,
                Username = "omm",
                Password = "omm",
                OmpClient = true
            };
            var xml = _serializer.Serialize(open);
            Assert.AreEqual("<Open protocolVersion=\"45\" username=\"omm\" password=\"omm\" OMPClient=\"1\" />", xml);
        }

        [TestMethod]
        public void CanDeserializeOpenResp()
        {
            var message = "<OpenResp ommStbState=\"None\" ommVersion=\"OpenMobility Manager SIP-DECT 7.1-CK14\" axiVersion=\"171101\" ommAxiSpecVersion=\"7.1.1\" protocolVersion=\"45\" errCode=\"EAuth\" />";
            var resp = _serializer.Deserialize<OpenResp>(message);
            Assert.IsNotNull(resp);
            Assert.AreEqual("OpenMobility Manager SIP-DECT 7.1-CK14", resp.OmmVersion);
            Assert.AreEqual("171101", resp.AxiVersion);
            Assert.AreEqual("7.1.1", resp.OmmAxiSpecVersion);
            Assert.AreEqual(45, resp.ProtocolVersion);
            Assert.AreEqual(OmmError.EAuth, resp.ErrorCode);
        }
    }
}