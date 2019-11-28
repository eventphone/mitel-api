using System.Xml.Serialization;
using mitelapi.Types;

namespace mitelapi.Events
{
    /// <summary>
    /// This event is sent by OM AXI when the message queue of a DECT phone experiences some kind of progress.
    /// </summary>
    public class EventMessageProgress : BaseEvent
    {
        /// <summary>
        /// Original send time of the message.
        /// </summary>
        [XmlAttribute("sendTime")]
        public uint SendTime { get; set; }

        /// <summary>
        /// Message ID.
        /// </summary>
        [XmlAttribute("id")]
        public uint Id { get; set; }

        /// <summary>
        /// Original recipient address of the message.
        /// </summary>
        [XmlAttribute("toAddr")]
        public string ToAddr { get; set; }

        /// <summary>
        /// The kind of progress.
        /// </summary>
        [XmlAttribute("event")]
        public MessageProgressType Event { get; set; }
    }
}