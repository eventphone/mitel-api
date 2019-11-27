using System.Xml.Serialization;

namespace mitelapi.Types
{
    /// <summary>
    /// These are possible values for RFPHwTypeType:
    /// Note: Not all RFP HW types are currently existing or in use!
    /// </summary>
    public enum RFPHwTypeType
    {
        /// <summary>
        /// Hardware type not known
        /// </summary>
        [XmlEnum("unknown")]
        Unknown,
        /// <summary>
        /// Non WLAN indoor RFP
        /// </summary>
        [XmlEnum("RFP 31")]
        RFP31,
        /// <summary>
        /// Non WLAN outdoor RFP
        /// </summary>
        [XmlEnum("RFP 33")]
        RFP33,
        /// <summary>
        /// WLAN indoor RFP
        /// </summary>
        [XmlEnum("RFP 41")]
        RFP41,
        /// <summary>
        /// WLAN specific DECT (e. g. with encryption) indoor RFP
        /// </summary>
        [XmlEnum("RFP 42")]
        RFP42,
        /// <summary>
        /// WLAN specific DECT (e. g. with encryption) indoor RFP / US variant
        /// </summary>
        [XmlEnum("RFP 42 US")]
        RFP42US,
        /// <summary>
        /// Non WLAN specific DECT (e. g. with encryption) indoor RFP
        /// </summary>
        [XmlEnum("RFP 32")]
        RFP32,
        /// <summary>
        /// Non WLAN specific DECT (e. g. with encryption) indoor RFP / US variant
        /// </summary>
        [XmlEnum("RFP 32 US")]
        RFP32US,
        /// <summary>
        /// Non WLAN specific DECT (e. g. with encryption) outdoor RFP
        /// </summary>
        [XmlEnum("RFP 34")]
        RFP34,
        /// <summary>
        /// Non WLAN specific DECT (e. g. with encryption) outdoor RFP / US variant
        /// </summary>
        [XmlEnum("RFP 34 US")]
        RFP34US,
        /// <summary>
        /// Non WLAN indoor 3G RFP
        /// </summary>
        [XmlEnum("RFP 35")]
        RFP35,
        /// <summary>
        /// Non WLAN outdoor 3G RFP
        /// </summary>
        [XmlEnum("RFP 36")]
        RFP36,
        /// <summary>
        /// Non WLAN outdoor 3G RFP with outside DECT antennas
        /// </summary>
        [XmlEnum("RFP 37")]
        RFP37,
        /// <summary>
        /// WLAN indoor 3G RFP
        /// </summary>
        [XmlEnum("RFP 43")]
        RFP43,
        /// <summary>
        /// Non WLAN outdoor licensed RFP
        /// </summary>
        [XmlEnum("RFP L33")]
        RFPL33,
        /// <summary>
        /// WLAN indoor licensed RFP
        /// </summary>
        [XmlEnum("RFP L41")]
        RFPL41,
        /// <summary>
        /// WLAN specific DECT (e. g. with encryption) indoor licensed RFP
        /// </summary>
        [XmlEnum("RFP L42")]
        RFPL42,
        /// <summary>
        /// WLAN specific DECT (e. g. with encryption) indoor licensed RFP / US variant
        /// </summary>
        [XmlEnum("RFP L42 US")]
        RFPL42US,
        /// <summary>
        /// Non WLAN specific DECT (e. g. with encryption) indoor licensed RFP
        /// </summary>
        [XmlEnum("RFP L32")]
        RFPL32,
        /// <summary>
        /// Non WLAN specific DECT (e. g. with encryption) indoor licensed RFP / US variant
        /// </summary>
        [XmlEnum("RFP L32 US")]
        RFPL32US,
        /// <summary>
        /// Non WLAN specific DECT (e. g. with encryption) outdoor licensed RFP
        /// </summary>
        [XmlEnum("RFP L34")]
        RFPL34,
        /// <summary>
        /// Non WLAN specific DECT (e. g. with encryption) outdoor licensed RFP / US variant
        /// </summary>
        [XmlEnum("RFP L34 US")]
        RFPL34US,
        /// <summary>
        /// Non WLAN indoor NG licensed RFP
        /// </summary>
        [XmlEnum("RFP L35")]
        RFPL35,
        /// <summary>
        /// Non WLAN outdoor NG licensed RFP
        /// </summary>
        [XmlEnum("RFP L36")]
        RFPL36,
        /// <summary>
        /// Non WLAN outdoor NG licensed RFP with outside DECT antennas
        /// </summary>
        [XmlEnum("RFP L37")]
        RFPL37,
        /// <summary>
        /// WLAN indoor NG licensed RFP
        /// </summary>
        [XmlEnum("RFP L43")]
        RFPL43,
        /// <summary>
        /// Non WLAN outdoor single cell NG RFP
        /// </summary>
        [XmlEnum("RFP SL36")]
        RFPSL36,
        /// <summary>
        /// Non WLAN outdoor NG single cell RFP with outside DECT antennas
        /// </summary>
        [XmlEnum("RFP SL37")]
        RFPSL37,
        /// <summary>
        /// WLAN indoor NG single cell RFP
        /// </summary>
        [XmlEnum("RFP SL43")]
        RFPSL43,
        /// <summary>
        /// Non WLAN indoor 4G-RFP only with 4 DECT channels (“'entry level')
        /// </summary>
        [XmlEnum("RFP 44")]
        RFP44,
        /// <summary>
        /// Non WLAN indoor 4G-RFP (“professional”)
        /// </summary>
        [XmlEnum("RFP 45")]
        RFP45,
        /// <summary>
        /// Non WLAN indoor 4G-RFP with outside DECT antennas (“directional”)
        /// </summary>
        [XmlEnum("RFP 47")]
        RFP47,
        /// <summary>
        /// WLAN indoor 4G-RFP (“dual mode”)
        /// </summary>
        [XmlEnum("RFP 48")]
        RFP48,
        /// <summary>
        /// External (linux PC) conference mixer that is handled as an RFP in the OMM
        /// </summary>
        [XmlEnum("PC ECM")]
        PCECM,
    }
}