using System.Xml.Serialization;
using mitelapi.Types;

namespace mitelapi.Events
{
    /// <summary>
    /// This event is sent by the OM AXI when a notification session containing the type MessageSend is active for a DECT phone or scheme and when there is a message sent from this DECT phone or to this address schema.
    /// </summary>
    public class EventMessageSend : BaseEvent
    {
        /// <summary>
        /// Message to be sent.
        /// </summary>
        [XmlElement("msg")]
        public MessageType Msg { get; set; }
    }
}