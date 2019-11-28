using System.Xml.Serialization;
using mitelapi.Types;

namespace mitelapi.Events
{
    /// <summary>
    /// This event is sent by OM AXI when information about the DECT phone position history has arrived.
    /// </summary>
    public class EventPositionHistory : BaseEvent
    {
        /// <summary>
        /// PPN being located
        /// </summary>
        [XmlAttribute("ppn")]
        public int Ppn { get; set; }

        /// <summary>
        /// Current multiframe number (1 increment per 160 ms)
        /// </summary>
        [XmlAttribute("nMultiFrame")]
        public uint MultiFrame { get; set; }

        /// <summary>
        /// A list of the last know locations, the first one is the latest
        /// </summary>
        [XmlElement("loc")]
        public LocationType[] Locations { get; set; }
    }
}