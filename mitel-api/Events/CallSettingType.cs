using System.Xml.Serialization;

namespace mitelapi.Events
{
    public enum CallSettingType 
    {
        [XmlEnum(Name="On")]
        On,
        
        [XmlEnum(Name="Off")]
        Off,
        
        [XmlEnum(Name="Global")]
        Global,
    }
}