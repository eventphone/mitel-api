using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;
using mitelapi;
using mitelapi.Events;
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
            var attributes = typeof(OmmResponseWrapper).GetProperty(nameof(OmmResponseWrapper.Response))
                .GetCustomAttributes(typeof(XmlElementAttribute), false)
                .OfType<XmlElementAttribute>()
                .Select(x => x.Type);
            foreach (var attribute in attributes)
            {
                respTypes.Remove(attribute);
            }
            Assert.IsTrue(respTypes.Count == 0, "XmlElement for (" + String.Join(", ", respTypes.Select(x=>x.Name)) + $") missing on {nameof(OmmResponseWrapper.Response)}");
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
            Assert.AreEqual(11, resp.DectActivatedCount);
        }

        [TestMethod]
        public void CanSerializeGetPPDevSummary()
        {
            var rfpSummary = new GetPPDevSummary();
            var xml = _serializer.Serialize(rfpSummary);
            Assert.AreEqual("<GetPPDevSummary />", xml);
        }

        [TestMethod]
        public void CanDeserializeGetPPDevSummaryResp()
        {
            var message = "<GetPPDevSummaryResp nRecords=\"3\" ppnFirst=\"116\" subscribedDevs=\"2\" />";
            var resp = _serializer.Deserialize<GetPPDevSummaryResp>(message);
            Assert.IsNotNull(resp);
            Assert.AreEqual(3, resp.TotalCount);
            Assert.AreEqual(2, resp.SubscribedCount);
        }

        [TestMethod]
        public void CanSerializeSubscribe()
        {
            var subscribe = new Subscribe
            {
                Commands = new[] {new SubscribeCmd{Cmd = CmdType.On, Event = EventType.SystemState}}
            };
            var xml = _serializer.Serialize(subscribe);
            Assert.AreEqual("<Subscribe><e cmd=\"On\" eventType=\"SystemState\" /></Subscribe>", xml);
        }

        [TestMethod]
        public void CanDeserializeSubscribeResp()
        {
            var message = "<SubscribeResp />";
            var resp = _serializer.Deserialize<SubscribeResp>(message);
            Assert.IsNotNull(resp);
            Assert.AreEqual(EventType.None, resp.Event);
        }

        [TestMethod]
        public void CanDeserializeEventDECTSubscriptionMode()
        {
            var message = "<EventDECTSubscriptionMode mode=\"Configured\" />";
            var dectEvent = _serializer.DeserializeEvent<EventDECTSubscriptionMode>(message);
            Assert.IsNotNull(dectEvent);
            Assert.AreEqual(DECTSubscriptionMode.Configured, dectEvent.Mode);
        }

        [TestMethod]
        public void CanDeserializeEventAlarmCallProgress()
        {
            var message = "<EventAlarmCallProgress ppn=\"5\" trigger=\"asdf\" id=\"99\" destAddr=\"tel:5555\" state=\"ringing\" />";
            var dectEvent = _serializer.DeserializeEvent<EventAlarmCallProgress>(message);
            Assert.IsNotNull(dectEvent);
            Assert.AreEqual(5, dectEvent.Ppn);
            Assert.AreEqual("asdf", dectEvent.Trigger);
            Assert.AreEqual(99u, dectEvent.Id);
            Assert.AreEqual("tel:5555", dectEvent.Destination);
            Assert.AreEqual("ringing", dectEvent.State);
        }

        [TestMethod]
        public void CanDeserializeEventRFPSummary()
        {
            var message = "<EventRFPSummary nRFPs=\"5\" idFirst=\"1\" nConnected=\"2\" wrongBrandedRFPs=\"0\" wrongStandbyRFPs=\"0\" " +
                          "wrongVersionedRFPs=\"0\" newAvailSWRFPs=\"0\" DecryptedDECTRFPs=\"0\" usbOverloads=\"0\" DECTactivatedRFPs=\"1\" " +
                          "DECTactiveRFPs=\"0\" advancedFeaturesErrorRFPs=\"0\" usedDECTclusters=\"1\" usedPagingAreas=\"1\" " +
                          "WLANactivatedRFPs=\"1\" WLANrunningRFPs=\"1\" usedWLANprofiles=\"1\" />";
            var dectEvent = _serializer.DeserializeEvent<EventRFPSummary>(message);
            Assert.IsNotNull(dectEvent);
            Assert.AreEqual(2, dectEvent.ConnectedCount);
            Assert.AreEqual(1, dectEvent.DectActivatedCount);
            Assert.AreEqual(0, dectEvent.DectActiveCount);
            Assert.AreEqual(5, dectEvent.TotalCount);
        }
    }
}