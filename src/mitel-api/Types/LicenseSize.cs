using System.Xml.Serialization;

namespace mitelapi.Types
{
    public enum LicenseSize
    {
        /// <summary>
        /// own PARK, no activation for maximal 5 RFPs
        /// </summary>
        [XmlEnum("small")]
        Small,
        /// <summary>
        /// own PARK and license for all RFPs
        /// </summary>
        [XmlEnum("standard")]
        Standard
    }
}