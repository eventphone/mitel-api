using System.Xml.Serialization;

namespace mitelapi.Types
{
    public enum LicenseViolation
    {
        /// <summary>
        /// no valid OMM system license set
        /// </summary>
        [XmlEnum("noLicense”")]
        NoLicense,
        /// <summary>
        /// less than 2 license RFPs connected
        /// </summary>
        [XmlEnum("inactiveLicense")]
        InactiveLicense,
        /// <summary>
        /// configuration exceeds license limitation, e. g. too many RFPs configured
        /// </summary>
        [XmlEnum("inactiveLicenseBlocked")]
        InactiveLicenseBlocked,
        /// <summary>
        /// only 2 license RFPs are connected
        /// </summary>
        [XmlEnum("noRedundancyLicense")]
        NoRedundancyLicense,
        /// <summary>
        /// configuration exceeds license limitation
        /// </summary>
        [XmlEnum("noRedundancyLicenseBlocked")]
        NoRedundancyLicenseBlocked,
        /// <summary>
        /// all is fine
        /// </summary>
        [XmlEnum("activeLicense")]
        ActiveLicense,
        /// <summary>
        /// configuration exceeds license limitation
        /// </summary>
        [XmlEnum("activeLicenseBlocked")]
        ActiveLicenseBlocked,
    }
}