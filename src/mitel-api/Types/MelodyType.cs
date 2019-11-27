using System.Xml.Serialization;

namespace mitelapi.Types
{
    public enum MelodyType
    {
        /// <summary>
        /// No melody (default)
        /// </summary>
        [XmlEnum("None")]
        None,
        /// <summary>
        /// Message melody 1 for internal DECT phone melody
        /// </summary>
        [XmlEnum("MsgMelody1")]
        MsgMelody1,
        /// <summary>
        /// Message melody 2 for internal DECT phone melody
        /// </summary>
        [XmlEnum("MsgMelody2")]
        MsgMelody2,
        /// <summary>
        /// Message melody 3 for internal DECT phone melody
        /// </summary>
        [XmlEnum("MsgMelody3")]
        MsgMelody3,
        /// <summary>
        /// Message melody 4 for internal DECT phone melody
        /// </summary>
        [XmlEnum("MsgMelody4")]
        MsgMelody4,
        /// <summary>
        /// Message melody 5 for internal DECT phone melody
        /// </summary>
        [XmlEnum("MsgMelody5")]
        MsgMelody5,
        /// <summary>
        /// Message melody 6 for internal DECT phone melody
        /// </summary>
        [XmlEnum("MsgMelody6")]
        MsgMelody6,
        /// <summary>
        /// Message melody 7 for internal DECT phone melody
        /// </summary>
        [XmlEnum("MsgMelody7")]
        MsgMelody7,
        /// <summary>
        /// Message melody 8 for internal DECT phone melody
        /// </summary>
        [XmlEnum("MsgMelody8")]
        MsgMelody8,
        /// <summary>
        /// Message melody 9 for internal DECT phone melody
        /// </summary>
        [XmlEnum("MsgMelody9")]
        MsgMelody9,
        /// <summary>
        /// Message melody 10 for internal DECT phone melody
        /// </summary>
        [XmlEnum("MsgMelody10")]
        MsgMelody10,
    }
}