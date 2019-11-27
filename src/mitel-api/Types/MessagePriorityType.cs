using System.Xml.Serialization;

namespace mitelapi.Types
{
    public enum MessagePriorityType
    {
        [XmlEnum("Normal")]
        Normal,
        [XmlEnum("Info")]
        Info,
        [XmlEnum("Low")]
        Low,
        [XmlEnum("High")]
        High,
        [XmlEnum("Emergency")]
        Emergency,
        [XmlEnum("LocatingAlert")]
        LocatingAlert
    }
}