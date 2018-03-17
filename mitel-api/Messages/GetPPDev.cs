using System.Xml.Serialization;
using mitelapi.Types;

namespace mitelapi.Messages
{
    public class GetPPDev : BaseRequest
    {
        [XmlAttribute("ppn")]
        public int Ppn { get; set; }

        [XmlAttribute("maxRecords")]
        public int MaxRecords { get; set; }
    }

    public class GetPPDevResp : BaseResponse
    {
        [XmlElement("pp")]
        public PPDevType[] Devices { get; set; }
    }
}
