using System.Xml.Serialization;

namespace mitelapi.Events
{
    /// Describes available subscription states
    public enum DECTSubscriptionStateType {
        /// <summary>
        /// Not subscribed 
        /// </summary>
        [XmlEnum(Name="No")]
        No,
        /// <summary>
        /// The subscription was made but not confirmed by the DECT phone 
        /// </summary>
        [XmlEnum(Name="Unconfirmed")]
        Unconfirmed,
        /// <summary>
        /// The subscription was confirmed 
        /// </summary>
        [XmlEnum(Name="Yes")]
        Yes,
    }
}