using System.Xml.Serialization;

namespace mitelapi.Types
{
    public enum MessageConfirmType
    {
        /// <summary>
        /// Message was opened for reading
        /// </summary>
        [XmlEnum("ReadYes")]
        ReadYes,
        /// <summary>
        /// Message was deleted without reading it.
        /// </summary>
        [XmlEnum("ReadNo")]
        ReadNo,
        /// <summary>
        /// Order accepted
        /// </summary>
        [XmlEnum("OrderOk")]
        OrderOk,
        /// <summary>
        /// Order not accepted
        /// </summary>
        [XmlEnum("OrderNok")]
        OrderNok,
        /// <summary>
        /// Not sure whether the order could be accomplished
        /// </summary>
        [XmlEnum("OrderDontKnow")]
        OrderDontKnow,
        /// <summary>
        /// Accomplished
        /// </summary>
        [XmlEnum("CompleteDone")]
        CompleteDone,
        /// <summary>
        /// Not accomplished
        /// </summary>
        [XmlEnum("CompleteNotDone")]
        CompleteNotDone,
        /// <summary>
        /// Failed to accomplish order
        /// </summary>
        [XmlEnum("CompleteFailed")]
        CompleteFailed
    }
}