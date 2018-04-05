using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace mitelapi.Types
{
    /// <summary>
    /// This type contains the SYNC quality data of an RFP. It has following attributes:
    /// </summary>
    public class SyncQualityType
    {
        /// <summary>
        /// RFP id
        /// </summary>
        [XmlAttribute("id")]
        public int Id { get; set; }
        /// <summary>
        /// Number of relations with an RSSI-value greater than -73dBm
        /// </summary>
        [XmlAttribute("strongRels")]
        public int StrongRels { get; set; }
        /// <summary>
        /// Number of relations with an RSSI-value less than -73dB
        /// </summary>
        [XmlAttribute("lowRels")]
        public int LowRels { get; set; }
        /// <summary>
        /// Maximum RSSI value (in dBm) of the strong relations
        /// </summary>
        [XmlAttribute("maxRSSI")]
        public int MaxRSSI { get; set; }
        /// <summary>
        /// Minimum RSSI value (in dBm) of the low relations
        /// </summary>
        [XmlAttribute("minRSSI")]
        public int MinRSSI { get; set; }
    }
}
