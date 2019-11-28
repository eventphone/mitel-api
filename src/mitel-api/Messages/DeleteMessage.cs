using System.Xml.Serialization;

namespace mitelapi.Messages
{
    [XmlRoot("DeleteMessage", Namespace = "")]
    public class DeleteMessage : BaseRequest
    {
        /// <summary>
        /// Original send time of the message to be deleted.
        /// </summary>
        [XmlAttribute("sendTime")]
        public uint SendTime { get; set; }

        /// <summary>
        /// Message ID.
        /// </summary>
        [XmlAttribute("id")]
        public uint Id { get; set; }

        /// <summary>
        /// Recipient address of the message to be deleted.
        /// Must have the same scheme as the original message (e.g. "tel:" or "ppn:").
        /// </summary>
        [XmlAttribute("toAddr")]
        public string ToAddr { get; set; }
    }

    public class DeleteMessageResp : BaseResponse
    {
    }
}