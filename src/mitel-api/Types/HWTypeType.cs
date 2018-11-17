using System.Xml.Serialization;

namespace mitelapi.Types
{
    /// <summary>
    /// Describes the hardware type of a DECT device
    /// </summary>
    public enum HWTypeType 
    {
        [XmlEnum("Unknown")]
        Unknown,
        [XmlEnum("142d")]
        Type_142d,
        [XmlEnum("610d")]
        Type_610d,
        [XmlEnum("620d")]
        Type_620d,
        [XmlEnum("630d")]
        Type_630d,
        [XmlEnum("612d")]
        Type_612d,
        [XmlEnum("612v2")]
        Type_612v2,
        [XmlEnum("622d")]
        Type_622d,
        [XmlEnum(Name = "622v2")]
        Type_622v2,
        [XmlEnum("632d")]
        Type_632d,
        [XmlEnum("650c")]
        Type_650c,
        [XmlEnum("740cv")]
        Type_740cv,
        [XmlEnum("GAP")]
        GAP,
    }
}