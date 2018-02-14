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
        public void OmmResponseWrapperDeclaresAllRespTypes()
        {
            var respTypes = typeof(BaseResponse).Assembly.GetTypes()
                .Where(x => !x.IsInterface)
                .Where(x => !x.IsAbstract)
                .Where(x => typeof(BaseResponse).IsAssignableFrom(x))
                .ToList();
            var attributes = typeof(OmmResponseWrapper).GetProperty(nameof(OmmResponseWrapper.Element))
                .GetCustomAttributes(typeof(XmlElementAttribute), false)
                .OfType<XmlElementAttribute>()
                .Select(x => x.Type);
            foreach (var attribute in attributes)
            {
                respTypes.Remove(attribute);
            }
            Assert.IsTrue(respTypes.Count == 0, "XmlElement for (" + String.Join(", ", respTypes.Select(x=>x.Name)) + $") missing on {nameof(OmmResponseWrapper.Element)}");
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

        [TestMethod]
        public void CanSerializeGetRFPSummary()
        {
            var rfpSummary = new GetRFPSummary();
            var xml = _serializer.Serialize(rfpSummary);
            Assert.AreEqual("<GetRFPSummary />", xml);
        }

        [TestMethod]
        public void CanDeserializeGetRFPSummaryResp()
        {
            var message = "<GetRFPSummaryResp nRFPs=\"5\" idFirst=\"1\" nConnected=\"2\" wrongBrandedRFPs=\"0\" wrongStandbyRFPs=\"0\" wrongVersionedRFPs=\"0\" " +
                "newAvailSWRFPs=\"0\" DecryptedDECTRFPs=\"0\" usbOverloads=\"0\" DECTactivatedRFPs=\"11\" " +
                "DECTactiveRFPs=\"1\" advancedFeaturesErrorRFPs=\"0\" usedDECTclusters=\"1\" usedPagingAreas=\"1\" WLANactivatedRFPs=\"1\" WLANrunningRFPs=\"1\" usedWLANprofiles=\"1\" />";
            var resp = _serializer.Deserialize<GetRFPSummaryResp>(message);
            Assert.IsNotNull(resp);
            Assert.AreEqual(5, resp.TotalCount);
            Assert.AreEqual(2, resp.ConnectedCount);
            Assert.AreEqual(1, resp.DectActiveCount);
            Assert.AreEqual(11, resp.DectActivedCount);
        }
    }
}