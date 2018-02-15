using System.Xml.Serialization;

namespace mitelapi.Messages
{
    //:<GetPPDevSummary />
    public class GetPPDevSummary : BaseRequest
    {
    }

    //<GetPPDevSummaryResp nRecords="3" ppnFirst="116" subscribedDevs="2" />
    [XmlRoot("GetPPDevSummaryResp", Namespace = "")]
    public class GetPPDevSummaryResp : BaseResponse
    {
        [XmlAttribute("nRecords")]
        public int TotalCount { get; set; }

        [XmlAttribute("subscribedDevs")]
        public int SubscribedCount { get; set; }
    }
}