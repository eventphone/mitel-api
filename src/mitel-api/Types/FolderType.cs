using System.Xml.Serialization;

namespace mitelapi.Types
{
    public enum FolderType
    {
        /// <summary>
        /// Do not store the message, must be combined with popUp=”1”
        /// </summary>
        [XmlEnum("None")]
        None,
        /// <summary>
        /// Show the message in Idle display only
        /// </summary>
        [XmlEnum("Idle")]
        Idle,
        /// <summary>
        /// Inbox
        /// </summary>
        [XmlEnum("Inbox")]
        Inbox,
        /// <summary>
        /// Add to inbox silently
        /// </summary>
        [XmlEnum("AddToInbox")]
        AddToInbox,
        /// <summary>
        /// Add this message to the pool of pre-defined messages
        /// </summary>
        [XmlEnum("AddToPreDefined")]
        AddToPreDefined,
        /// <summary>
        /// Add this message to the Outbox
        /// </summary>
        [XmlEnum("AddToOutbox")]
        AddToOutbox
    }
}