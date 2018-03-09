using System.Xml.Serialization;
using mitelapi.Events;

namespace mitelapi.Messages
{
    [XmlRoot("root")]
    public class OmmResponseWrapper
    {
        [XmlElement(nameof(OpenResp), typeof(OpenResp))]
        [XmlElement(nameof(PingResp), typeof(PingResp))]
        [XmlElement(nameof(GetVersionsResp), typeof(GetVersionsResp))]
        [XmlElement(nameof(GetRFPSummaryResp), typeof(GetRFPSummaryResp))]
        [XmlElement(nameof(GetPPDevSummaryResp), typeof(GetPPDevSummaryResp))]
        [XmlElement(nameof(GetPPUserSummaryResp), typeof(GetPPUserSummaryResp))]
        [XmlElement(nameof(SetPPUserDevRelationResp), typeof(SetPPUserDevRelationResp))]
        [XmlElement(nameof(SubscribeResp), typeof(SubscribeResp))]
        [XmlElement(nameof(SetPPResp), typeof(SetPPResp))]
        [XmlElement(nameof(CreatePPUserResp), typeof(CreatePPUserResp))]
        public BaseResponse Response { get; set; }

        [XmlElement(nameof(EventDECTSubscriptionMode), typeof(EventDECTSubscriptionMode))]
        [XmlElement(nameof(EventRFPSummary), typeof(EventRFPSummary))]
        [XmlElement(nameof(EventAlarmCallProgress), typeof(EventAlarmCallProgress))]
        [XmlElement(nameof(EventPPDevSummary), typeof(EventPPDevSummary))]
        [XmlElement(nameof(EventPPUserSummary), typeof(EventPPUserSummary))]
        [XmlElement(nameof(EventPPDevCnf), typeof(EventPPDevCnf))]
        public BaseEvent Event { get; set; }
    }
}