using System.Xml.Serialization;

namespace mitelapi.Types
{
    /// <summary>
    /// This type describes the SIP state of a DECT phone
    /// </summary>
    public enum PPUserSIPEventType
    {
        /// <summary>
        /// For the user of the DECT phone a SIP registration is started.
        /// </summary>
        [XmlEnum("sipRegistrationEvent")]
        Registration,
        /// <summary>
        /// For the user of the DECT phone a SIP registration is ended. The result is contained in PPSIPStateType.
        /// </summary>
        [XmlEnum("sipRegistrationEndEvent")]
        RegistrationEnd,
        /// <summary>
        /// For the user of the DECT phone a SIP notification event is received.
        /// </summary>
        [XmlEnum("sipNotifyEvent")]
        Notify
    }
}