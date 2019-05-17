using System.Xml.Serialization;
using mitelapi.Types;

namespace mitelapi.Events
{
    /// <summary>
    /// This event is sent by OM AXI when this configuration item has been changed. Refer to chapter 4.1.4
    /// on how to set up a notification session.
    /// To get this event the client has to subscribe to RFPCnf.This is allowed if the client has at least one of the
    /// following permissions: AllCnfRead.
    /// Configuration items are all attributes which are not selected with withState or with withDetails.
    /// The notification contains all attributes which have been changed. Even attributes with default values will
    /// always be contained explicitly if their value has changed.
    /// This event is also sent upon creation of an RFP. If the RFP has been deleted, this event is sent with only
    /// an rfpId in the rfp element and the attribute deleted="1".
    /// </summary>
    public class EventRFPCnf : BaseEvent
    {
        /// <summary>
        /// Contains all attributes which have been changed.
        /// </summary>
        [XmlElement("rfp")]
        public RFPType Rfp { get; set; }

        /// <summary>
        /// „1” or “true”, if this data set has been deleted
        /// </summary>
        [XmlAttribute("deleted")]
        public bool Deleted { get; set; }
    }
}