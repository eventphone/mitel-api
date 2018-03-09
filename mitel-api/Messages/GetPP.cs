using System.Xml.Serialization;
using mitelapi.Types;

namespace mitelapi.Messages
{
    public class GetPP : BaseRequest
    {
        [XmlAttribute("uid")]
        public int uid;
        [XmlAttribute("ppn")]
        public int ppn;
    }

    public class GetPPResp : BaseResponse
    {
        [XmlElement("user")]
        public PPUserType User;
        [XmlElement("pp")]
        public PPDevType PortablePart;

    }
}
