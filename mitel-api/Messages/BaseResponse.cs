using System.ComponentModel;
using System.Xml.Serialization;
using mitelapi.Events;

namespace mitelapi.Messages
{
    [XmlRoot("root")]
    public class OmmResponseWrapper
    {
        [XmlElement(nameof(OpenResp), typeof(OpenResp))]
        [XmlElement(nameof(PingResp), typeof(PingResp))]
        [XmlElement(nameof(GetRFPSummaryResp), typeof(GetRFPSummaryResp))]
        [XmlElement(nameof(GetPPDevSummaryResp), typeof(GetPPDevSummaryResp))]
        [XmlElement(nameof(GetPPUserSummaryResp), typeof(GetPPUserSummaryResp))]
        [XmlElement(nameof(SubscribeResp), typeof(SubscribeResp))]
        public BaseResponse Response { get; set; }

        [XmlElement(nameof(EventDECTSubscriptionMode), typeof(EventDECTSubscriptionMode))]
        [XmlElement(nameof(EventRFPSummary), typeof(EventRFPSummary))]
        [XmlElement(nameof(EventAlarmCallProgress), typeof(EventAlarmCallProgress))]
        [XmlElement(nameof(EventPPDevSummary), typeof(EventPPDevSummary))]
        [XmlElement(nameof(EventPPUserSummary), typeof(EventPPUserSummary))]
        public BaseEvent Event { get; set; }
    }

    public abstract class BaseResponse
    {
        [XmlIgnore]
        public int? Seq
        {
            get { return XmlSeqSpecified ? (int?)XmlSeq : null; }
            set
            {
                XmlSeqSpecified = value.HasValue;
                XmlSeq = value.GetValueOrDefault();
            }
        }
        
        [XmlAttribute("seq")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int XmlSeq { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlSeqSpecified { get; set; }
        
        [XmlAttribute("errCode")]
        public OmmError ErrorCode { get; set; }
        
        /// <summary>
        /// This field may contain additional information about an error. It is free style text in English and used mainly to track errors.
        /// </summary>
        [XmlAttribute("info")]
        public string Info { get; set; }
        
        /// <summary>
        /// In case of EInval, EMissing or ETooLong: Name of the invalid attribute or element
        /// </summary>
        [XmlAttribute("bad")]
        public string ErrorBad { get; set; }
        
        /// <summary>
        /// In case of ETooLong: Maximal length (in characters, not bytes) expected for the erroneous attribute.
        /// </summary>
        [XmlIgnore]
        public int? ErrorMaxLength
        {
            get { return XmlErrorMaxLengthSpecified ? (int?)XmlErrorMaxLength : null; }
            set
            {
                XmlErrorMaxLengthSpecified = value.HasValue;
                XmlErrorMaxLength = value.GetValueOrDefault();
            }
        }
        
        [XmlAttribute("maxLen")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int XmlErrorMaxLength { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlErrorMaxLengthSpecified { get; set; }
    }
}