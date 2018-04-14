using System.Xml;
using System.Xml.Serialization;
using mitelapi.Types;

namespace mitelapi.Events
{
    /// <summary>
    /// This event is sent by OM AXI when the OMM permissions have changed (e. g. change license conditions).
    /// To get this event the client has to subscribe to SystemState.
    /// This is allowed if the client has at least one of the following permissions: AllCnfRead.
    /// </summary>
    public class EventPermissionChange : BaseEvent
    {
        [XmlElement("permission")]
        public PermissionType[] Permissions { get; set; }
    }
}