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
        [XmlEnum(Name = "Inactive")]
        Inactive,
        /// <summary>
        /// RFP is not synchronized
        /// </summary>
        [XmlEnum(Name = "NotSynced")]
        NotSynced,
        /// <summary>
        /// RFP searches for other synchronized RFPs
        /// </summary>
        [XmlEnum(Name = "Searching")]
        Searching,
        /// <summary>
        /// RFP is synchronized
        /// </summary>
        [XmlEnum(Name = "Synced")]
        Synced
    }
}