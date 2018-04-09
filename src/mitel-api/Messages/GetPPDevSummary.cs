using System.Xml.Serialization;

namespace mitelapi.Messages
{
    //:<GetPPDevSummary />
    public class GetPPDevSummary : BaseRequest
    {
    }

    //<GetPPDevSummaryResp nRecords="3" ppnFirst="116" subscribedDevs="2" />
    public interface IPPDevSummary
    {
        int TotalCount { get; set; }

        int SubscribedCount { get; set; }
    }

    public class GetPPDevSummaryResp : BaseResponse, IPPDevSummary
    {
        [XmlAttribute("nRecords")]
        public int TotalCount { get; set; }

        [XmlAttribute("subscribedDevs")]
        public int SubscribedCount { get; set; }
    }
}