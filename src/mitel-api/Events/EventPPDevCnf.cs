using mitelapi.Types;
using System.Xml.Serialization;

namespace mitelapi.Events
{
    /// <summary>
    /// This event is sent by OM AXI when this configuration item has been changed. 
    /// To get this event the client has to subscribe to PPDevCnf. 
    /// This is allowed if the client has at least one of the following permissions: AllCnfRead.
    /// The notification contains all attributes which have been changed. 
    /// This event is also sent upon creation of a record. 
    /// If the record has been deleted, this event is sent with only a ppn in the pp element and the attribute deleted="1". 
    /// </summary>
    public class EventPPDevCnf : BaseEvent
    {
        /// <summary>
        /// Changed attributes
        /// </summary>
        [XmlElement("pp")]
        public PPDevType PP { get; set; }

        /// <summary>
        /// boolean, default false  „1” or “true”, if this data set has been deleted 
        /// </summary>
        [XmlAttribute("deleted")]
        public bool Deleted { get; set; }
    }
}