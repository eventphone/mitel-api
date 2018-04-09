using mitelapi.Types;
using System.Xml.Serialization;

namespace mitelapi.Messages
{
    [XmlRoot("Subscribe", Namespace = "")]
    public class Subscribe : BaseRequest
    {
        /// <summary>
        /// Up to 20 event commands to be executed at once atomically.
        /// </summary>
        [XmlElement("e")]
        public SubscribeCmdType[] Commands { get; set; }
    }
    
    public class SubscribeResp:BaseResponse
    {
        /// <summary>
        /// The first event type which caused EInval or EPerm
        /// </summary>
        public EventType Event { get; set; }
    }
}