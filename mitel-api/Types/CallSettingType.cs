using System.Xml.Serialization;

namespace mitelapi.Types
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