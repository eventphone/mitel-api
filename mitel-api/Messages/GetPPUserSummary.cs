using System.Xml.Serialization;

namespace mitelapi.Messages
{
    //<GetPPUserSummary />
    public class GetPPUserSummary : BaseRequest
    {
    }

    //<GetPPUserSummaryResp nRecords="3" uidFirst="1" nLocatable="0" nBtLocatable="0" nMsgSend="2" nSipRegistration="0" usersActiveMonitored="0" usersPassiveMonitored="0" usersWarned="0" usersUnavailable="0" usersEscalated="0" />
    public interface IPPUserSummary
    {
        int TotalCount { get; set; }
        int LocatableCount { get; set; }
        int SipRegistrationCount { get; set; }
    }

    [XmlRoot("GetPPUserSummaryResp", Namespace = "")]
    public class GetPPUserSummaryResp : BaseResponse, IPPUserSummary
    {
        [XmlAttribute("nRecords")]
        public int TotalCount { get; set; }

        [XmlAttribute("nLocatable")]
        public int LocatableCount { get; set; }

        [XmlAttribute("nSipRegistration")]
        public int SipRegistrationCount { get; set; }
    }
}