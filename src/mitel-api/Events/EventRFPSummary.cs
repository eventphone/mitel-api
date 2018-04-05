using System.Xml.Serialization;
using mitelapi.Messages;

namespace mitelapi.Events
{
    [XmlRoot("EventRFPSummary", Namespace = "")]
    public class EventRFPSummary : BaseEvent,IRfpSummary
    {
        [XmlAttribute("nRFPs")]
        public int TotalCount { get; set; }

        [XmlAttribute("DECTactiveRFPs")]
        public int DectActiveCount { get; set; }

        [XmlAttribute("DECTactivatedRFPs")]
        public int DectActivatedCount { get; set; }

        [XmlAttribute("nConnected")]
        public int ConnectedCount { get; set; }
    }
}