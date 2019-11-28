using System.Xml.Serialization;

namespace mitelapi.Types
{
    public enum MessageProgressType
    {
        /// <summary>
        /// The message to be send has been removed from the queue by a higher prioritized message.
        /// If the client is still interested in sending this message, it should try again after getting an EventQueueEmpty.
        /// </summary>
        [XmlEnum("Overridden")]
        Overridden,
        /// <summary>
        /// The message deletion commands have been removed from the queue by a higher prioritized message.
        /// If the client is still interested in deleting this message, it should try again after getting an EventQueueEmpty.
        /// </summary>
        [XmlEnum("DeleteOverridden")]
        DeleteOverridden,
        /// <summary>
        /// The message has been delivered to the DECT phone.
        /// This does not mean that the user actually did open, read nor understand this message.
        /// </summary>
        [XmlEnum("Delivered")]
        Delivered,
        /// <summary>
        /// This event is sent in one of these two cases:
        /// - The message deletion command has been delivered to the DECT phone
        /// - The message which should be deleted has been removed from the queue in case it has not been send to the DECT phone yet.
        /// In both cases the deletion can be seen as completed.
        /// </summary>
        [XmlEnum("DeleteDelivered")]
        DeleteDelivered,
        /// <summary>
        /// The DECT phone was not been found yet.
        /// However, the OMM will continue to search for this DECT phone.
        /// This is for informational purposes only.
        /// When PagingTimeout is received during the client is waiting for a DeleteDelivered the client must know, that the DeleteMessage is trashed.
        /// The DeleteMessage has to be sent again by the client after timeout.
        /// </summary>
        [XmlEnum("PagingTimeout")]
        PagingTimeout,
        /// <summary>
        /// The message has not been accepted by the DECT phone. It should not be resent.
        /// </summary>
        [XmlEnum("Rejected")]
        Rejected,
        /// <summary>
        /// The message has not been accepted by the DECT phone.
        /// The DECT phone is temporarily busy and the message can be resent after a timeout.
        /// </summary>
        [XmlEnum("Busy")]
        Busy,
        /// <summary>
        /// The message has not been accepted by the DECT phone, because of a wrong character set.
        /// This must be the Latin1 character set.
        /// </summary>
        [XmlEnum("WrongCharacterSet")]
        WrongCharacterSet,
        /// <summary>
        /// The message has not been accepted by the DECT phone, because of an unknown URI format.
        /// </summary>
        [XmlEnum("WrongURI")]
        WrongUri,
        /// <summary>
        /// The message has not been accepted by the DECT phone, because the DECT phone is switched off.
        /// </summary>
        [XmlEnum("TemporaryUnavailable")]
        TemporaryUnavailable,
        /// <summary>
        /// The message has not been accepted by the DECT phone.
        /// The reason is unknown.
        /// </summary>
        [XmlEnum("Unknown")]
        Unknown,
    }
}