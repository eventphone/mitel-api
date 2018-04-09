using System.Xml.Serialization;

namespace mitelapi.Messages
{
    [XmlRoot("Limits")]
    public class Limits : BaseRequest
    {

    }

    public class LimitsResp : BaseResponse
    {
        /// <summary>
        /// Maximal number of supported AXI clients.
        /// </summary>
        [XmlAttribute("axiClients")]
        public int MaxAxiClients { get; set; }

        /// <summary>
        /// Maximal number of supported codecs.
        /// </summary>
        [XmlAttribute("codec")]
        public int MaxCodecs { get; set; }

        /// <summary>
        /// Maximal number of supported LDAP servers.
        /// </summary>
        [XmlAttribute("ldapServer")]
        public int MaxLdapServer { get; set; }

        /// <summary>
        /// Grace period timeout in seconds.
        /// </summary>
        [XmlAttribute("licLatency")]
        public int LicenseGracePeriod { get; set; }

        /// <summary>
        /// Maximal number of supported DECT phones.
        /// </summary>
        [XmlAttribute("ppnNum")]
        public int MaxPP { get; set; }

        /// <summary>
        /// Maximal number of records supported in one XML element.
        /// </summary>
        [XmlAttribute("records")]
        public int MaxXmlRecords { get; set; }

        /// <summary>
        /// Maximal number of supported RFPs.
        /// </summary>
        [XmlAttribute("rfpNum")]
        public int MaxRFP { get; set; }

        /// <summary>
        /// Maximal number of supported sites.
        /// </summary>
        [XmlAttribute("site")]
        public int MaxSites { get; set; }

        /// <summary>
        /// Maximal number of supported WLAN SSIDs.
        /// </summary>
        [XmlAttribute("ssidWlan")]
        public int MaxSSID { get; set; }

        /// <summary>
        /// Maximal number of supported WLAN keys of an SSID.
        /// </summary>
        [XmlAttribute("ssidWlanKey")]
        public int MaxWlanKeys { get; set; }

        /// <summary>
        /// Maximal number of supported DECT phone profiles.
        /// </summary>
        [XmlAttribute("ppProfileNum")]
        public int MaxProfiles { get; set; }

        /// <summary>
        /// Maximal number of supported SIP (trusted or local) certificates.
        /// </summary>
        [XmlAttribute("certificateNum")]
        public int MaxCertificates { get; set; }

        /// <summary>
        /// Maximal number of supported video devices for a DECT phone.
        /// </summary>
        [XmlAttribute("ppVideoDevNum")]
        public int MaxPPVideoDev { get; set; }

        /// <summary>
        /// Maximal number of supported alarm triggers.
        /// </summary>
        [XmlAttribute("trigger")]
        public int MaxAlarmTrigger { get; set; }

        /// <summary>
        /// Maximal supported length of an URL.
        /// </summary>
        [XmlAttribute("urlLen")]
        public int MaxUrlLength { get; set; }

        /// <summary>
        /// Maximal number of user account Ids.
        /// </summary>
        [XmlAttribute("userId")]
        public int MaxUserAccounts { get; set; }

        /// <summary>
        /// Maximal number of supported RFPM DNS servers.
        /// </summary>
        [XmlAttribute("dnsServer")]
        public int MaxDNSServer { get; set; }

        /// <summary>
        /// Maximal number of supported RFPM NTP servers.
        /// </summary>
        [XmlAttribute("ntpServer")]
        public int MaxNTPServer { get; set; }

        /// <summary>
        /// Maximal number of supported WLAN profiles.
        /// </summary>
        [XmlAttribute("wlanProfiles")]
        public int MaxWLANProfiles { get; set; }

        /// <summary>
        /// Maximal number of supported WLAN clients.
        /// </summary>
        [XmlAttribute("wlanClients")]
        public int MaxWLANClients { get; set; }

        /// <summary>
        /// Maximal number of supported WLAN MAC filters entries.
        /// </summary>
        [XmlAttribute("wlanMacFilter")]
        public int MaxWLANMacFilter { get; set; }

        /// <summary>
        /// Maximal number of supported built-in XML applications.
        /// </summary>
        [XmlAttribute("xmlBuiltInAppl")]
        public int MaxBuildInXmlApps { get; set; }

        /// <summary>
        /// Maximal number of supported Bluetooth beacons.
        /// </summary>
        [XmlAttribute("bluetoothBeacons")]
        public int MaxBluetoothBeacons { get; set; }

        /// <summary>
        /// Maximal number of supported Bluetooth beacon neighbors.
        /// </summary>
        [XmlAttribute("bluetoothNeighbours")]
        public int MaxBluetoothNeighbours { get; set; }

        /// <summary>
        /// Maximal number of supported Bluetooth RSSI values for a Bluetooth client.
        /// </summary>
        [XmlAttribute("bluetoothRssiValues")]
        public int MaxBluetoothRssiValues { get; set; }

        /// <summary>
        /// Maximal number of supported conference rooms.
        /// </summary>
        [XmlAttribute("conferenceRooms")]
        public int MaxConferenceRooms { get; set; }

        /// <summary>
        /// Maximal number of supported dynamic/configurable XML applications.
        /// </summary>
        [XmlAttribute("xmlDynAppl")]
        public int MaxDynamicXmlApps { get; set; }

        /// <summary>
        /// Maximal number of supported corporate directory XML applications contained in dynamic/configurable XML application entries.
        /// </summary>
        [XmlAttribute("xmlCorpDirAppl")]
        public int MaxCorporateDirectoryInXmlApps { get; set; }

        /// <summary>
        /// IP quality limit 1 for round trip time (rtt) in ms. Interval 1: 0 ms &lt; limitRTT1 ms
        /// </summary>
        [XmlAttribute("limitRTT1")]
        public int RTTLimit1 { get; set; }

        /// <summary>
        /// IP quality limit 2 for round trip time (rtt) in ms. Interval 2: limitRTT1 ms &lt; limitRTT2 ms
        /// </summary>
        [XmlAttribute("limitRTT2")]
        public int RTTLimit2 { get; set; }

        /// <summary>
        /// IP quality limit 3 for round trip time (rtt) in ms. Interval 3: limitRTT2 ms &lt; limitRTT3 ms
        /// </summary>
        [XmlAttribute("limitRTT3")]
        public int RTTLimit3 { get; set; }

        /// <summary>
        /// IP quality limit 4 for round trip time (rtt) in ms. Interval 4: limitRTT3 ms &lt; limitRTT4 ms Interval 5: &gt;= limitRTT4 ms
        /// </summary>
        [XmlAttribute("limitRTT4")]
        public int RTTLimit4 { get; set; }
    }
}