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
        [XmlEnum(Name = "None")]
        None,
        /// <summary>
        /// North American TX power limit
        /// </summary>
        [XmlEnum(Name = "LowTX")]
        LowTX,
        /// <summary>
        /// European TX power limit
        /// </summary>
        [XmlEnum(Name = "NormalTX")]
        NormalTX,
        /// <summary>
        /// The power limit can be configured
        /// </summary>
        [XmlEnum(Name = "ConfigurableTX")]
        ConfigurableTX
    }
}