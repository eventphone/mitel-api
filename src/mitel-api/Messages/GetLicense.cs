using System.Xml.Serialization;
using mitelapi.Interfaces;
using mitelapi.Types;

namespace mitelapi.Messages
{
    /// <summary>
    /// With this request the client can query the license configuration of the OMM.
    /// </summary>
    [XmlRoot("GetLicense")]
    public class GetLicense : BaseRequest
    {

    }

    public class GetLicenseResp : BaseResponse, ILicenseCnf
    {
        /// <inheritdoc />
        [XmlAttribute("type")]
        public LicenseSize Type { get; set; }
        
        /// <inheritdoc />
        [XmlAttribute("state")]
        public LicenseViolation State { get; set; }
        
        /// <inheritdoc />
        [XmlElement("violation")]
        public LicenseViolationReason[] Violation { get; set; }
        
        /// <inheritdoc />
        [XmlAttribute("latency")]
        public int Latency { get; set; }
        
        /// <inheritdoc />
        [XmlAttribute("park")]
        public string Park { get; set; }
        
        /// <inheritdoc />
        [XmlElement("licenseRfp")]
        public LicenseRFPType[] LicenseRFPs { get; set; }
        
        /// <inheritdoc />
        [XmlElement("sysLicense")]
        public SysLicenseType SysLicense { get; set; }
        
        /// <inheritdoc />
        [XmlElement("msgLicense")]
        public MsgLicenseType MsgLicense { get; set; }
        
        /// <inheritdoc />
        [XmlElement("locLicense")]
        public LocLicenseType LocLicense { get; set; }
    }
}