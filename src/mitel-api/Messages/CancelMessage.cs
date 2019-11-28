using System.Xml.Serialization;

namespace mitelapi.Messages
{
    [XmlRoot("CancelMessage", Namespace = "")]
    public class CancelMessage : BaseRequest
    {
        /// <summary>
        /// Original send time of the message to be cancelled.
        /// </summary>
        [XmlAttribute("sendTime")]
        public uint SendTime { get; set; }

        /// <summary>
        /// Message ID.
        /// </summary>
        [XmlAttribute("id")]
        public uint Id { get; set; }

        /// <summary>
        /// Recipient address of the message to be cancelled.
        /// Must have the same scheme as the original message ( e. g. "tel:" or "ppn:").
        /// </summary>
        [XmlAttribute("toAddr")]
        public string ToAddr { get; set; }
    }

    public class CancelMessageResp : BaseResponse
    {
    }
}