using System.Xml.Serialization;

namespace mitelapi.Types
{
    public enum LicenseViolationReason
    {
        /// <summary>
        /// no license violation
        /// </summary>
        [XmlEnum("noViolation")]
        NoViolation,
        /// <summary>
        /// no OMM system license configured
        /// </summary>
        [XmlEnum("noLicense")]
        NoLicense,
        /// <summary>
        /// too many RFPs configured
        /// </summary>
        [XmlEnum("numRFPs")]
        NumRFPs,
        /// <summary>
        /// license not valid for this software release
        /// </summary>
        [XmlEnum("swRelease")]
        SwRelease,
        /// <summary>
        /// too many users configured to locate
        /// </summary>
        [XmlEnum("numLocatables")]
        NumLocatables,
    }
}