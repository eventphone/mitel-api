using System.Xml.Serialization;

namespace mitelapi.Types
{
    public enum CallForwardStateType 
    {
        /// <summary>
        /// No call forward 
        /// </summary>
        [XmlEnum(Name="Off")]
        Off,
        /// <summary>
        /// Call forward on busy
        /// </summary>
        [XmlEnum(Name="Busy")]
        Busy,
        /// <summary>
        /// Call forward on no answer
        /// </summary>
        [XmlEnum(Name="NoAnswer")]
        NoAnswer,
        /// <summary>
        /// Call forward on busy and no answer
        /// </summary>
        [XmlEnum(Name="BusyNoAnswer")]
        BusyNoAnswer,
        /// <summary>
        /// Forward immediately
        /// </summary>
        [XmlEnum(Name="All")]
        All,
    }
}