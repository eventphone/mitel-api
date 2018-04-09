using System.ComponentModel;
using System.Xml.Serialization;

namespace mitelapi.Types
{
    public class SubscribeCmdType
    {
        public SubscribeCmdType()
        {
        }

        public SubscribeCmdType(EventType type)
        {
            Cmd = CmdType.On;
            Event = type;
        }

        /// <summary>
        /// “On” to set the subscription flag, “Off” to reset it.
        /// </summary>
        [XmlAttribute("cmd")]
        public CmdType Cmd { get; set; }

        /// <summary>
        /// The event type.
        /// </summary>
        [XmlAttribute("eventType")]
        public EventType Event { get; set; }
        
        /// <summary>
        /// The subscription command is valid for this DECT phone device.
        /// If it is –1, the command automatically refers to all items.
        /// If it is missing, no items are included.
        /// </summary>
        [XmlIgnore]
        public int? Ppn
        {
            get { return XmlPpnSpecified ? (int?)XmlPpn : null; }
            set
            {
                XmlPpnSpecified = value.HasValue;
                XmlPpn = value.GetValueOrDefault();
            }
        }
        
        [XmlAttribute("ppn")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long XmlPpn { get; set; }
        
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlPpnSpecified { get; set; }
        
        /// <summary>
        /// The subscription command is valid for this DECT phone user.
        /// If it is –1, the command automatically refers to all items.
        /// If it is missing, no items are included.
        /// </summary>
        [XmlIgnore]
        public int? Uid
        {
            get { return XmlUidSpecified ? (int?)XmlPpn : null; }
            set
            {
                XmlUidSpecified = value.HasValue;
                XmlUid = value.GetValueOrDefault();
            }
        }
        
        [XmlAttribute("uid")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long XmlUid { get; set; }
        
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlUidSpecified { get; set; }
        
        /// <summary>
        /// The subscription command is valid for this RFP.
        /// If it is –1, the command automatically refers to all RFPs.
        /// If it is missing, no RFPs are included.
        /// </summary>
        [XmlIgnore]
        public int? RfpId
        {
            get { return XmlRfpIdSpecified ? (int?)XmlPpn : null; }
            set
            {
                XmlRfpIdSpecified = value.HasValue;
                XmlRfpId = value.GetValueOrDefault();
            }
        }
        
        [XmlAttribute("rfpId")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long XmlRfpId { get; set; }
        
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlRfpIdSpecified { get; set; }
        
        /// <summary>
        /// The subscription command is valid for the OMM if this field has the value -1.
        /// If it is missing, the OMM is not included.
        /// </summary>
        [XmlIgnore]
        public int? Omm
        {
            get { return XmlOmmSpecified ? (int?)XmlPpn : null; }
            set
            {
                XmlOmmSpecified = value.HasValue;
                XmlOmm = value.GetValueOrDefault();
            }
        }
        
        [XmlAttribute("omm")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long XmlOmm { get; set; }
        
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlOmmSpecified { get; set; }
        
        /// <summary>
        /// Alarm triggers the client is interested in.
        /// If it is an empty String (“*”), the commands automatically refers to all alarm triggers.
        /// If it is missing, no triggers are included.
        /// Wildcards like “LOC-*” are also allowed.
        /// </summary>
        [XmlAttribute("trigger")]
        public string Trigger { get; set; }

        /// <summary>
        /// Address scheme the client is interested in (without ':').
        /// If it is an empty String (“*”), the commands automatically refers to all address schemes.
        /// If it is missing, no address scheme is included.
        /// </summary>
        [XmlAttribute("scheme")]
        public string Scheme { get; set; }
    }
}