using System.Xml.Serialization;
using mitelapi.Types;

namespace mitelapi.Messages
{
    public class GetPPUserByNumber : BaseRequest
    {
        [XmlAttribute("num")]
        public string Num { get; set; }
    }
    
    public class GetPPUserByNumberResp : BaseResponse
    {
        [XmlElement("user")]
        public PPUserType User { get; set; }
    }
}