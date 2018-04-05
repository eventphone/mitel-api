using System.Xml.Serialization;

namespace mitelapi.Messages
{
    public class DeletePPDev : BaseRequest
    {
        [XmlAttribute("ppn")]
        public int Ppn { get; set; }
    }

    public class DeletePPDevResp : BaseResponse
    {

    }
}