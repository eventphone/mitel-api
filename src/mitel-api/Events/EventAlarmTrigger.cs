using System;
using System.Xml.Serialization;

namespace mitelapi.Events
{

    public class EventAlarmTrigger : BaseEvent
    {
        /// <summary>
        /// Original send time in seconds since 01.01.1970 00:00, local time of the DECT system
        /// (note that the DECT system and the AXI client might be in different time zones – sendTime will not be adjusted to UTC).
        /// </summary>
        [XmlAttribute("sendTime")]
        public uint SendTime { get;set; }

        public DateTimeOffset Timestamp => DateTimeOffset.FromUnixTimeSeconds(SendTime);

        /// <summary>
        /// Alarm ID
        /// </summary>
        [XmlAttribute("id")]
        public uint Id { get; set; }

        /// <summary>
        /// Alarm trigger identifier
        /// </summary>
        [XmlAttribute("trigger")]
        public string Trigger { get;set; }

        /// <summary>
        /// If applicable: PPN of the DECT phone which triggered the alarm
        /// </summary>
        [XmlAttribute("ppn")]
        public int Ppn { get; set; }

        /// <summary>
        /// If applicable: user ID of the user which triggered the alarm
        /// </summary>
        [XmlAttribute("uid")]
        public int Uid { get; set; }

        /// <summary>
        /// Sender address. In URI format, e. g. “tel:4711”
        /// </summary>
        [XmlAttribute("fromAddr")]
        public string From { get; set; }

        /// <summary>
        /// If applicable: Destination for alarm call, e. g. "tel:110"
        /// </summary>
        [XmlAttribute("toAddr")]
        public string To { get; set; }

        /// <summary>
        /// Additional alarm trigger information for the application given as dial suffix.
        /// </summary>
        [XmlAttribute("dialSuffix")]
        public string DialSuffix { get; set; }

        /// <summary>
        /// Optional additional info about this alarm, always text/plain encoded in UTF-8
        /// </summary>
        [XmlAttribute("Content")]
        public string Content { get; set; }
    }
}