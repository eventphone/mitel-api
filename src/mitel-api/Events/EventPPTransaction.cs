using mitelapi.Types;
using System.Xml.Serialization;

namespace mitelapi.Events
{
    /// <summary>
    /// This event is sent by OM AXI when a DECT phone transaction took place. Refer to chapter 4.1.4 on how to set up a notification session.
    /// </summary>
    public class EventPPTransaction : BaseEvent
    {
        /// <summary>
        /// One of the transaction types.
        /// </summary>
        [XmlAttribute("trType")]
        public TransactionTypeType TransactionType { get; set; }

        /// <summary>
        /// The DECT phone device related to this transaction.
        /// </summary>
        [XmlAttribute("ppn")]
        public int Ppn { get; set; }

        /// <summary>
        /// Contains the ID of the RFP the event took place on.
        /// The presence of this parameter indicates also an established link to the DECT phone.
        /// </summary>
        [XmlAttribute("rfpId")]
        public int RfpId { get; set; }
    }
}