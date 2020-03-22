using System;
using System.Linq;
using System.Reflection;
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
            var failed = true;
            foreach (var type in respTypes)
            {
                var xml = $"<{type.Name}/>";
                _serializer.Deserialize<BaseResponse>(xml);
                failed = false;
            }
            Assert.IsFalse(failed);
        }

        [TestMethod]
        public void OmmResponseWrapperDeclaresAllEventTypes()
        {
            var respTypes = typeof(BaseEvent).Assembly.GetTypes()
                .Where(x => !x.IsInterface)
                .Where(x => !x.IsAbstract)
                .Where(x => typeof(BaseEvent).IsAssignableFrom(x))
                .ToList();
            var failed = true;
            foreach (var type in respTypes)
            {
                var xml = $"<{type.Name}/>";
                _serializer.DeserializeEvent<BaseEvent>(xml);
                failed = false;
            }
            Assert.IsFalse(failed);
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
            setPP = new SetPP
            {
                PortablePart = new PPDevType
                {
                    Ppn = 1,
                    Encrypt = true,
                }
            };
            xml = _serializer.Serialize(setPP);
            Assert.AreEqual("<SetPP><pp ppn=\"1\" encrypt=\"true\" /></SetPP>", xml);
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
            Assert.AreEqual("<CreatePPUser><user uid=\"0\" ppn=\"0\" name=\"UnitTestUser\" num=\"9900\" " +
                "hierarchy1=\"Beschreibung1\" hierarchy2=\"Beschreibung2\" addId=\"9900\" pin=\"1234\" sipAuthId=\"9900\" sipPw=\"9900\" /></CreatePPUser>", xml);
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
                Commands = new[] {new SubscribeCmdType{Cmd = CmdType.On, Event = EventType.SystemState}}
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
        public void CanDeserializeEventMessageSend()
        {
            var message = "<EventMessageSend alwaysIndirect=\"true\"><msg sendTime=\"1574881564\" id=\"67134080\" ppn=\"6201\" fromAddr=\"tel:4502\" toAddr=\"Tel:8378\" fromName=\"PoC zivillian\" priority=\"Normal\" folder=\"Inbox\" content=\"Void\"/></EventMessageSend>";
            var send = _serializer.DeserializeEvent<EventMessageSend>(message);
            Assert.IsNotNull(send);
            var msg = send.Msg;
            Assert.IsNotNull(msg);
            Assert.AreEqual(1574881564u, msg.SendTime);
            Assert.AreEqual("Void", msg.Content);
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

        [TestMethod]
        public void CanSerializeGetRFPStatisticConfig()
        {
            var getRFPStatisticConfig = new GetRFPStatisticConfig();
            var xml = _serializer.Serialize(getRFPStatisticConfig);
            Assert.AreEqual("<GetRFPStatisticConfig />", xml);
        }

        [TestMethod]
        public void CanDeserializeGetRFPStatisticConfigResp()
        {
            var message = "<GetRFPStatisticConfigResp>" +
                          "<rfpStatHead numElemPerRec=\"28\" recordSets=\"3\" resolution=\"week\" />" +
                          "<rfpStatName elemId=\"0\" group=\"Voice channels\" name=\"Only 2 voice channels free\" />" +
                          "<rfpStatName elemId=\"1\" group=\"Voice channels\" name=\"Only 1 voice channels free\" />" +
                          "</GetRFPStatisticConfigResp>";
            var getRFPStatisticConfigResp = _serializer.Deserialize<GetRFPStatisticConfigResp>(message);
            Assert.AreEqual(2, getRFPStatisticConfigResp.Name.Length);
            Assert.AreEqual(1, getRFPStatisticConfigResp.Name[1].Id);
            Assert.AreEqual("Voice channels", getRFPStatisticConfigResp.Name[1].Group);
            Assert.AreEqual("Only 2 voice channels free", getRFPStatisticConfigResp.Name[0].Name);
        }

        [TestMethod]
        public void CanSerializeGetRFPStatistic()
        {
            var getRFPStatistic = new GetRFPStatistic
            {
                Id = 0,
                MaxRecords = 20,
                RecordSet = 0
            };
            var xml = _serializer.Serialize(getRFPStatistic);
            Assert.AreEqual("<GetRFPStatistic id=\"0\" maxRecords=\"20\" recordSet=\"0\" />", xml);
        }

        [TestMethod]
        public void CanDeserializeRfpStatisticResp()
        {
            var message = "<GetRFPStatisticResp seq=\"0\">" +
                          "<rfpStatData id=\"0\" counter=\"0,0,0,0,0,0,0,0,0,0,182,0,0,2154,43,16,0,82,0,0,0,24,44,0,262,11946,3159605,4\" />" +
                          "<rfpStatData id=\"1\" counter=\"0,0,0,0,0,0,0,0,0,0,0,1,1,49040,14087,91,0,38866,31578,1142,6,2504,271,0,51756,2109872,2147421342,0\" />" +
                          "<rfpStatData id=\"2\" counter=\"0,0,0,0,0,0,0,0,0,0,0,7,4,8238,15344,58,2,14274,36409,1462,8,1850,364,0,25922,832670,2147424124,0\" />" +
                          "<rfpStatData id=\"3\" counter=\"0,0,0,0,0,0,0,0,0,0,0,3,0,1249,0,0,0,82,0,0,0,0,0,0,267,206,836134,0\" />" +
                          "<rfpStatData id=\"4\" counter=\"0,0,0,0,0,0,0,0,0,0,0,5,5,3060,15,7,3,537,0,0,0,75,17,0,1966,129916,14067096,9\" />" +
                          "<rfpStatData id=\"5\" counter=\"0,0,0,0,0,0,0,0,0,0,0,0,1,57076,84,8,2,47987,127,0,0,632,1369,0,2500,1574117,331537509,5\" />" +
                          "<rfpStatData id=\"6\" counter=\"0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0\" />" +
                          "<rfpStatData id=\"7\" counter=\"0,0,0,0,0,0,0,0,0,0,0,0,1,211,3,0,0,12,0,0,0,0,1,0,65535,0,835984,0\" />" +
                          "<rfpStatData id=\"8\" counter=\"0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0\" />" +
                          "<rfpStatData id=\"9\" counter=\"0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0\" />" +
                          "<rfpStatData id=\"10\" counter=\"0,0,0,0,0,0,0,0,0,0,0,0,1,5546,111,9,1,378,5,0,0,37,24,217,1134,26507,19052111,1\" />" +
                          "<rfpStatData id=\"11\" counter=\"0,0,0,0,0,0,0,0,0,0,0,1,4,187,0,0,0,2,0,0,0,0,21,0,65535,0,91550,0\" />" +
                          "<rfpStatData id=\"12\" counter=\"0,0,0,0,0,0,0,0,0,1,12,1,5,10,0,0,0,1,0,0,0,0,467,0,65535,0,26187,0\" />" +
                          "<rfpStatData id=\"13\" counter=\"0,0,0,0,0,0,0,0,0,0,1,2,4,92,0,0,0,3,0,0,0,0,123,0,65535,0,38237,0\" />" +
                          "<rfpStatData id=\"14\" counter=\"0,0,0,0,0,0,0,0,0,0,0,0,0,46065,207,12,0,8322,1336,1,0,114,378,0,3326,288054,575190482,1\" />" +
                          "<rfpStatData id=\"19\" counter=\"0,0,0,0,0,0,0,0,0,0,86,0,0,101,0,0,0,3,0,0,0,2,1,0,65535,965,37134,25\" />" +
                          "<rfpStatData id=\"23\" counter=\"0,0,0,0,0,0,0,0,0,0,0,0,1,12148,2,0,0,6669,0,0,0,65,95,0,880,68307,14824770,5\" />" +
                          "<rfpStatData id=\"24\" counter=\"0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0\" />" +
                          "</GetRFPStatisticResp>";
            var getRFPStatisticResp = _serializer.Deserialize<GetRFPStatisticResp>(message);
            Assert.AreEqual(18, getRFPStatisticResp.Data.Length);
            Assert.IsTrue(getRFPStatisticResp.Data.All(x=>x.Values.Length == 28));
            Assert.AreEqual(182L, getRFPStatisticResp.Data[0].Values[10]);
        }

        [TestMethod]
        public void CanSerializeDeletePPDev()
        {
            var deletePPDev = new DeletePPDev
            {
                Ppn = 7
            };
            var xml = _serializer.Serialize(deletePPDev);
            Assert.AreEqual("<DeletePPDev ppn=\"7\" />", xml);
        }

        [TestMethod]
        public void CanSerializeDeletePPUser()
        {
            var deletePPUser = new DeletePPUser
            {
                Uid = 42
            };
            var xml = _serializer.Serialize(deletePPUser);
            Assert.AreEqual("<DeletePPUser uid=\"42\" />", xml);
        }

        [TestMethod]
        public void CanDeserializeGetVersionsResp()
        {
            var message = "<GetVersionsResp " +
                          "ActivateRemoteSystemDump=\"1.0.1\" AddUserToConference=\"2.0.2\" CancelMessage=\"1.0.2\" ChangeUserInConference=\"2.0.1\" " +
                          "ConferenceConfirmation=\"1.0.1\" CreateAccount=\"1.0.5\" CreateACLEntry=\"1.0.3\" CreateAlarmTrigger=\"1.0.9\" " +
                          "CreateBluetoothBeacon=\"2.0.1\" CreateConference=\"1.0.1\" CreateConferenceRoom=\"1.0.2\" CreateDigitTreatment=\"1.0.1\" " +
                          "CreateFixedPP=\"1.1.8\" CreateLDAP=\"1.0.3\" CreatePPDev=\"2.0.0\" CreatePPUser=\"1.1.11\" CreateRFP=\"2.0.2\" " +
                          "CreateSite=\"1.0.2\" CreateVideoDev=\"2.1.1\" CreateWLANProfile=\"2.0.4\" CreateXMLApplication=\"3.0.3\" DeleteAccount=\"1.0.1\" " +
                          "DeleteACLEntry=\"1.0.3\" DeleteAlarmTrigger=\"1.0.3\" DeleteBluetoothBeacon=\"1.0.1\" DeleteConference=\"1.0.1\" " +
                          "DeleteConferenceRoom=\"1.0.1\" DeleteDigitTreatment=\"1.0.1\" DeleteEventLogBuffer=\"1.0.1\" DeleteLDAP=\"1.0.1\" " +
                          "DeleteMessage=\"1.0.2\" DeletePPDev=\"1.0.1\" DeletePPUser=\"1.0.2\" DeleteRFPCaptureListElem=\"1.0.3\" " +
                          "DeleteRFPCaptureList=\"1.0.3\" DeleteRFP=\"1.0.2\" DeleteSite=\"1.0.1\" DeleteUserFromConference=\"1.0.1\" DeleteVideoDev=\"1.0.1\" " +
                          "DeleteWLANProfile=\"1.0.1\" DeleteXMLApplication=\"1.0.1\" EventAccountCnf=\"1.0.5\" EventAccountSummary=\"1.0.1\" " +
                          "EventACLCnf=\"1.0.3\" EventAdditionalSettingsCnf=\"1.0.2\" EventAddUserToConference=\"2.0.2\" EventAdvancedSIPCnf=\"3.0.3\" " +
                          "EventAlarmCallProgress=\"1.0.1\" EventAlarmTriggerCnf=\"1.0.1\" EventAlarmTrigger=\"1.0.7\" EventAutoDBBackupCnf=\"2.0.2\" " +
                          "EventAutoDBBackupFileNameCnf=\"1.0.1\" EventBackupSIPCnf=\"1.0.1\" EventBasicSIPCnf=\"3.0.1\" EventBluetoothBeaconCnf=\"2.0.1\" " +
                          "EventBluetoothBeaconSummary=\"1.0.1\" EventBluetoothClientStatistic=\"1.0.1\" EventBluetoothGlobalSettingsCnf=\"1.0.1\" " +
                          "EventBluetoothSensitivityCnf=\"1.0.1\" EventChangeUserInConference=\"2.0.1\" EventConferenceRelease=\"1.0.1\" " +
                          "EventConferenceRequest=\"1.0.1\" EventConferenceRoomCnf=\"1.0.2\" EventConferenceServerSIPCnf=\"1.0.2\" EventConfigURLCnf=\"1.0.2\" " +
                          "EventCoreDumpURLCnf=\"1.0.2\" EventCreateConference=\"1.0.1\" EventDbTransferState=\"1.0.3\" EventDECTAuthCodeCnf=\"1.0.1\" " +
                          "EventDECTEncryptionCnf=\"1.0.1\" EventDECTPagingAreaSizeCnf=\"1.0.1\" EventDECTPpSettingsCnf=\"2.0.1\" " +
                          "EventDECTRegDomainCnf=\"1.0.2\" EventDECTSubscriptionMode=\"1.0.1\" EventDeleteConference=\"1.0.1\" " +
                          "EventDeleteUserFromConference=\"1.0.1\" EventDevAutoCreateCnf=\"1.0.1\" EventDigitTreatmentCnf=\"1.0.1\" EventDTMFCnf=\"1.0.1\" " +
                          "EventEULAConfirmCnf=\"1.0.1\" EventEventLogBufferDelete=\"1.0.0\" EventEventLogEntry=\"1.0.2\" EventFACCnf=\"1.0.3\" " +
                          "EventFACPrefixCnf=\"1.0.1\" EventFreeConferenceChannels=\"1.0.1\" EventHealthState=\"1.1.9\" EventIMACnf=\"2.0.2\" " +
                          "EventIntercomCallHandlingSIPCnf=\"1.0.1\" EventLDAPCnf=\"1.0.2\" EventLicenseCnf=\"2.0.2\" EventLicensedCodecLines=\"1.0.1\" " +
                          "EventLicenseFile=\"1.0.1\" EventLicenseServerListCnf=\"1.0.1\" EventMessageConfirmation=\"1.0.1\" EventMessageProgress=\"1.0.2\" " +
                          "EventMessageQueueEmpty=\"1.0.1\" EventMessageSend=\"1.0.7\" EventNetParamsCnf=\"1.0.1\" EventOMMCertificateCnf=\"1.0.2\" " +
                          "EventPARKCnf=\"1.0.1\" EventPARKFromServerResult=\"1.0.1\" EventPermissionChange=\"1.0.4\" EventPortRangeSIPCnf=\"1.0.1\" " +
                          "EventPositionHistory=\"1.0.1\" EventPositionInfo=\"1.0.1\" EventPositionRequest=\"1.0.1\" EventPositionTrack=\"1.0.1\" " +
                          "EventDECTPowerLimitCnf=\"1.0.1\" EventPPCnf=\"2.0.0\" EventPPDevCnf=\"2.0.0\" EventPPDevSummary=\"1.0.1\" " +
                          "EventPPFirmwareUpdateCnf=\"1.0.2\" EventPPFirmwareUpdateOverview=\"1.0.1\" EventPPFirmwareUpdateStatus=\"1.0.2\" " +
                          "EventPPFirmwareURLCnf=\"1.0.2\" EventPPLoginVariantCnf=\"1.0.1\" EventPpProfileCnf=\"1.0.2\" EventPPState=\"1.1.3\" " +
                          "EventPPTransaction=\"1.0.1\" EventPPUserCnf=\"1.1.9\" EventPPUserSummary=\"1.0.3\" EventPreserveUserDeviceRelationCnf=\"1.0.1\" " +
                          "EventReadyForConferencing=\"1.0.1\" EventRegistrationTrafficShapingCnf=\"2.0.2\" EventRemoteAccessCnf=\"1.0.1\" " +
                          "EventRemoteSystemDumpCnf=\"1.0.2\" EventRestrictedSubscriptionDurationCnf=\"1.0.1\" EventRFPCaptureCnf=\"1.1.2\" " +
                          "EventRFPCapture=\"1.0.4\" EventRFPCnf=\"3.0.3\" EventRFPConnectAttempt=\"1.1.2\" EventRFPDetails=\"1.1.5\" EventRFPIpQuality=\"1.0.2\" " +
                          "EventRFPMediaStreamQuality=\"1.0.1\" EventRFPState=\"1.1.5\" EventRFPSummary=\"1.0.5\" EventRFPSyncQuality=\"1.0.2\" " +
                          "EventRFPSyncRel=\"1.0.1\" EventRTPCnf=\"3.0.1\" EventRTPConferenceStreamChg=\"1.0.1\" EventSARICnf=\"1.0.1\" EventSecureSIPCnf=\"2.0.1\" " +
                          "EventSecureOMMCertificateServerImportCnf=\"1.0.5\" EventSecurePROVCertificateServerImportCnf=\"1.0.5\" " +
                          "EventSecureSIPCertificateCnf=\"1.1.1\" EventSecureSIPCertificateServerImportCnf=\"2.0.5\" EventSupplicantCertificateCnf=\"1.0.0\" " +
                          "EventSupplicantCertificateServerImportCnf=\"1.0.0\" EventSupplicantCnf=\"1.0.0\" EventSiteCnf=\"1.0.2\" EventSiteSummary=\"1.0.2\" " +
                          "EventSNMPCnf=\"1.0.1\" EventSoftwareUpdateCnf=\"1.0.3\" EventSpecialBrandingCnf=\"1.0.2\" EventStbStateChange=\"1.0.1\" " +
                          "EventSuplServCnf=\"1.0.7\" EventSyslogServerCnf=\"1.0.2\" EventSystemCredentialsCnf=\"1.0.1\" EventSystemNameCnf=\"1.0.1\" " +
                          "EventSystemProvUpdTrigCnf=\"1.0.3\" EventSysToneSchemeCnf=\"1.0.1\" EventSysVoiceboxNumCnf=\"1.0.1\" EventUsedConfigURL=\"1.0.1\" " +
                          "EventUserDataImport=\"1.0.1\" EventUserDataServerCnf=\"2.0.2\" EventUserDeviceSyncOMMCnf=\"1.0.1\" EventUserMonitoringCnf=\"1.0.1\" " +
                          "EventVideoDevCnf=\"2.1.1\" EventVideoDevLink=\"1.0.1\" EventVideoDevSummary=\"1.0.1\" EventWLANClient=\"1.0.2\" " +
                          "EventWLANProfileCnf=\"2.0.3\" EventWLANRegDomainCnf=\"1.0.1\" EventXMLApplicationCnf=\"3.0.3\" EventCorporateDirectoryCnf=\"1.0.0\" " +
                          "EventCorporateDirectoryOrderCnf=\"1.0.0\" GenerateHealthStateAlarmTriggers=\"1.0.1\" GetAccount=\"1.0.5\" GetAccountSummary=\"1.0.2\" " +
                          "GetACLEntry=\"1.0.2\" GetActivePPDev=\"1.0.1\" GetAdditionalSettings=\"1.0.2\" GetAdvancedSIP=\"3.0.3\" GetAlarmTrigger=\"1.1.6\" " +
                          "GetAlarmTriggerSummary=\"1.0.1\" GetAutoDBBackupFileName=\"1.0.1\" GetAutoDBBackup=\"2.0.2\" GetBackupSIP=\"1.0.1\" GetBasicSIP=\"3.0.1\" " +
                          "GetBluetoothBeacon=\"2.0.1\" GetBluetoothBeaconSummary=\"1.0.1\" GetBluetoothClientStatistic=\"1.0.1\" GetBluetoothGlobalSettings=\"1.0.1\" " +
                          "GetBluetoothSensitivity=\"1.0.1\" GetConferenceRoom=\"1.0.2\" GetConferenceServerSIP=\"1.0.2\" GetConfigURL=\"1.0.1\" " +
                          "GetCoreDumpURL=\"1.0.2\" GetDbTransferState=\"1.0.2\" GetDECTAuthCode=\"1.0.1\" GetDECTEncryption=\"1.0.1\" GetDECTPagingAreaSize=\"1.0.1\" " +
                          "GetDECTPpSettings=\"2.0.1\" GetDECTRegDomain=\"1.0.2\" GetDECTSubscriptionMode=\"1.0.1\" GetDevAutoCreate=\"1.0.1\" " +
                          "GetDigitTreatment=\"1.0.1\" GetDigitTreatmentSummary=\"1.0.1\" GetDTMF=\"1.0.1\" GetEULAConfirm=\"1.0.1\" GetEventLogBuffer=\"1.0.2\" " +
                          "GetFACList=\"1.0.3\" GetFACPrefix=\"1.0.1\" GetFile=\"1.0.4\" GetFlashMemUsage=\"1.0.1\" GetFreeConferenceChannels=\"1.0.1\" " +
                          "GetG729ChannelsForConference=\"1.0.1\" GetHealthState=\"1.1.9\" GetIMA=\"2.0.2\" GetIntercomCallHandlingSIP=\"1.0.1\" " +
                          "GetLastPPDevAction=\"1.0.1\" GetLDAP=\"1.0.2\" GetLicensedCodecLines=\"1.0.1\" GetLicense=\"2.0.2\" GetLicenseServerList=\"1.0.1\" " +
                          "GetNetParams=\"1.0.1\" GetOMMCertificate=\"1.0.2\" GetPARK=\"1.0.1\" GetPortRangeSIP=\"1.0.1\" GetPPDev=\"2.0.0\" GetPPDevByIPEI=\"2.0.0\" " +
                          "GetPPDevSummary=\"1.0.2\" GetPPFirmwareUpdate=\"1.0.2\" GetPPFirmwareUpdateOverview=\"1.0.2\" GetPPFirmwareUpdateStatus=\"1.0.2\" " +
                          "GetPPFirmwareURL=\"1.0.2\" GetPPLoginVariant=\"1.0.1\" GetPpProfile=\"1.0.2\" GetPPState=\"1.1.2\" GetDECTPowerLimit=\"1.0.1\" " +
                          "GetPPUser=\"1.2.8\" GetPPUserByNumber=\"1.0.0\" GetPPUserSummary=\"1.0.3\" GetPreserveUserDeviceRelation=\"1.0.1\" GetPublicKey=\"1.0.1\" " +
                          "GetReadyForConferencing=\"1.0.1\" GetRegistrationTrafficShaping=\"2.0.2\" GetRemoteAccess=\"1.0.1\" GetRemoteSystemDump=\"1.0.2\" " +
                          "GetRestrictedSubscriptionDuration=\"1.0.1\" GetRFPCapture=\"1.1.2\" GetRFPCaptureList=\"1.1.5\" GetRFP=\"3.0.2\" GetRFPIpQuality=\"1.0.2\" " +
                          "GetRFPMediaStreamQuality=\"1.0.2\" GetRFPStatisticConfig=\"1.0.1\" GetRFPStatistic=\"1.0.2\" GetRFPSummary=\"1.0.5\" GetRFPSync=\"1.0.1\" " +
                          "GetRFPSyncQuality=\"1.0.2\" GetRTP=\"3.0.1\" GetSARI=\"1.0.1\" GetSecureSIP=\"2.0.1\" GetSecureOMMCertificateServerImport=\"1.0.4\" " +
                          "GetSecurePROVCertificateServerImport=\"1.0.4\" GetSecureSIPCertificate=\"1.1.1\" GetSecureSIPCertificateServerImport=\"2.0.4\" " +
                          "GetSupplicant=\"1.0.0\" GetSupplicantCertificate=\"1.0.0\" GetSupplicantCertificateServerImport=\"1.0.0\" GetSite=\"1.0.2\" " +
                          "GetSiteSummary=\"1.0.3\" GetSNMP=\"1.0.1\" GetSoftwareUpdate=\"1.0.2\" GetSpecialBranding=\"1.0.2\" GetStbState=\"1.0.1\" GetSuplServ=\"1.0.7\" " +
                          "GetSyslogServer=\"1.0.2\" GetSysStatisticConfig=\"1.0.1\" GetSysStatisticMinMax=\"1.0.2\" GetSysStatisticMinMaxRecord=\"1.0.2\" " +
                          "GetSysStatisticMinMaxSummary=\"1.0.2\" GetSysStatisticOccurrence=\"1.0.2\" GetSystemCredentials=\"1.0.1\" GetSystemName=\"1.0.1\" " +
                          "GetSystemProvUpdTrig=\"1.0.3\" GetSysToneScheme=\"1.0.1\" GetSysVoiceboxNum=\"1.0.1\" GetUsedConfigURL=\"1.0.1\" GetUserDataServer=\"2.0.2\" " +
                          "GetUserDeviceSyncOMM=\"1.0.1\" GetUserMonitoring=\"1.0.1\" GetVersions=\"2.1.2\" GetVideoDev=\"2.1.1\" GetVideoDevLink=\"1.0.1\" " +
                          "GetVideoDevSummary=\"1.0.1\" GetWLANClients=\"1.0.1\" GetWLANProfile=\"2.0.4\" GetWLANRegDomain=\"1.0.1\" GetWLANRegDomainList=\"1.0.1\" " +
                          "GetXMLApplication=\"3.0.3\" GetCorporateDirectory=\"1.0.0\" GetCorporateDirectoryOrder=\"1.0.0\" Limits=\"2.0.4\" ManualDBBackup=\"2.0.2\" " +
                          "ManualDBRestore=\"2.0.2\" ManualUserDataImport=\"1.0.1\" Open=\"1.0.18\" PARKFromServer=\"1.0.1\" Ping=\"1.0.2\" PutFile=\"1.1.5\" " +
                          "RequestPositionInfo=\"1.0.1\" ResetRFPMediaStreamQuality=\"1.0.2\" ResetRFPStatistic=\"1.0.2\" ResetSysStatistic=\"1.0.2\" " +
                          "SendMessage=\"1.0.7\" SetAccount=\"1.0.7\" SetACLEntry=\"1.0.1\" SetAdditionalSettings=\"1.0.2\" SetAdvancedSIP=\"3.0.3\" " +
                          "SetAlarmTrigger=\"1.0.7\" SetAutoDBBackup=\"2.0.2\" SetBackupSIP=\"1.0.1\" SetBasicSIP=\"2.0.1\" SetBluetoothBeacon=\"2.0.1\" " +
                          "SetBluetoothGlobalSettings=\"1.0.1\" SetBluetoothSensitivity=\"1.0.1\" SetConferenceRoom=\"1.0.2\" SetConferenceServerSIP=\"1.0.2\" " +
                          "SetConfigURL=\"1.0.2\" SetCoreDumpURL=\"1.0.2\" SetDECTAuthCode=\"1.0.1\" SetDECTEncryption=\"1.0.2\" SetDECTPagingAreaSize=\"1.0.1\" " +
                          "SetDECTPpSettings=\"2.0.1\" SetDECTRegDomain=\"1.1.2\" SetDECTSubscriptionMode=\"1.0.2\" SetDevAutoCreate=\"1.0.1\" " +
                          "SetDigitTreatment=\"1.0.1\" SetDTMF=\"1.0.1\" SetEULAConfirm=\"1.0.1\" SetFAC=\"1.0.3\" SetFACList=\"1.0.3\" SetFACPrefix=\"1.0.1\" " +
                          "SetIMA=\"2.0.3\" SetIntercomCallHandlingSIP=\"1.0.1\" SetLDAP=\"1.0.3\" SetLicenseServerList=\"1.0.1\" SetNetParams=\"1.0.1\" " +
                          "SetOMMCertificate=\"1.0.4\" SetPARK=\"1.0.1\" SetPortRangeSIP=\"1.0.1\" GetPP=\"2.0.0\" SetPP=\"2.0.0\" SetPPDev=\"2.0.0\" " +
                          "SetPPFirmwareUpdate=\"1.0.1\" SetPPFirmwareURL=\"1.0.2\" SetPPLink=\"1.0.1\" SetPPLoginVariant=\"1.0.2\" SetPpProfile=\"1.0.3\" " +
                          "SetPPUserDevRelation=\"1.0.1\" SetPPUser=\"1.1.9\" SetDECTPowerLimit=\"1.0.1\" SetPPUserTracking=\"1.0.1\" SetPreserveUserDeviceRelation=\"1.0.1\" " +
                          "SetRegistrationTrafficShaping=\"2.0.2\" SetRemoteAccess=\"1.0.1\" SetRemoteSystemDump=\"1.0.2\" SetRestrictedSubscriptionDuration=\"1.0.1\" " +
                          "SetRFPCapture=\"1.1.2\" SetRFP=\"2.0.2\" SetRTPConferenceStreamChg=\"1.0.1\" SetRTP=\"3.0.1\" SetSARI=\"1.0.1\" SetSecureSIP=\"2.0.1\" " +
                          "SetSecureOMMCertificateServerImport=\"1.0.4\" SetSecurePROVCertificateServerImport=\"1.0.4\" SetSecureSIPCertificate=\"1.1.2\" " +
                          "SetSecureSIPCertificateServerImport=\"2.0.4\" SetSupplicant=\"1.0.0\" SetSupplicantCertificate=\"1.0.2\" " +
                          "SetSupplicantCertificateServerImport=\"1.0.0\" SetSite=\"1.0.2\" SetSNMP=\"1.0.1\" SetSpecialBranding=\"1.0.2\" SetSuplServ=\"1.0.5\" " +
                          "SetSyslogServer=\"1.0.2\" SetSystemCredentials=\"1.0.1\" SetSystemName=\"1.0.1\" SetSystemProvUpdTrig=\"1.0.3\" SetSysToneScheme=\"1.0.1\" " +
                          "SetSysVoiceboxNum=\"1.0.1\" SetUserDataServer=\"2.0.2\" SetUserDeviceSyncOMM=\"1.0.1\" SetUserMonitoring=\"1.0.1\" SetVideoDev=\"2.1.1\" " +
                          "SetWLANProfile=\"2.0.8\" SetWLANRegDomain=\"1.1.1\" SetXMLApplication=\"3.0.3\" SetCorporateDirectory=\"1.0.0\" " +
                          "SetCorporateDirectoryOrder=\"1.0.0\" SoftwareUpdate=\"1.0.4\" Subscribe=\"3.1.2\" SystemRestart=\"1.0.2\" ApplicationDataChannel=\"1.0.0\" " +
                          "CreateApplicationDataChannel=\"1.0.0\" DeleteApplicationDataChannel=\"1.0.0\" EventApplicationDataChannel=\"1.0.0\" " +
                          "EventApplicationDataChannelCnf=\"1.0.0\" SubscribeApplicationDataChannel=\"1.0.0\" EventMOMControlState=\"1.0.0\" GetMOMControlState=\"1.0.0\" " +
                          "SetMOMControlState=\"1.0.0\" EventDECTSubscribe=\"1.0.0\" DECTSubscribeReject=\"1.0.0\" EventDECTLocate=\"1.0.0\" DECTLocateReject=\"1.0.0\" " +
                          "EventPPLogin=\"1.0.0\" EventPPUserMovedLocally=\"1.0.0\" EventPPLink=\"1.0.0\" EventPPSIPDeregistered=\"1.0.0\" PPSIPDeregister=\"1.0.0\" " +
                          "PPSIPRegister=\"1.0.0\" RouteEventFromMOM=\"1.0.0\" RouteRequestToMOM=\"1.0.0\" RouteResponseFromMOM=\"1.0.0\" EventEventFromMOM=\"1.0.0\" " +
                          "EventRequestToMOM=\"1.0.0\" EventResponseFromMOM=\"1.0.0\" ClientInfo=\"1.0.0\" EventClientInfo=\"1.0.0\" />";
            var getVersionsResp = _serializer.Deserialize<GetVersionsResp>(message);
            Assert.AreEqual("1.1.9", getVersionsResp.SetPPUser);
        }

        [TestMethod]
        public void CanSerializeGetVersions()
        {
            var getVersions = new GetVersions();
            var xml = _serializer.Serialize(getVersions);
            Assert.AreEqual("<GetVersions />", xml);
        }

        [TestMethod]
        public void CanDeserializeLimitsResp()
        {
            var message = "<LimitsResp axiClients=\"100\" omm=\"0\" codec=\"5\" rfpNum=\"4096\" site=\"250\" dnsServer=\"3\" " +
                          "ntpServer=\"3\" ppProfileNum=\"20\" limitRTT1=\"25\" limitRTT2=\"50\" limitRTT3=\"150\" limitRTT4=\"500\" " +
                          "ldapServer=\"5\" licLatency=\"43200\" ppnNum=\"10000\" records=\"20\" ssidWlan=\"4\" ssidWlanKey=\"4\" " +
                          "trigger=\"100\" urlLen=\"513\" userId=\"100\" wlanMacFilter=\"512\" xmlBuiltInAppl=\"15\" xmlDynAppl=\"10\" " +
                          "xmlCorpDirAppl=\"5\" wlanClients=\"262144\" wlanProfiles=\"20\" bluetoothBeacons=\"28672\" " +
                          "bluetoothNeighbours=\"8\" bluetoothRssiValues=\"6\" conferenceRooms=\"100\" certificateNum=\"10\" ppVideoDevNum=\"10\" />";
            var getVersionsResp = _serializer.Deserialize<LimitsResp>(message);
            Assert.AreEqual(10000, getVersionsResp.MaxPP);
        }

        [TestMethod]
        public void CanSerializeLimits()
        {
            var limits = new Limits();
            var xml = _serializer.Serialize(limits);
            Assert.AreEqual("<Limits />", xml);
        }

        [TestMethod]
        public void CanDeserializeEventPermissionChange()
        {
            var message = "<EventPermissionChange>" +
                          "<permission>AllCnfRead</permission><permission>AllCnfWrite</permission><permission>Messaging</permission>" +
                          "<permission>InfoMessaging</permission><permission>Alerting</permission><permission>LocatingAlert</permission>" +
                          "<permission>Locating</permission><permission>Monitoring</permission></EventPermissionChange>";
            var eventStgStateChange = _serializer.DeserializeEvent<EventPermissionChange>(message);
            Assert.AreEqual(eventStgStateChange.Permissions.Length, 8);
        }

        [TestMethod]
        public void CanDeserializeGetLicenseResp()
        {
            var message = "<GetLicenseResp type=\"standard\" state=\"activeLicense\" latency=\"22458\" park=\"1F102AF12C\">" +
                "<violation>noViolation</violation>" +
                "<licenseRfp id=\"0\" ethAddr=\"00:30:42:12:3E:45\" connected=\"1\" />" +
                "<sysLicense key=\"41TLW-RF9SJ-77UPA-N8JTP-MUH6C\" number=\"100\" systemLicenseVersion=\"7.1\" />" +
                "<msgLicense key=\"XHBP6-S1U6A-L9BF1-QSFER-ZRR4D\" number=\"10000\" messagingLicenseRcvMsgs=\"1\" />" +
                "<locLicense key=\"VRK87-5PAJK-BMVHM-AWG3A-2TJCN\" number=\"700\" locatingLicense=\"1\" /></GetLicenseResp>";
            var getLicenseResp = _serializer.Deserialize<GetLicenseResp>(message);
            Assert.AreEqual(LicenseViolationReason.NoViolation, getLicenseResp.Violation[0]);
            Assert.AreEqual("1F102AF12C", getLicenseResp.Park);
            Assert.AreEqual("7.1", getLicenseResp.SysLicense.SystemLicenseVersion);
        }

        [TestMethod]
        public void CanSerializedGetPPState()
        {
            var getPPState = new GetPPState{Ppn = 600};
            var xml = _serializer.Serialize(getPPState);
            Assert.AreEqual("<GetPPState ppn=\"600\" />", xml);
        }

        [TestMethod]
        public void CanDeserializeGetPPStateResp()
        {
            var message = "<GetPPStateResp ppn=\"600\" onHook=\"1\" registered=\"1\" silentCharging=\"0\" callState=\"idle\" " +
                "swVersion=\"5.00.SP5\" bluetooth=\"0\" regServerType=\"Primary\" regServerAddr=\"172.20.23.2\" " +
                "regServerPort=\"5060\" seq=\"600\" />";
            var getPPStateResp = _serializer.Deserialize<GetPPStateResp>(message);
            Assert.AreEqual("5.00.SP5", getPPStateResp.SwVersion);
            Assert.AreEqual(5060, getPPStateResp.RegServerPort.Value);
            Assert.IsTrue(getPPStateResp.OnHook);
            Assert.IsFalse(getPPStateResp.Bluetooth.Value);
        }

        [TestMethod]
        public void CanDeserializeEventDECTAuthCodeCnf()
        {
            var message = "<EventDECTAuthCodeCnf ac=\"0000\"/>";
            var eventDectAuthCodeCnf = _serializer.DeserializeEvent<EventDECTAuthCodeCnf>(message);
            Assert.AreEqual("0000", eventDectAuthCodeCnf.Ac);
        }

        [TestMethod]
        public void CanDeserializeEventPPState()
        {
            var message = "<EventPPState ppn=\"12\" swVersion=\"7.2\"/>";
            var eventPPState = _serializer.DeserializeEvent<EventPPState>(message);
            Assert.AreEqual("7.2", eventPPState.SwVersion);
        }
    }
}