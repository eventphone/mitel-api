using System.Xml.Serialization;
using mitelapi.Messages;

namespace mitelapi.Events
{
    public class EventPPUserSummary : BaseEvent, IPPUserSummary
    {
        [XmlAttribute("nRecords")]
        public int TotalCount { get; set; }

        [XmlAttribute("nLocatable")]
        public int LocatableCount { get; set; }

        [XmlAttribute("nSipRegistration")]
        public int SipRegistrationCount { get; set; }
    }
}