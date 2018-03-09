using mitelapi.Types;
using System.Xml.Serialization;

namespace mitelapi.Messages
{
    [XmlRoot("CreatePPUser", Namespace = "")]
    public class CreatePPUser:BaseRequest
    {
        [XmlElement("user")]
        public PPUserType User;
    }

    [XmlRoot("CreatePPUserResp", Namespace = "")]
    public class CreatePPUserResp:BaseResponse
    {
        [XmlElement("user")]
        public PPUserType User;
    }
}
