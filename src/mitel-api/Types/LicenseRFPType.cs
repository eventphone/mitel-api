using System.Xml.Serialization;

namespace mitelapi.Types
{
    /// <summary>
    /// This type contains all license RFP data fields. It is used in license the event and license responses.
    /// </summary>
    public class LicenseRFPType
    {
        /// <summary>
        /// Unique RFP identifier of the license RFP
        /// </summary>
        [XmlAttribute("id")]
        public int Id { get; set; }

        /// <summary>
        /// Ethernet address of the license RFP, format "00:11:22:aa:bb:cc"
        /// </summary>
        [XmlAttribute("ethAddr")]
        public string EthAddr { get; set; }

        /// <summary>
        /// "1" or "true", if the license RFP is connected
        /// </summary>
        [XmlAttribute("connected")]
        public bool Connected { get; set; }
    }
}