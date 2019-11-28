using System.Xml.Serialization;

namespace mitelapi.Types
{
    /// <summary>
    /// This type contains all data fields which describe the location of a DECT phone.
    /// </summary>
    public class LocationType
    {
        /// <summary>
        /// ID of RFP the DECT phone has been located at
        /// </summary>
        [XmlAttribute("id")]
        public int Id { get; set; }

        /// <summary>
        /// RSSI of the new RFP at the time of the handover in call state or for the next call setup in negative form, e.g. "-75" for –75 dBm
        /// </summary>
        [XmlAttribute("rssiNew")]
        public int RssiNew { get; set; }

        /// <summary>
        /// RSSI of the old RFP at the time of the handover in call state or for the next call setup in negative form, e. g. "-75" for –75 dBm
        /// </summary>
        [XmlAttribute("rssiOld")]
        public int RssiOld { get; set; }

        /// <summary>
        /// Multiframe number the location has been recorded at, (1 increment per 160 ms)
        /// </summary>
        [XmlAttribute("nMultiFrame")]
        public uint MultiFrame { get; set; }
    }
}