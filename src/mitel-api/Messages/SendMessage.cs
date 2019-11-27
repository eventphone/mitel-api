using System.Xml.Serialization;
using mitelapi.Types;

namespace mitelapi.Messages
{
    [XmlRoot("SendMessage", Namespace = "")]
    public class SendMessage : BaseRequest
    {
        [XmlElement("msg")]
        public MessageType Msg { get; set; }
    }

    public class SendMessageResp : BaseResponse
    {

    }
}