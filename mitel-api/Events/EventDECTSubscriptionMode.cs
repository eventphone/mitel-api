using System.Xml.Serialization;
using mitelapi.Messages;

namespace mitelapi.Events
{
    [XmlRoot("EventDECTSubscriptionMode", Namespace = "")]
    public class EventDECTSubscriptionMode:BaseEvent
    {
        [XmlAttribute("mode")]
        public DECTSubscriptionMode Mode { get; set; }
    }
}