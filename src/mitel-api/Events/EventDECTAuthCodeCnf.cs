using System.Xml.Serialization;

namespace mitelapi.Events
{
    /// <summary>
    /// This event is sent by OM AXI when this configuration item has been changed.
    /// To get this event the client has to subscribe to SystemCnf.
    /// This is allowed if the client has at least one of the following permissions: AllCnfRead.
    /// </summary>
    public class EventDECTAuthCodeCnf : BaseEvent
    {
        /// <summary>
        /// Changed DECT authentication code
        /// </summary>
        [XmlAttribute("ac")]
        public string Ac { get; set; }
    }
}