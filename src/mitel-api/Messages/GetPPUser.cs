using System.Xml.Serialization;
using mitelapi.Types;

namespace mitelapi.Messages
{
    public class GetPPUser : BaseRequest
    {
        [XmlAttribute("uid")]
        public int Uid { get; set; }

        [XmlAttribute("maxRecords")]
        public int MaxRecords { get; set; }
    }

    public class GetPPUserResp : BaseResponse
    {
        [XmlElement("user")]
        public PPUserType[] Users { get; set; }
    }
}
