using System.Xml.Serialization;

namespace mitelapi.Types
{
    /// <summary>
    /// These are the possible values for RFPSyncStateType:
    /// </summary>
    public enum RFPSyncStateType
    {
        /// <summary>
        /// RFP not DECT active
        /// </summary>
        [XmlEnum("Inactive")]
        Inactive,
        /// <summary>
        /// RFP is not synchronized
        /// </summary>
        [XmlEnum("NotSynced")]
        NotSynced,
        /// <summary>
        /// RFP searches for other synchronized RFPs
        /// </summary>
        [XmlEnum("Searching")]
        Searching,
        /// <summary>
        /// RFP is synchronized
        /// </summary>
        [XmlEnum("Synced")]
        Synced
    }
}