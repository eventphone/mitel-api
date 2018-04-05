using System.Xml.Serialization;
using mitelapi.Types;

namespace mitelapi.Messages
{
    public class SetPPDev : BaseRequest
    {
        [XmlElement("pp")]
        public PPDevType PortablePart { get; set; }
    }

    public class SetPPDevResp : BaseResponse
    {
        [XmlElement("pp")]
        public PPDevType PortablePart { get; set; }
    }
}