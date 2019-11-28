using System.Xml.Serialization;

namespace mitelapi.Events
{
    /// <summary>
    /// This event is sent by OM AXI when the message queue of a DECT phone gets empty.
    /// </summary>
    public class EventMessageQueueEmpty : BaseEvent
    {
        /// <summary>
        /// The DECT phone which’s queue got empty.
        /// </summary>
        [XmlAttribute("ppn")]
        public int Ppn { get; set; }
    }
}