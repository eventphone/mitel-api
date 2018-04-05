using System.Xml.Serialization;

namespace mitelapi.Types
{
    public enum MonitoringStateType 
    {
        /// <summary>
        /// The user monitoring state of this item is unknown 
        /// </summary>
        [XmlEnum(Name="Unknown")]
        Unknown,
        /// <summary>
        /// The user monitoring state of this item is available 
        /// </summary>
        [XmlEnum(Name="Available")]
        Available,
        /// <summary>
        /// The user monitoring state of this item is warning 
        /// </summary>
        [XmlEnum(Name="Warning")]
        Warning,
        /// <summary>
        /// The user monitoring state of this item is unavailable 
        /// </summary>
        [XmlEnum(Name="Unavailable")]
        Unavailable,
        /// <summary>
        /// The user monitoring state of this item is escalated  
        /// </summary>
        [XmlEnum(Name="Escalated")]
        Escalated,
    }
}