using System.Xml.Serialization;
using mitelapi.Messages;
using mitelapi.Types;

namespace mitelapi.Events
{
    [XmlRoot("EventDECTSubscriptionMode", Namespace = "")]
    public class EventDECTSubscriptionMode:BaseEvent
    {
        [XmlAttribute("mode")]
        public DECTSubscriptionModeType Mode { get; set; }
    }
}