using System.Xml.Serialization;

namespace mitelapi.Types
{
    public enum PPLanguageType
    {
        [XmlEnum(Name="English")]
        English, 
        [XmlEnum(Name="German")]
        German, 
        [XmlEnum(Name="French")]
        French, 
        [XmlEnum(Name="Spanish")]
        Spanish, 
        [XmlEnum(Name="Italian")]
        Italian, 
        [XmlEnum(Name="Dutch")]
        Dutch, 
        [XmlEnum(Name="Swedish")]
        Swedish, 
        [XmlEnum(Name="Portuguese")]
        Portuguese, 
        [XmlEnum(Name="Danish")]
        Danish, 
        [XmlEnum(Name="Finnish")]
        Finnish, 
        [XmlEnum(Name="Norwegian")]
        Norwegian, 
        [XmlEnum(Name="Czech")]
        Czech, 
        [XmlEnum(Name="Slovakian")]
        Slovakian, 
        [XmlEnum(Name="Hungarian")]
        Hungarian, 
        [XmlEnum(Name="Russian")]
        Russian, 
        [XmlEnum(Name="Turkish")]
        Turkish, 
        [XmlEnum(Name="Polish")]
        Polish, 
        [XmlEnum(Name="Estonian")]
        Estonian 
    }
}