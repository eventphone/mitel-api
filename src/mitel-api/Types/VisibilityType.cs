using System.Xml.Serialization;

namespace mitelapi.Types
{
    /// <summary>
    /// This type contains all data fields which describe the visibility of an RFP to a DECT phone.
    /// </summary>
    public class VisibilityType
    {
        /// <summary>
        /// ID of RFP which can be seen by the DECT phone
        /// </summary>
        [XmlAttribute("id")]
        public int Id { get; set; }

        /// <summary>
        /// Filtered RSSI value in negative form, e.g. "-75" for –75 dBm
        /// </summary>
        [XmlAttribute("rssiAvg")]
        public int RssiAvg { get; set; }
    }
}