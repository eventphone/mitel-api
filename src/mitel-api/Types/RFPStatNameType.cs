using System.Xml.Serialization;

namespace mitelapi.Types
{
    /// <summary>
    /// This type contains the information about a single RFP statistic element.
    /// </summary>
    public class RFPStatNameType
    {
        /// <summary>
        /// Unique element id of a record-element
        /// </summary>
        [XmlAttribute("elemId")]
        public int Id { get; set; }

        /// <summary>
        /// String to identify the different element groups
        /// </summary>
        [XmlAttribute("group")]
        public string Group { get; set; }

        /// <summary>
        /// Name and meaning of the current element in English
        /// </summary>
        [XmlAttribute("name")]
        public string Name { get; set; }
    }
}