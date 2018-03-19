using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;
using mitelapi;
using mitelapi.Events;
using mitelapi.Types;
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
                Username = "omm",
                Password = "omm"
            };
            var xml = _serializer.Serialize(open);
            Assert.AreEqual("<Open username=\"omm\" password=\"omm\" />", xml);
            open.UserDeviceSyncClient = true;
            xml = _serializer.Serialize(open);
            Assert.AreEqual("<Open username=\"omm\" password=\"omm\" UserDeviceSyncClient=\"true\" />", xml);
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
        public void CanSerializeSetPP()
        {
            var setPP = new SetPP()
            {
                PortablePart = new PPDevType() {
                    Ppn = 1,
                    RelType = PPRelTypeType.Unbound,
                    Uid = 0
                },
                User = new PPUserType() {
                    Uid = 1,
                    RelType = PPRelTypeType.Unbound,
                    Ppn = 0
                }
            };

            var xml = _serializer.Serialize(setPP);
            Assert.AreEqual("<SetPP><pp ppn=\"1\" relType=\"Unbound\" uid=\"0\" /><user uid=\"1\" relType=\"Unbound\" ppn=\"0\" /></SetPP>", xml);
        }

        [TestMethod]
        public void CanDeserializeSetPPResp()
        {
            var message = "<SetPPResp seq=\"2\"><pp ppn=\"32\" ppnSec=\"0\" relType=\"Unbound\" uid=\"0\" timeStamp=\"1520386972\""+
                " ipei=\"03074 0220259 3\" ac=\"\" s=\"Yes\" uak=\"C70FF5D60D1448184995414BA9577C5B\" encrypt=\"1\" capMessaging=\"0\" "+
                "capMessagingForInternalUse=\"0\" capEnhLocating=\"1\" capBluetooth=\"0\" ethAddr=\"\" hwType=\"Unknown\" ppProfileCapability=\"0\""+
                " ppDefaultProfileLoaded=\"0\" subscribeToPARIOnly=\"0\" ommId=\"102A7C82\" ommIdAck=\"102A7C82\" timeStampAdmin=\"1520386972\""+
                " timeStampRelation=\"1520386972\" timeStampRoaming=\"1510486477\" timeStampSubscription=\"1510486477\" autoCreate=\"1\""+
                " roaming=\"RoamingComplete\" modicType=\"01\" locationData=\"000001000000\" dectIeFixedId=\"06A0A0102A7C8200\" "+
                "subscriptionId=\"0500C0235C630000\" /><user uid=\"4\" uidSec=\"0\" permanent=\"0\" relType=\"Unbound\" ppn=\"0\" "+
                "timeStamp=\"1520386972\" name=\"1234\" num=\"1234\" hierarchy1=\"\" hierarchy2=\"\" addId=\"1234\" sipAuthId=\"1234\" "+
                "sipPw=\"kmmpH8QRJL5Jv6sbbub65gEPutga0wL9zuVibv6VRkeCwbnoAnCK1VckA3UBQLiZgtroPxYYstDudjqzeSEDiA==\" sosNum=\"\" manDownNum=\"\" "+
                "voiceboxNum=\"\" pin=\"hdwySugH1CFKm1KawJzMcfTgNDq/ycDIyp+wlEA7wM7oQPXhu589CyaJXuF8UjAnh2hM5Kyb27Tib1Rv2IZIKg==\" lang=\"English\" "+
                "forwardState=\"Off\" forwardDest=\"\" forwardTime=\"0\" holdRingBackTime=\"3\" callWaitingDisabled=\"0\" autoAnswer=\"Global\" "+
                "microphoneMute=\"Global\" warningTone=\"Global\" allowBargeIn=\"Global\" trackingActive=\"0\" autoLogoutOnCharge=\"0\" "+
                "locRight=\"0\" locatable=\"0\" msgRight=\"1\" sendVcardRight=\"1\" recvVcardRight=\"0\" keepLocalPB=\"0\" vip=\"0\" "+
                "sipRegisterCheck=\"1\" external=\"0\" BTlocatable=\"0\" BTsensitivity=\"high\" conferenceServerType=\"Global\" "+
                "conferenceServerURI=\"\" monitoringMode=\"Off\" HAS=\"Unknown\" HSS=\"Unknown\" HRS=\"Unknown\" HCS=\"Unknown\" SRS=\"Unknown\""+
                " SCS=\"Unknown\" CDS=\"Unknown\" HBS=\"Unknown\" BTS=\"Unknown\" SWS=\"Unknown\" CUS=\"Unknown\" allowVideoStream=\"0\" "+
                "credentialPw=\"mJJxssWIaZLc0+pN3Nkfcnkzi4YH4YPkSvUIaYJlBwB08YmkzF9qngcXwHBN1ocwsz3KjdmgP13JlJ7DHBKQSA==\" fixedSipPort=\"0\" "+
                "calculatedSipPort=\"5060\" hotDeskingSupport=\"0\" useSIPUserName=\"Global\" useSIPUserAuthentication=\"Global\" "+
                "serviceUserName=\"\" serviceAuthName=\"\" "+
                "serviceAuthPassword=\"V8SPo26k/NRNY5XfeMb5tqUfqmJ2ozp300P9AA6KR5IePKUTd76J6JN7XKoqq8/zGzFathgsmdEoYydeFyY1+A==\" "+
                "configurationDataLoaded=\"0\" ppProfileId=\"0\" ppnOld=\"32\" timeStampAdmin=\"1520386972\" timeStampRelation=\"1520386972\" /></SetPPResp>";
            var resp = _serializer.Deserialize<SetPPResp>(message);
            Assert.IsNotNull(resp);
            Assert.IsNotNull(resp.PortablePart);
            Assert.IsNotNull(resp.User);
            Assert.AreEqual(resp.PortablePart.RelType, PPRelTypeType.Unbound);
            Assert.AreEqual(resp.User.RelType, PPRelTypeType.Unbound);
            Assert.AreEqual(resp.User.Uid, 4);
            Assert.AreEqual(resp.User.Ppn, 0);
            Assert.AreEqual(resp.PortablePart.Ppn, 32);
            Assert.AreEqual(resp.PortablePart.Uid, 0);
        }

        [TestMethod]
        public void CanSerializeRFPType()
        {
            var rfp = new RFPType()
            {
                Id = 3,
                X = 10,
                Y = 44

            };
            var xml = _serializer.Serialize(rfp);
            Assert.AreEqual("<RFPType id=\"3\" x=\"10\" y=\"44\" />", xml);
        }

        [TestMethod]
        public void CanSerializeCreatePPUser()
        {
            var create = new CreatePPUser()
            {
                User = new PPUserType()
                {
                    Name = "UnitTestUser",
                    Num = "9900",
                    Hierarchy1 = "Beschreibung1",
                    Hierarchy2 = "Beschreibung2",
                    AddId = "9900",
                    Pin = "1234",
                    SipAuthId = "9900",
                    SipPw = "9900"
                }
            };

            var xml = _serializer.Serialize(create);
            Assert.AreEqual("<CreatePPUser><user uid=\"0\" ppn=\"0\" name=\"UnitTestUser\" num=\"9900\" hierarchy1=\"Beschreibung1\" " +
                "hierarchy2=\"Beschreibung2\" addId=\"9900\" pin=\"1234\" sipAuthId=\"9900\" sipPw=\"9900\" /></CreatePPUser>", xml);
        }

        [TestMethod]
        public void CanDeserializeCreatePPUserResp()
        {
            var message = "<CreatePPUserResp seq=\"2\"><user uid=\"6\" uidSec=\"0\" permanent=\"0\" relType=\"Unbound\" ppn=\"0\" timeStamp=\"1520550838\" "+
                "name=\"UnitTestUser\" num=\"9900\" hierarchy1=\"Beschreibung1\" hierarchy2=\"Beschreibung2\" addId=\"9900\" sipAuthId=\"9900\" "+
                "sipPw=\"if2arwBYiCVve6enyZyjhsYYKAIFvAhnEb4HuBP88muqMiI63jxtutU7r6Z+xz57BQuukvT9iZTSrCNF6Z3/IQ==\" sosNum=\"\" manDownNum=\"\" "+
                "voiceboxNum=\"\" pin=\"OB5aKJg//nQtlxjALg44SnW3MRPxQIC8XHWxGk1q6NBdgrpIAof63pMjYrI7PODoLu/BJR9DSHtN4a9IVDFudw==\" lang=\"English\" "+
                "forwardState=\"Off\" forwardDest=\"\" forwardTime=\"0\" holdRingBackTime=\"3\" callWaitingDisabled=\"0\" autoAnswer=\"Global\" "+
                "microphoneMute=\"Global\" warningTone=\"Global\" allowBargeIn=\"Global\" trackingActive=\"0\" autoLogoutOnCharge=\"0\" locRight=\"0\" "+
                "locatable=\"0\" msgRight=\"1\" sendVcardRight=\"1\" recvVcardRight=\"0\" keepLocalPB=\"0\" vip=\"0\" sipRegisterCheck=\"0\" external=\"0\" "+
                "BTlocatable=\"0\" BTsensitivity=\"high\" conferenceServerType=\"Global\" conferenceServerURI=\"\" monitoringMode=\"Off\" HAS=\"Unknown\" "+
                "HSS=\"Unknown\" HRS=\"Unknown\" HCS=\"Unknown\" SRS=\"Unknown\" SCS=\"Unknown\" CDS=\"Unknown\" HBS=\"Unknown\" BTS=\"Unknown\" "+
                "SWS=\"Unknown\" CUS=\"Unknown\" allowVideoStream=\"0\" "+
                "credentialPw=\"UWXjt3WYcxi7bK+RNA8J/oP7hia8Zer/7EcmkVvJ1KrtZ9h53uwy/GhHif+qSZrH8V+cgCGTMtlMM5vHSvHUjA==\" fixedSipPort=\"0\" "+
                "calculatedSipPort=\"0\" hotDeskingSupport=\"0\" useSIPUserName=\"Global\" useSIPUserAuthentication=\"Global\" serviceUserName=\"\" "+
                "serviceAuthName=\"\" serviceAuthPassword=\"ILLSNSY77GNuSMwTOhx+ef6Bw2iYu2ByhdNBmNE1rtCkN8YzM1AQXvCvefXtGKu6TnIsReF86wlgELyLyS2Myw==\" "+
                "configurationDataLoaded=\"0\" ppProfileId=\"0\" /></CreatePPUserResp>";
            var resp = _serializer.Deserialize<CreatePPUserResp>(message);
            Assert.IsNotNull(resp);
            Assert.IsNotNull(resp.User);
            Assert.AreEqual(resp.User.RelType, PPRelTypeType.Unbound);
            Assert.AreEqual(resp.User.Uid, 6);
            Assert.AreEqual(resp.User.Ppn, 0);
            Assert.AreEqual(resp.User.Num, "9900");
            Assert.AreEqual(resp.User.Hierarchy1, "Beschreibung1");
            Assert.AreEqual(resp.User.Hierarchy2, "Beschreibung2");
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
            Assert.AreEqual(DECTSubscriptionModeType.Configured, dectEvent.Mode);
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

        [TestMethod]
        public void CanDeserializeEventPPCnf()
        {
            var message = "<EventPPCnf deletedUser=\"1\"><user uid=\"25\" uidSec=\"0\" /></EventPPCnf>";
            var ppnCnfEvent = _serializer.DeserializeEvent<EventPPCnf>(message);
            Assert.IsNotNull(ppnCnfEvent);
            Assert.IsTrue(ppnCnfEvent.DeletedUser);
            Assert.AreEqual(25, ppnCnfEvent.User.Uid);
        }

        [TestMethod]
        public void CanSerializeGetPPUser()
        {
            var getPPUser = new GetPPUser
            {
                Uid = 3,
                MaxRecords = 20
            };
            var xml = _serializer.Serialize(getPPUser);
            Assert.AreEqual("<GetPPUser uid=\"3\" maxRecords=\"20\" />", xml);
        }

        [TestMethod]
        public void CanDeserializeGetPPUserResp()
        {
            var message = "<GetPPUserResp><user uid=\"1\" /><user uid=\"2\" /><user uid=\"3\" /></GetPPUserResp>";
            var getPPUserResp = _serializer.Deserialize<GetPPUserResp>(message);
            Assert.AreEqual(3, getPPUserResp.Users.Length);
        }

        [TestMethod]
        public void CanSerializePutFile()
        {
            var putFile = new PutFile
            {
                Name = ":license",
                Data = "bnNlRmlsZT4=",
                Offset = 1000,
            };
            var xml = _serializer.Serialize(putFile);
            Assert.AreEqual("<PutFile name=\":license\" offset=\"1000\" data=\"bnNlRmlsZT4=\" />", xml);
            putFile = new PutFile
            {
                Name = ":license",
                Eof = true,
                Offset = 1008,
            };
            xml = _serializer.Serialize(putFile);
            Assert.AreEqual("<PutFile name=\":license\" offset=\"1008\" data=\"\" eof=\"true\" />", xml);
        }
    }
}