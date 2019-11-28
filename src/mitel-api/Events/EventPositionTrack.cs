using System.Xml.Serialization;

namespace mitelapi.Events
{
    /// <summary>
    /// This event is sent by OM AXI when DECT phone position tracking information has arrived.
    /// </summary>
    public class EventPositionTrack : BaseEvent
    {
        /// <summary>
        /// PPN being tracked
        /// </summary>
        [XmlAttribute("ppn")]
        public int Ppn { get; set; }

        /// <summary>
        /// ID of current RFP
        /// </summary>
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}