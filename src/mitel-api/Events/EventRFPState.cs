using mitelapi.Types;
using System.Xml.Serialization;

namespace mitelapi.Events
{
    /// <summary>
    /// This event is sent by OM AXI when a change of a state attribute happened. Refer to chapter 4.1.4 on how to set
    /// up a notification session.
    /// To get this event the client has to subscribe to RFPState.This is allowed if the client has at least one of the
    /// following permissions: AllCnfRead.
    /// Items belonging to this group are those which are selected with withState.
    /// The notification contains all attributes which have been changed.Even attributes with default values will always
    /// be contained explicitly if their value has changed.
    /// This event is not sent upon deletion of an RFP.
    /// /// </summary>
    public class EventRFPState : BaseEvent 
    {
        /// <summary>
        /// Id of the RFP
        /// </summary>        
        [XmlElement("id")]
        public int Id { get; set;}

        /// <summary>
        /// Contains all attributes which have been changed
        /// </summary>
        [XmlElement("rfp")]
        public RFPType rfp { get; set; }
    }
}