using System.Xml.Serialization;
using mitelapi.Types;

namespace mitelapi.Messages
{
    public class CreatePPDev : BaseRequest
    {
        [XmlElement("pp")]
        public PPDevType PortablePart { get; set; }
    }

    public class CreatePPDevResp : BaseResponse
    {
        [XmlElement("pp")]
        public PPDevType PortablePart { get; set; }
    }
}