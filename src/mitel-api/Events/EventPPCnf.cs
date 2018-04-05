using mitelapi.Types;
using System.Xml.Serialization;

namespace mitelapi.Events
{
    /// <summary>
    /// This event is sent by OM AXI when this configuration item has been changed.
    /// To get this event the client has to subscribe to PPCnf. 
    /// This is allowed if the client has at least one of the following permissions: AllCnfRead. 
    /// The notification contains all attributes which have been changed. 
    /// This event is also sent upon creation of a record. 
    /// If the record has been deleted, this event is sent with only a uid in the user element and the attribute deleted="1". 
    /// </summary>
    [XmlRoot("EventPPCnf", Namespace = "")]
    public class EventPPCnf : BaseEvent 
    {
        /// <summary>
        /// Changed attributes
        /// </summary>        
        [XmlElement("user")]
        public PPUserType User { get; set;}

        /// <summary>
        /// boolean, default false  „1” or “true”, if this data set has been deleted 
        /// </summary>
        [XmlAttribute("deletedUser")]
        public bool DeletedUser { get; set; }

        [XmlElement("pp")]
        public PPDevType Device { get; set; }
    }
}