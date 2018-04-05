using mitelapi.Types;
using System.Xml.Serialization;

namespace mitelapi.Messages
{
    [XmlRoot("SetPPUser", Namespace = "")]
    public class SetPPUser : BaseRequest
    {
        [XmlElement("user")]
        public PPUserType User { get; set; }
    }

    [XmlRoot("SetPPUserResp", Namespace = "")]
    public class SetPPUserResp : BaseResponse
    {
        [XmlElement("user")]
        public PPUserType User { get; set; }
    }

}