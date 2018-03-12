using System;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;

namespace mitelapi.Messages
{
    /// <summary>
    /// With this request a client can upload a file to the OMM.
    /// </summary>
    [XmlRoot("PutFile", Namespace = "")]
    public class PutFile:BaseRequest
    {
        public PutFile()
        {
            Data = String.Empty;
        }

        /// <summary>
        /// File name
        /// </summary>
        [XmlAttribute("name")]
        public string Name { get; set; }

        /// <summary>
        /// File offset, for reference reasons
        /// </summary>
        [XmlAttribute("offset")]
        public int Offset { get; set; }

        /// <summary>
        /// Base64 encoded file data block
        /// <remarks>
        /// In some cases data might be empty (e. g. for :ima), then the file will be deleted. 
        /// </remarks> 
        /// </summary>
        [XmlAttribute("data")]
        public string Data { get; set; }
        
        [XmlIgnore]
        public bool? Eof
        {
            get { return XmlEofSpecified ? (bool?)XmlEof : null; }
            set
            {
                XmlEofSpecified = value.HasValue;
                XmlEof = value.GetValueOrDefault();
            }
        }
        
        [XmlAttribute("eof")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlEof { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlEofSpecified { get; set; }
    }
    
    [XmlRoot("PutFileResp", Namespace = "")]
    public class PutFileResp : BaseResponse
    {

    }
}