using System.Xml.Serialization;
namespace mitelapi.Types
{
    /// <summary>
    /// Describes the type of a relation between a DECT phone device and a DECT phone user 
    /// </summary>
    public enum PPRelTypeType {
        /// <summary>
        /// This  DECT phone device or  DECT phone user can be bound dynamically, currently it is unbound. 
        /// </summary>
        [XmlEnum("Unbound")]
        Unbound,
        /// <summary>
        /// This  DECT phone device or  DECT phone user can be bound dynamically, currently it is bound. 
        /// </summary>
        [XmlEnum("Dynamic")]
        Dynamic,
        /// <summary>
        /// This  DECT phone device or  DECT phone user has a fixed relation. 
        /// </summary>
        [XmlEnum("Fixed")]
        Fixed
    }
}
