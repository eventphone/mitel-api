using System.Xml.Serialization;

namespace mitelapi.Types
{
    /// <summary>
    /// This type contains all data fields of an alarm trigger.
    /// It is used in different requests and responses defined in this document.
    /// </summary>
    public class AlarmTriggerType
    {
        /// <summary>
        /// Alarm trigger ID, starts at 0, -1 is invalid
        /// </summary>
        [XmlAttribute("id")]
        public int Id { get; set; }

        /// <summary>
        /// Textual identifier of the alarm trigger, not case sensitive
        /// </summary>
        [XmlAttribute("triggerId")]
        public string TriggerId{ get; set; }

        /// <summary>
        /// Feature access code, not case sensitive
        /// </summary>
        [XmlAttribute("fac")]
        public string Fac{ get; set; }

        /// <summary>
        /// Comment
        /// </summary>
        [XmlAttribute("comment")]
        public string Comment{ get; set; }

        /// <summary>
        /// Phone number to be called
        /// </summary>
        [XmlAttribute("num")]
        public string Num{ get; set; }        
    }
}