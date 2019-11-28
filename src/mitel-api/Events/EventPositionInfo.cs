using System.Xml.Serialization;
using mitelapi.Types;

namespace mitelapi.Events
{
    /// <summary>
    /// This event is sent by OM AXI when information about the current DECT phone position has arrived.
    /// </summary>
    public class EventPositionInfo : BaseEvent
    {
        /// <summary>
        /// PPN being located
        /// </summary>
        [XmlAttribute("ppn")]
        public int Ppn { get; set; }

        /// <summary>
        /// A list of all RFPs currently visible
        /// </summary>
        [XmlElement("vis")]
        public VisibilityType[] Visibility { get; set; }
    }
}