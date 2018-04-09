using mitelapi.Types;
using System.ComponentModel;
using System.Xml.Serialization;

namespace mitelapi.Messages
{
    public abstract class BaseResponse
    {
        /// <summary>
        /// Sequence number taken from the original request. Only filled in if the original request also had a sequence number.
        /// </summary>
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
        
        /// <summary>
        /// Fixed string codes described in the documentation for the particular requests.
        /// If this attribute is absent it implies that no error occurred.
        /// </summary>
        [XmlAttribute("errCode")]
        public OmmError ErrorCode { get; set; }
        
        /// <summary>
        /// This field may contain additional information about an error.
        /// It is free style text in English and used mainly to track errors.
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