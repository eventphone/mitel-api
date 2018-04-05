using System.ComponentModel;
using System.Xml.Serialization;

namespace mitelapi.Types
{
    /// <summary>
    /// This type contains the synchronization offset from an RFP to its neighbors. It has following attributes:
    /// If the attribute lost is set to true, this relation must be removed from the set of relations which may be stored at
    /// client side.
    /// </summary>
    public class SyncOffsetType
    {
        /// <summary>
        /// RFP ID of neighbor RFP
        /// </summary>
        [XmlAttribute("id")]
        public int Id { get; set; }

        /// <summary>
        /// Time offset in ns
        /// </summary>
        [XmlAttribute("offset")]
        public int Offset { get; set; }

        /// <summary>
        /// RSSI in dBm, e. g. –75
        /// </summary>
        [XmlAttribute("rssi")]
        public int Rssi { get; set; }

        /// <summary>
        /// „1” or “true”, if this relation has been lost
        /// </summary>
        [XmlIgnore]
        public bool Lost { get; set; }

        [XmlAttribute("lost")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string LostSerialize
        {
            get { return Lost ? "1" : "0"; }
            set { Lost = value == "1"; }
        }
    }
}