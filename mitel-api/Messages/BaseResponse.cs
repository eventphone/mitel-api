using System.ComponentModel;
using System.Xml.Serialization;

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
        public BaseResponse Element { get; set; }
    }

    [XmlInclude(typeof(OpenResp))]
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