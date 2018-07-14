using System.Xml.Serialization;

namespace mitelapi.Types
{
    /// <summary>
    /// These are the possible values for RFPRadioTypeType:
    /// </summary>
    public enum RfpRadioTypeType
    {
        /// <summary>
        /// No power limit for this RFP
        /// </summary>
        [XmlEnum("None")]
        None,
        /// <summary>
        /// North American TX power limit
        /// </summary>
        [XmlEnum("LowTX")]
        LowTX,
        /// <summary>
        /// European TX power limit
        /// </summary>
        [XmlEnum("NormalTX")]
        NormalTX,
        /// <summary>
        /// The power limit can be configured
        /// </summary>
        [XmlEnum("ConfigurableTX")]
        ConfigurableTX
    }
}