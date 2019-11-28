using System.Xml.Serialization;

namespace mitelapi.Events
{
    /// <summary>
    /// This event is sent by OM AXI when a user wants to locate another DECT phone using his DECT phone.
    /// </summary>
    public class EventPositionRequest : BaseEvent
    {
        /// <summary>
        /// Number of user who wants to locate somebody
        /// </summary>
        [XmlAttribute("num")]
        public string Num { get; set; }

        /// <summary>
        /// Name of the user who wants to locate somebody, optional and for informational purposes only
        /// </summary>
        [XmlAttribute("name")]
        public string Name { get; set; }

        /// <summary>
        /// Number of user who has to be located
        /// </summary>
        [XmlAttribute("targetNum")]
        public string TargetNum { get; set; }

        /// <summary>
        /// Name of the user who has to be located, optional and for informational purposes only.
        /// </summary>
        [XmlAttribute("targetName")]
        public string TargetName { get; set; }
    }
}