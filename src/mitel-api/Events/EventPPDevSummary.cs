using System.Xml.Serialization;
using mitelapi.Messages;

namespace mitelapi.Events
{
    [XmlRoot("EventPPDevSummary", Namespace = "")]
    public class EventPPDevSummary : BaseEvent, IPPDevSummary
    {
        [XmlAttribute("nRecords")]
        public int TotalCount { get; set; }

        [XmlAttribute("subscribedDevs")]
        public int SubscribedCount { get; set; }
    }
}