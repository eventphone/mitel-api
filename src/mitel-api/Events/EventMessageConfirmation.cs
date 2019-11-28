using System.Xml.Serialization;
using mitelapi.Types;

namespace mitelapi.Events
{
    /// <summary>
    /// This event is sent by the OM AXI when a notification session containing the type MessageConfirmation is active for a DECT phone and when there is a confirmation for a message of this DECT phone.
    /// </summary>
    public class EventMessageConfirmation : BaseEvent
    {
        /// <summary>
        /// Original send time.
        /// </summary>
        [XmlAttribute("sendTime")]
        public uint SendTime { get; set; }

        /// <summary>
        /// Original message ID.
        /// </summary>
        [XmlAttribute("id")]
        public uint Id { get; set; }

        /// <summary>
        /// Sender address of confirmed message. This is the destination of the confirmation.
        /// </summary>
        [XmlAttribute("fromAddr")]
        public string FromAddr { get; set; }

        /// <summary>
        /// Recipient address of confirmed message.
        /// </summary>
        [XmlAttribute("toAddr")]
        public string ToAddr { get; set; }

        /// <summary>
        /// Time of confirmation, same format as sendTime.
        /// </summary>
        [XmlAttribute("confTime")]
        public uint ConfTime { get; set; }

        /// <summary>
        /// Confirmation for this message.
        /// </summary>
        [XmlAttribute("confirmation")]
        public MessageConfirmType Confirmation { get; set; }
    }
}