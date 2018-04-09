using System.Xml.Serialization;

namespace mitelapi.Types
{
    public enum OmmStbState
    {
        /// <summary>
        /// no OMM standby active
        /// </summary>
        None,
        /// <summary>
        /// OMM standby running and active
        /// </summary>
        [XmlEnum(Name = "OK")]
        OK,
        /// <summary>
        /// OMM standby active but the standby OMM is not visible or the database is not synchronized
        /// </summary>
        [XmlEnum(Name = "NotSynchronized")]
        NotSynchronized,
        /// <summary>
        /// OMM standby active, but OMMs do not fit together
        /// </summary>
        [XmlEnum(Name = "DifferentOMMTypes")]
        DifferentOMMTypes,
        /// <summary>
        /// OMM standby active, but OMMs do not fit together
        /// </summary>
        [XmlEnum(Name = "DifferentOMMVersions")]
        DifferentOMMVersions,
    }
}