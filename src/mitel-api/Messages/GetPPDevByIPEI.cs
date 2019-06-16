using System.Xml.Serialization;
using mitelapi.Types;

namespace mitelapi.Messages
{
    public class GetPPDevByIPEI : BaseRequest
    {
        [XmlAttribute("ipei")]
        public string Ipei { get; set; }
    }

    public class GetPPDevByIPEIResp : BaseResponse
    {
        [XmlElement("pp")]
        public PPDevType Device { get; set; }
    }
}