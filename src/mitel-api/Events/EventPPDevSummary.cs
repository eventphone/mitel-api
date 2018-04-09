using System.Xml.Serialization;
using mitelapi.Messages;

namespace mitelapi.Events
{
    public class EventPPDevSummary : BaseEvent, IPPDevSummary
    {
        [XmlAttribute("nRecords")]
        public int TotalCount { get; set; }

        [XmlAttribute("subscribedDevs")]
        public int SubscribedCount { get; set; }
    }
}