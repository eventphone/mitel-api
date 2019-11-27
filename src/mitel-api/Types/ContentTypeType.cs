using System.Xml.Serialization;

namespace mitelapi.Types
{
    public enum ContentTypeType
    {
        [XmlEnum("text/plain")]
        Text,
        [XmlEnum("text/x-vcard")]
        VCard
    }
}