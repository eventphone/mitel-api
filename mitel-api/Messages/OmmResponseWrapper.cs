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
        [XmlElement(nameof(GetPPResp), typeof(GetPPResp))]
        [XmlElement(nameof(CreatePPUserResp), typeof(CreatePPUserResp))]
        [XmlElement(nameof(GetPPUserResp), typeof(GetPPUserResp))]
        [XmlElement(nameof(SetPPUserResp), typeof(SetPPUserResp))]
        [XmlElement(nameof(GetPPDevResp), typeof(GetPPDevResp))]
        [XmlElement(nameof(DeletePPUserResp), typeof(DeletePPUserResp))]
        [XmlElement(nameof(PutFileResp), typeof(PutFileResp))]
        [XmlElement(nameof(GetRFPResp), typeof(GetRFPResp))]
        [XmlElement(nameof(SetRFPResp), typeof(SetRFPResp))]
        [XmlElement(nameof(GetRFPSyncResp), typeof(GetRFPSyncResp))]
        [XmlElement(nameof(GetRFPSyncQualityResp), typeof(GetRFPSyncQualityResp))]
        [XmlElement(nameof(GetRFPStatisticConfigResp), typeof(GetRFPStatisticConfigResp))]
        [XmlElement(nameof(GetRFPStatisticResp), typeof(GetRFPStatisticResp))]
        [XmlElement(nameof(GetDECTSubscriptionModeResp), typeof(GetDECTSubscriptionModeResp))]
        [XmlElement(nameof(SetDECTSubscriptionModeResp), typeof(SetDECTSubscriptionModeResp))]
        [XmlElement(nameof(GetDevAutoCreateResp), typeof(GetDevAutoCreateResp))]
        [XmlElement(nameof(SetDevAutoCreateResp), typeof(SetDevAutoCreateResp))]
        [XmlElement(nameof(CreateRFPResp), typeof(CreateRFPResp))]
        [XmlElement(nameof(DeleteRFPResp), typeof(DeleteRFPResp))]
        [XmlElement(nameof(GetRFPCaptureResp), typeof(GetRFPCaptureResp))]
        [XmlElement(nameof(SetRFPCaptureResp), typeof(SetRFPCaptureResp))]
        [XmlElement(nameof(DeleteRFPCaptureListResp), typeof(DeleteRFPCaptureListResp))]
        [XmlElement(nameof(DeleteRFPCaptureListElemResp), typeof(DeleteRFPCaptureListElemResp))]
        [XmlElement(nameof(GetRFPCaptureListResp), typeof(GetRFPCaptureListResp))]
        public BaseResponse Response { get; set; }

        [XmlElement(nameof(EventDECTSubscriptionMode), typeof(EventDECTSubscriptionMode))]
        [XmlElement(nameof(EventRFPSummary), typeof(EventRFPSummary))]
        [XmlElement(nameof(EventAlarmCallProgress), typeof(EventAlarmCallProgress))]
        [XmlElement(nameof(EventPPDevSummary), typeof(EventPPDevSummary))]
        [XmlElement(nameof(EventPPUserSummary), typeof(EventPPUserSummary))]
        [XmlElement(nameof(EventPPDevCnf), typeof(EventPPDevCnf))]
        [XmlElement(nameof(EventPPUserCnf), typeof(EventPPUserCnf))]
        [XmlElement(nameof(EventPPCnf), typeof(EventPPCnf))]
        [XmlElement(nameof(EventRFPSyncRel), typeof(EventRFPSyncRel))]
        [XmlElement(nameof(EventRFPState), typeof(EventRFPState))]
        [XmlElement(nameof(EventRFPSyncQuality), typeof(EventRFPSyncQuality))]
        public BaseEvent Event { get; set; }
    }
}