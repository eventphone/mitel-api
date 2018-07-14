using System.Xml.Serialization;
using mitelapi.Interfaces;
using mitelapi.Types;

namespace mitelapi.Events
{
    /// <summary>
    /// This event is sent by OM AXI when this configuration item has been changed.
    /// To get this event the client has to subscribe to SystemState.
    /// This is allowed if the client has at least one of the following permissions: AllCnfRead.
    /// </summary>
    public class EventLicenseCnf : BaseEvent, ILicenseCnf
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