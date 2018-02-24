using System.Xml.Serialization;

namespace mitelapi.Events
{
    /// <summary>
    /// Describes the hardware type of a DECT device
    /// </summary>
    public enum HWTypeType 
    {
        [XmlEnum(Name = "Unknown")]
        Unknown,
        [XmlEnum(Name = "142d")]
        Type_142d,
        [XmlEnum(Name = "610d")]
        Type_610d,
        [XmlEnum(Name = "620d")]
        Type_620d,
        [XmlEnum(Name = "630d")]
        Type_630d,
        [XmlEnum(Name = "612d")]
        Type_612d,
        [XmlEnum(Name = "622d")]
        Type_622d,
        [XmlEnum(Name = "632d")]
        Type_632d,
        [XmlEnum(Name = "650c")]
        Type_650c,
        [XmlEnum(Name = "740cv")]
        Type_740cv,
        [XmlEnum(Name = "GAP")]
        GAP,
    }
}