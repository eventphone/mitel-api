using System.Xml.Serialization;

namespace mitelapi.Events
{
    public class EventAlarmCallProgress:BaseEvent
    {
        [XmlAttribute("ppn")]
        public int Ppn { get; set; }

        [XmlAttribute("trigger")]
        public string Trigger { get; set; }

        [XmlAttribute("id")]
        public uint Id { get; set; }

        [XmlAttribute("destAddr")]
        public string Destination { get; set; }

        [XmlAttribute("state")]
        public string State { get; set; }
    }
}