using System.Xml.Serialization;

namespace mitelapi.Types
{
    public enum PPUserCallStateType
    {
        [XmlEnum("none")]
        None,
        [XmlEnum("ringing")]
        Ringing,
        [XmlEnum("calling")]
        Calling,
        [XmlEnum("paging")]
        Paging,
        [XmlEnum("connected")]
        Connected,
        [XmlEnum("idle")]
        Idle,
    }
}