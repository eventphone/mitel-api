using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;

namespace mitelapi.Types
{
    /// <summary>
    /// This type contains all configuration data fields and state information about an RFP. It is used in different requests
    /// and responses defined in this document.Not all fields are used in all OMM versions and in all Request and
    /// Response types.
    /// </summary>
    public class RFPType
    {
        private static List<RFPHwTypeType> _outdoortypes = new List<RFPHwTypeType>() { RFPHwTypeType.RFP33, RFPHwTypeType.RFP34, RFPHwTypeType.RFP36, RFPHwTypeType.RFP37 };

        /// <summary>
        /// Unique RFP identifier. The numbering starts at 0
        /// </summary>
        [XmlAttribute("id")]
        public int Id { get; set; }

        /// <summary>
        /// Ethernet address, format "00:11:22:aa:bb:cc"
        /// </summary>
        [XmlAttribute("ethAddr")]
        public string EthAddr { get; set; }

        /// <summary>
        /// „1” or “true”, if DECT is enabled on this RFP
        /// </summary>
        [XmlIgnore]
        public bool DectOn { get; set; }

        [XmlAttribute("dectOn")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string DectOnSerialize
        {
            get { return DectOn ? "1" : "0"; }
            set { DectOn = value == "1"; }
        }

        /// <summary>
        /// „1” or “true”, if WLAN is enabled on this RFP
        /// </summary>
        [XmlIgnore]
        public bool WlanOn { get; set; }

        [XmlAttribute("wlanOn")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string WlanOnSerialize
        {
            get { return WlanOn ? "1" : "0"; }
            set { WlanOn = value == "1"; }
        }

        /// <summary>
        /// This RFP is used for licensing, it cannot be deleted
        /// </summary>
        [XmlIgnore]
        public bool LicenseRFP { get; set; }

        [XmlAttribute("licenseRfp")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string LicenseRFPSerialize
        {
            get { return LicenseRFP ? "1" : "0"; }
            set { LicenseRFP = value == "1"; }
        }

        /// <summary>
        /// Name of this RFP, free format text
        /// </summary>
        [XmlAttribute("name")]
        public string Name { get; set; }

        /// <summary>
        /// Position hierarchy level 1, free format text
        /// </summary>
        [XmlAttribute("hierarchy1")]
        public string Hierarchy1 { get; set; }

        /// <summary>
        /// Position hierarchy level 2, free format text
        /// </summary>
        [XmlAttribute("hierarchy2")]
        public string Hierarchy2 { get; set; }

        /// <summary>
        /// Position hierarchy level 3, free format text
        /// </summary>
        [XmlAttribute("hierarchy3")]
        public string Hierarchy3 { get; set; }

        /// <summary>
        /// Position hierarchy level 4, free format text
        /// </summary>
        [XmlAttribute("hierarchy4")]
        public string Hierarchy4 { get; set; }

        /// <summary>
        /// DECT RPN
        /// </summary>
        [XmlAttribute("rpn")]
        public int Rpn { get; set; }

        /// <summary>
        /// Paging area number, -1 for unassigned
        /// </summary>
        [XmlAttribute("pagingArea")]
        public int PagingArea { get; set; }

        /// <summary>
        /// Synchronization cluster, 0 is invalid
        /// </summary>
        [XmlAttribute("cluster")]
        public int Cluster { get; set; }

        /// <summary>
        /// This RFP is preferred in sync start up
        /// </summary>
        [XmlIgnore]
        public bool PreferredSync { get; set; }

        [XmlAttribute("preferredSync")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string PreferredSyncSerialize
        {
            get { return PreferredSync ? "1" : "0"; }
            set { PreferredSync = value == "1"; }
        }

        /// <summary>
        /// This RFP is located in a reflective environment
        /// </summary>
        [XmlIgnore]
        public bool ReflectiveEnv { get; set; }

        [XmlAttribute("reflectiveEnv")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ReflectiveEnvSerialize
        {
            get { return ReflectiveEnv ? "1" : "0"; }
            set { ReflectiveEnv = value == "1"; }
        }

        /// <summary>
        /// Reference to site data set id.
        /// </summary>
        [XmlAttribute("site")]
        public int Site { get; set; }

        /// <summary>
        /// X coordinate for visualization
        /// </summary>
        [XmlAttribute("x")]
        public int X { get; set; }

        /// <summary>
        /// Y coordinate for visualization
        /// </summary>
        [XmlAttribute("y")]
        public int Y { get; set; }

        /// <summary>
        /// Type of hardware for this RFP
        /// </summary>
        [XmlAttribute("hwType")]
        public RFPHwTypeType HwType { get; set; }

        /// <summary>
        /// Read only value to indicate the possibility to configure the hwType.
        /// Until the RFP did not connect ever to the OMM the value is false
        /// and hwType can be configured.The value never changes from true
        /// to false!
        /// </summary>
        [XmlIgnore]
        public bool HwTypeLocked { get; set; }

        [XmlAttribute("hwTypeLocked")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string HwTypeLockedSerialize
        {
            get { return HwTypeLocked ? "1" : "0"; }
            set { HwTypeLocked = value == "1"; }
        }

        /// <summary>
        /// WLAN profile 0 is invalid
        /// </summary>
        [XmlAttribute("wlanProfile")]
        public int WlanProfile { get; set; }

        /// <summary>
        /// „1” or “true”, if WLAN antenna diversity is set
        /// </summary>
        [XmlIgnore]
        public bool WlanAntennaDiv { get; set; }

        [XmlAttribute("wlanAntennaDiv")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string WlanAntennaDivSerialize
        {
            get { return WlanAntennaDiv ? "1" : "0"; }
            set { WlanAntennaDiv = value == "1"; }
        }

        /// <summary>
        /// Selected WLAN antenna, 1 or 2
        /// </summary>
        [XmlAttribute("wlanAntenna")]
        public int WlanAntenna { get; set; }

        /// <summary>
        /// Configured WLAN channel, one of 1 to 14, 36, 40, 44, 48, 52, 56,
        /// 60, 64, 100, 104, 108, 112, 116, 120, 124, 128, 132, 136, 140, 147,        /// 151, 155, 159, 163, 167, 171
        /// </summary>
        [XmlAttribute("wlanChannel")]
        public int WlanChannel { get; set; }

        /// <summary>
        /// "1” or “true”, if WLAN high throughput mode 40 is set
        /// </summary>
        [XmlIgnore]
        public bool WlanHighThroughput { get; set; }

        [XmlAttribute("wlanHighThroughput")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string WlanHighThroughputSerialize
        {
            get { return WlanHighThroughput ? "1" : "0"; }
            set { WlanHighThroughput = value == "1"; }
        }

        /// <summary>
        /// Cofigured WLAN transmit power in percent, one of 6, 12, 25, 50, 100.
        /// </summary>
        [XmlAttribute("wlanPower")]
        public int WlanPower { get; set; }

        /// <summary>
        /// „1” or “true”, if this RFP can be used for conference cahnnels
        /// </summary>
        [XmlIgnore]
        public bool ConferenceChannels { get; set; }

        [XmlAttribute("conferenceChannels")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ConferenceChannelsSerialize
        {
            get { return ConferenceChannels ? "1" : "0"; }
            set { ConferenceChannels = value == "1"; }
        }

        // The following attributes are transient (selected with withState in Requests):

        /// <summary>
        /// „1” or “true”, if this RFP is connected, transient
        /// </summary>
        [XmlIgnore]
        public bool Connected { get; set; }

        [XmlAttribute("connected")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ConnectedSerialize
        {
            get { return Connected ? "1" : "0"; }
            set { Connected = value == "1"; }
        }

        /// <summary>
        /// Current or last known IP address, transient
        /// </summary>
        [XmlAttribute("ipAddr")]
        public string IpAddr { get; set; }

        /// <summary>
        /// „1” or “true”, if this RFP requested the OMM to load new
        /// software., transient
        /// </summary>
        [XmlIgnore]
        public bool NewSoftwareRequest { get; set; }

        [XmlAttribute("newSoftwareRequest")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string NewSoftwareRequestSerialize
        {
            get { return NewSoftwareRequest ? "1" : "0"; }
            set { NewSoftwareRequest = value == "1"; }
        }

        /// <summary>
        /// 1” or “true”, if the DECT is running on this RFP., transient
        /// </summary>
        [XmlIgnore]
        public bool DectRunning { get; set; }

        [XmlAttribute("dectRunning")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string DectRunningSerialize
        {
            get { return DectRunning ? "1" : "0"; }
            set { DectRunning = value == "1"; }
        }

        /// <summary>
        /// „1” or “true”, if the WLAN is running on this RFP, transient
        /// </summary>
        [XmlIgnore]
        public bool WlanRunning { get; set; }

        [XmlAttribute("wlanRunning")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string WlanRunningSerialize
        {
            get { return WlanRunning ? "1" : "0"; }
            set { WlanRunning = value == "1"; }
        }

        /// <summary>
        /// „1” or “true”, if the OMM is running on this RFP, transient
        /// </summary>
        [XmlIgnore]
        public bool OmmRunning { get; set; }

        [XmlAttribute("ommRunning")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string OmmRunningSerialize
        {
            get { return OmmRunning ? "1" : "0"; }
            set { OmmRunning = value == "1"; }
        }

        /// <summary>
        /// „1” or “true”, if the standby OMM is running on this RFP, transient
        /// </summary>
        [XmlIgnore]
        public bool OmmStbRunning { get; set; }

        [XmlAttribute("ommStbRunning")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string OmmStbRunningSerialize
        {
            get { return OmmStbRunning ? "1" : "0"; }
            set { OmmStbRunning = value == "1"; }
        }

        /// <summary>
        /// „1” or “true”, if WLAN is supported by this RFP hardware
        /// </summary>
        [XmlIgnore]
        public bool HasWlan { get; set; }

        [XmlAttribute("hasWlan")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string HasWlanSerialize
        {
            get { return HasWlan ? "1" : "0"; }
            set { HasWlan = value == "1"; }
        }

        /// <summary>
        /// „1” or “true”, if encryption is supported by this RFP hardware
        /// These features can be configured within a site
        /// </summary>
        [XmlIgnore]
        public bool HasEncryption { get; set; }

        [XmlAttribute("hasEncryption")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string HasEncryptionSerialize
        {
            get { return HasEncryption ? "1" : "0"; }
            set { HasEncryption = value == "1"; }
        }

        /// <summary>
        /// „1” or “true”, if Hi-Q audio technology (wide band) G.722, terminal
        /// video, DECT security and secure SIP are supported by this RFP
        /// hardware.
        /// These features can be configured within a site.
        /// </summary>
        [XmlIgnore]
        public bool HasAdvancedFeatures { get; set; }

        [XmlAttribute("hasAdvancedFeatures")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string HasAdvancedFeaturesSerialize
        {
            get { return HasAdvancedFeatures ? "1" : "0"; }
            set { HasAdvancedFeatures = value == "1"; }
        }

        /// <summary>
        /// Current DECT synchronization state for this RFP.
        /// </summary>
        [XmlAttribute("syncState")]
        public RFPSyncStateType SyncState { get; set; }

        /// <summary>
        /// Current software version on this RFP in the format:
        /// <majorRelease>.<minorRelease>.{RC x | SP y | <bugfixVersion>}
        /// [Build z] [version description], 
        /// e. g. „2.1 RC4”, „2.1 SP1”, „2.1.5”, „2.1SP1 Build 2”,r
        /// „3.0 RC1 Build 1 - OpenMobility SIP 3.0RC1-Internal”.
        /// RCx: Release candidate number x
        /// SPy: Release service pack number y
        /// bugfixVersion: Old bugfix release version number
        /// Build z: Build release number z for internal use
        /// </summary>
        [XmlAttribute("swVersion")]
        public string SwVersion { get; set; }

        /// <summary>
        /// „1” or “true”, if branding of this RFP and OMM do not fit together
        /// </summary>
        [XmlIgnore]
        public bool BrandingMismatch { get; set; }

        [XmlAttribute("brandingMismatch")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string BrandingMismatchSerialize
        {
            get { return BrandingMismatch ? "1" : "0"; }
            set { BrandingMismatch = value == "1"; }
        }

        /// <summary>
        /// „1” or “true”, if software version of this RFP and OMM do not fit
        /// together
        /// </summary>
        [XmlIgnore]
        public bool VersionMismatch { get; set; }

        [XmlAttribute("versionMismatch")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string VersionMismatchSerialize
        {
            get { return VersionMismatch ? "1" : "0"; }
            set { VersionMismatch = value == "1"; }
        }

        /// <summary>
        /// „1” or “true”, if this RFP has an invalid OMM standby
        /// configuration.
        /// </summary>
        [XmlIgnore]
        public bool StbMismatch { get; set; }

        [XmlAttribute("stbMismatch")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string StbMismatchSerialize
        {
            get { return StbMismatch ? "1" : "0"; }
            set { StbMismatch = value == "1"; }
        }

        /// <summary>
        /// „1” or “true”, if the Ethernet link is too slow ( e. g. only 10 MBit/s)
        /// to enable WLAN on this RFP
        /// </summary>
        [XmlIgnore]
        public bool WlanLinkNok { get; set; }

        [XmlAttribute("wlanLinkNok")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string WlanLinkNokSerialize
        {
            get { return WlanLinkNok ? "1" : "0"; }
            set { WlanLinkNok = value == "1"; }
        }

        /// <summary>
        /// Used Channel one of 1 to 14, 36, 40, 44, 48, 52, 56, 60, 64, 100,
        /// 104, 108, 112, 116, 120, 124, 128, 132, 136, 140, 147, 151, 155,
        /// 159, 163, 167, 171.
        /// This value is read only.
        /// </summary>
        [XmlAttribute("wlanChannelUsed")]
        public int WlanChannelUsed { get; set; }

        /// <summary>
        /// Used high throughput channel type, one of “None”, “HT20”,
        /// “HT40Minus” or “HT40Plus” .
        /// This value is read only.
        /// </summary>
        [XmlAttribute("wlanHighThroughputTypeUsed")]
        public string WlanHighThroughputTypeUsed { get; set; }

        /// <summary>
        /// Used WLAN transmit power in DBM (decibel per milliwatt) .
        /// This value is read only.
        /// </summary>
        [XmlAttribute("wlanPowerUsed")]
        public int WlanPowerUsed { get; set; }

        /// <summary>
        /// Number of DECT synchronization relations
        /// </summary>
        [XmlAttribute("nSyncRels")]
        public int nSyncRels { get; set; }

        /// <summary>
        /// The DECT radio type of this RFP
        /// </summary>
        [XmlAttribute("radioType")]
        public RfpRadioTypeType RadioType { get; set; }

        /// <summary>
        /// „1” or “true”, if this is an outdoor RFP hardware
        /// </summary>
        [XmlIgnore]
        public bool OutdoorType { get; set; }

        [XmlAttribute("outdoorType")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string OutdoorTypeSerialize
        {
            get { return OutdoorType ? "1" : "0"; }
            set { OutdoorType = value == "1"; }
        }

        [XmlIgnore]
        public bool IsOutdoor
        {
            get
            {
                return _outdoortypes.Contains(HwType);
            }
        }

        /// <summary>
        /// „1” or “true”, if frequency shift is supported for this RFP
        /// </summary>
        [XmlIgnore]
        public bool HasFreqShift { get; set; }

        [XmlAttribute("hasFreqShift")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string HasFreqShiftSerialize
        {
            get { return HasFreqShift ? "1" : "0"; }
            set { HasFreqShift = value == "1"; }
        }
    }
}
