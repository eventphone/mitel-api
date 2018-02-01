using System.ComponentModel;
using System.Xml.Serialization;

namespace mitelapi.Messages
{
    [XmlRoot("root")]
    public class OmmResponseWrapper
    {
        [XmlElement(nameof(OpenResp), typeof(OpenResp))]
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
        
        [XmlAttribute("info")]
        public string Info { get; set; }
        
        [XmlAttribute("bad")]
        public string ErrorBad { get; set; }
        
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