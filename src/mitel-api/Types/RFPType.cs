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
        [XmlIgnore]
        public int? Id
        {
            get { return XmlIdSpecified ? (int?)XmlId : null; }
            set
            {
                XmlIdSpecified = value.HasValue;
                XmlId = value.GetValueOrDefault();
            }
        }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlIdSpecified { get; set; }

        [XmlAttribute("id")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int XmlId { get; set; }

        /// <summary>
        /// Ethernet address, format "00:11:22:aa:bb:cc"
        /// </summary>
        [XmlAttribute("ethAddr")]
        public string EthAddr { get; set; }

        /// <summary>
        /// „1” or “true”, if DECT is enabled on this RFP
        /// </summary>
        [XmlIgnore]
        public bool? DectOn
        {
            get { return XmlDectOnSpecified ? (bool?)(XmlDectOn == "true"): null; }
            set
            {
                XmlDectOnSpecified = value.HasValue;
                XmlDectOn = value.GetValueOrDefault() ? "true" : "false";
            }
        }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlDectOnSpecified { get; set; }

        [XmlAttribute("dectOn")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string XmlDectOn { get; set; }

        /// <summary>
        /// „1” or “true”, if WLAN is enabled on this RFP
        /// </summary>
        [XmlIgnore]
        public bool? WlanOn
        {
            get { return XmlWlanOnSpecified ? (bool?)(XmlWlanOn == "true") : null; }
            set
            {
                XmlWlanOnSpecified = value.HasValue;
                XmlWlanOn = value.GetValueOrDefault() ? "true" : "false";
            }
        }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlWlanOnSpecified { get; set; }

        [XmlAttribute("wlanOn")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string XmlWlanOn { get; set; }

        /// <summary>
        /// This RFP is used for licensing, it cannot be deleted
        /// </summary>
        [XmlIgnore]
        public bool? LicenseRFP
        {
            get { return XmlLicenseRFPSpecified ? (bool?)(XmlLicenseRFP == "true") : null; }
            set
            {
                XmlLicenseRFPSpecified = value.HasValue;
                XmlLicenseRFP = value.GetValueOrDefault() ? "true" : "false";
            }
        }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlLicenseRFPSpecified { get; set; }

        [XmlAttribute("licenseRfp")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string XmlLicenseRFP { get; set; }

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
        [XmlIgnore]
        public int? Rpn
        {
            get { return XmlRpnSpecified ? (int?)XmlRpn : null; }
            set
            {
                XmlRpnSpecified = value.HasValue;
                XmlRpn = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("rpn")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int XmlRpn { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlRpnSpecified { get; set; }

        /// <summary>
        /// Paging area number, -1 for unassigned
        /// </summary>
        [XmlIgnore]
        public int? PagingArea
        {
            get { return XmlPagingAreaSpecified ? (int?)XmlPagingArea : null; }
            set
            {
                XmlPagingAreaSpecified = value.HasValue;
                XmlPagingArea = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("pagingArea")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int XmlPagingArea { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlPagingAreaSpecified { get; set; }

        /// <summary>
        /// Synchronization cluster, 0 is invalid
        /// </summary>
        [XmlIgnore]
        public int? Cluster
        {
            get { return XmlClusterSpecified ? (int?)XmlCluster : null; }
            set
            {
                XmlClusterSpecified = value.HasValue;
                XmlCluster = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("cluster")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int XmlCluster { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlClusterSpecified { get; set; }

        /// <summary>
        /// This RFP is preferred in sync start up
        /// </summary>
        [XmlIgnore]
        public bool? PreferredSync
        {
            get { return XmlPreferredSyncSpecified ? (bool?)(XmlPreferredSync == "true") : null; }
            set
            {
                XmlPreferredSyncSpecified = value.HasValue;
                XmlPreferredSync = value.GetValueOrDefault() ? "true" : "false";
            }
        }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlPreferredSyncSpecified { get; set; }

        [XmlAttribute("preferredSync")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string XmlPreferredSync { get; set; }

        /// <summary>
        /// This RFP is located in a reflective environment
        /// </summary>
        [XmlIgnore]
        public bool? ReflectiveEnv
        {
            get { return XmlReflectiveEnvSpecified ? (bool?)(XmlReflectiveEnv == "true") : null; }
            set
            {
                XmlReflectiveEnvSpecified = value.HasValue;
                XmlReflectiveEnv = value.GetValueOrDefault() ? "true" : "false";
            }
        }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlReflectiveEnvSpecified { get; set; }

        [XmlAttribute("reflectiveEnv")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string XmlReflectiveEnv { get; set; }

        /// <summary>
        /// Reference to site data set id.
        /// </summary>
        [XmlIgnore]
        public int? Site
        {
            get { return XmlSiteSpecified ? (int?)XmlSite : null; }
            set
            {
                XmlSiteSpecified = value.HasValue;
                XmlSite = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("site")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int XmlSite { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlSiteSpecified { get; set; }

        /// <summary>
        /// X coordinate for visualization
        /// </summary>
        [XmlIgnore]
        public int? X
        {
            get { return XmlXSpecified ? (int?)XmlX : null; }
            set
            {
                XmlXSpecified = value.HasValue;
                XmlX = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("x")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int XmlX { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlXSpecified { get; set; }

        /// <summary>
        /// Y coordinate for visualization
        /// </summary>
        [XmlIgnore]
        public int? Y
        {
            get { return XmlYSpecified ? (int?)XmlY : null; }
            set
            {
                XmlYSpecified = value.HasValue;
                XmlY = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("y")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int XmlY { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlYSpecified { get; set; }

        /// <summary>
        /// Type of hardware for this RFP
        /// </summary>
        [XmlIgnore]
        public RFPHwTypeType? HwType
        {
            get { return XmlHwTypeSpecified ? (RFPHwTypeType?)XmlHwType : null; }
            set
            {
                XmlHwTypeSpecified = value.HasValue;
                XmlHwType = value.GetValueOrDefault();
            }
        }
        [XmlAttribute("hwType")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RFPHwTypeType XmlHwType { get; set; }
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlHwTypeSpecified { get; set; }

        /// <summary>
        /// Read only value to indicate the possibility to configure the hwType.
        /// Until the RFP did not connect ever to the OMM the value is false
        /// and hwType can be configured.The value never changes from true
        /// to false!
        /// </summary>
        [XmlIgnore]
        public bool? HwTypeLocked
        {
            get { return XmlHwTypeLockedSpecified ? (bool?)(XmlHwTypeLocked == "true") : null; }
            set
            {
                XmlHwTypeLockedSpecified = value.HasValue;
                XmlHwTypeLocked = value.GetValueOrDefault() ? "true" : "false";
            }
        }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlHwTypeLockedSpecified { get; set; }

        [XmlAttribute("hwTypeLocked")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string XmlHwTypeLocked { get; set; }

        /// <summary>
        /// WLAN profile 0 is invalid
        /// </summary>
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? WlanProfile
        {
            get { return XmlWlanProfileSpecified ? (int?)XmlWlanProfile : null; }
            set
            {
                XmlWlanProfileSpecified = value.HasValue;
                XmlWlanProfile = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("wlanProfile")]
        public int XmlWlanProfile { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlWlanProfileSpecified { get; set; }

        /// <summary>
        /// „1” or “true”, if WLAN antenna diversity is set
        /// </summary>
        [XmlIgnore]
        public bool? WlanAntennaDiv
        {
            get { return XmlWlanAntennaDivSpecified ? (bool?)(XmlWlanAntennaDiv == "true") : null; }
            set
            {
                XmlWlanAntennaDivSpecified = value.HasValue;
                XmlWlanAntennaDiv = value.GetValueOrDefault() ? "true" : "false";
            }
        }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlWlanAntennaDivSpecified { get; set; }

        [XmlAttribute("wlanAntennaDiv")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string XmlWlanAntennaDiv { get; set; }

        /// <summary>
        /// Selected WLAN antenna, 1 or 2
        /// </summary>
        [XmlIgnore]
        public int? WlanAntenna
        {
            get { return XmlWlanAntennaSpecified ? (int?)XmlWlanAntenna : null; }
            set
            {
                XmlWlanAntennaSpecified = value.HasValue;
                XmlWlanAntenna = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("wlanAntenna")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int XmlWlanAntenna { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlWlanAntennaSpecified { get; set; }

        /// <summary>
        /// Configured WLAN channel, one of 1 to 14, 36, 40, 44, 48, 52, 56,
        /// 60, 64, 100, 104, 108, 112, 116, 120, 124, 128, 132, 136, 140, 147,        /// 151, 155, 159, 163, 167, 171
        /// </summary>
        [XmlIgnore]
        public int? WlanChannel
        {
            get { return XmlWlanChannelSpecified ? (int?)XmlWlanChannel : null; }
            set
            {
                XmlWlanChannelSpecified = value.HasValue;
                XmlWlanChannel = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("wlanChannel")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int XmlWlanChannel { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlWlanChannelSpecified { get; set; }

        /// <summary>
        /// "1” or “true”, if WLAN high throughput mode 40 is set
        /// </summary>
        [XmlIgnore]
        public bool? WlanHighThroughput
        {
            get { return XmlWlanHighThroughputSpecified ? (bool?)(XmlWlanHighThroughput == "true") : null; }
            set
            {
                XmlWlanHighThroughputSpecified = value.HasValue;
                XmlWlanHighThroughput = value.GetValueOrDefault() ? "true" : "false";
            }
        }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlWlanHighThroughputSpecified { get; set; }

        [XmlAttribute("wlanHighThroughput")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string XmlWlanHighThroughput { get; set; }

        /// <summary>
        /// Cofigured WLAN transmit power in percent, one of 6, 12, 25, 50, 100.
        /// </summary>
        [XmlIgnore]
        public int? WlanPower
        {
            get { return XmlWlanPowerSpecified ? (int?)XmlWlanPower : null; }
            set
            {
                XmlWlanPowerSpecified = value.HasValue;
                XmlWlanPower = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("wlanPower")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int XmlWlanPower { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlWlanPowerSpecified { get; set; }

        /// <summary>
        /// „1” or “true”, if this RFP can be used for conference cahnnels
        /// </summary>
        [XmlIgnore]
        public bool? ConferenceChannels
        {
            get { return XmlConferenceChannelsSpecified ? (bool?)(XmlConferenceChannels == "true") : null; }
            set
            {
                XmlConferenceChannelsSpecified = value.HasValue;
                XmlConferenceChannels = value.GetValueOrDefault() ? "true" : "false";
            }
        }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlConferenceChannelsSpecified { get; set; }

        [XmlAttribute("conferenceChannels")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string XmlConferenceChannels { get; set; }

        // The following attributes are transient (selected with withState in Requests):

        /// <summary>
        /// „1” or “true”, if this RFP is connected, transient
        /// </summary>
        [XmlIgnore]
        public bool? Connected
        {
            get { return XmlConnectedSpecified ? (bool?)(XmlConnected == "true") : null; }
            set
            {
                XmlConnectedSpecified = value.HasValue;
                XmlConnected = value.GetValueOrDefault() ? "true" : "false";
            }
        }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlConnectedSpecified { get; set; }

        [XmlAttribute("connected")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string XmlConnected { get; set; }

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
        public bool? NewSoftwareRequest
        {
            get { return XmlNewSoftwareRequestSpecified ? (bool?)(XmlNewSoftwareRequest == "true") : null; }
            set
            {
                XmlNewSoftwareRequestSpecified = value.HasValue;
                XmlNewSoftwareRequest = value.GetValueOrDefault() ? "true" : "false";
            }
        }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlNewSoftwareRequestSpecified { get; set; }

        [XmlAttribute("newSoftwareRequest")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string XmlNewSoftwareRequest { get; set; }

        /// <summary>
        /// 1” or “true”, if the DECT is running on this RFP., transient
        /// </summary>
        [XmlIgnore]
        public bool? DectRunning
        {
            get { return XmlDectRunningSpecified ? (bool?)(XmlDectRunning == "true") : null; }
            set
            {
                XmlDectRunningSpecified = value.HasValue;
                XmlDectRunning = value.GetValueOrDefault() ? "true" : "false";
            }
        }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlDectRunningSpecified { get; set; }

        [XmlAttribute("dectRunning")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string XmlDectRunning { get; set; }

        /// <summary>
        /// „1” or “true”, if the WLAN is running on this RFP, transient
        /// </summary>
        [XmlIgnore]
        public bool? WlanRunning
        {
            get { return XmlWlanRunningSpecified ? (bool?)(XmlWlanRunning == "true") : null; }
            set
            {
                XmlWlanRunningSpecified = value.HasValue;
                XmlWlanRunning = value.GetValueOrDefault() ? "true" : "false";
            }
        }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlWlanRunningSpecified { get; set; }

        [XmlAttribute("wlanRunning")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string XmlWlanRunning { get; set; }

        /// <summary>
        /// „1” or “true”, if the OMM is running on this RFP, transient
        /// </summary>
        [XmlIgnore]
        public bool? OmmRunning
        {
            get { return XmlOmmRunningSpecified ? (bool?)(XmlOmmRunning == "true") : null; }
            set
            {
                XmlOmmRunningSpecified = value.HasValue;
                XmlOmmRunning = value.GetValueOrDefault() ? "true" : "false";
            }
        }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlOmmRunningSpecified { get; set; }

        [XmlAttribute("ommRunning")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string XmlOmmRunning { get; set; }

        /// <summary>
        /// „1” or “true”, if the standby OMM is running on this RFP, transient
        /// </summary>
        [XmlIgnore]
        public bool? OmmStbRunning
        {
            get { return XmlOmmStbRunningSpecified ? (bool?)(XmlOmmStbRunning == "true") : null; }
            set
            {
                XmlOmmStbRunningSpecified = value.HasValue;
                XmlOmmStbRunning = value.GetValueOrDefault() ? "true" : "false";
            }
        }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlOmmStbRunningSpecified { get; set; }

        [XmlAttribute("ommStbRunning")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string XmlOmmStbRunning { get; set; }

        /// <summary>
        /// „1” or “true”, if WLAN is supported by this RFP hardware
        /// </summary>
        [XmlIgnore]
        public bool? HasWlan
        {
            get { return XmlHasWlanSpecified ? (bool?)(XmlHasWlan == "true") : null; }
            set
            {
                XmlHasWlanSpecified = value.HasValue;
                XmlHasWlan = value.GetValueOrDefault() ? "true" : "false";
            }
        }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlHasWlanSpecified { get; set; }

        [XmlAttribute("hasWlan")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string XmlHasWlan { get; set; }

        /// <summary>
        /// „1” or “true”, if encryption is supported by this RFP hardware
        /// These features can be configured within a site
        /// </summary>
        [XmlIgnore]
        public bool? HasEncryption
        {
            get { return XmlHasEncryptionSpecified ? (bool?)(XmlHasEncryption == "true") : null; }
            set
            {
                XmlHasEncryptionSpecified = value.HasValue;
                XmlHasEncryption = value.GetValueOrDefault() ? "true" : "false";
            }
        }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlHasEncryptionSpecified { get; set; }

        [XmlAttribute("hasEncryption")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string XmlHasEncryption { get; set; }

        /// <summary>
        /// „1” or “true”, if Hi-Q audio technology (wide band) G.722, terminal
        /// video, DECT security and secure SIP are supported by this RFP
        /// hardware.
        /// These features can be configured within a site.
        /// </summary>
        [XmlIgnore]
        public bool? HasAdvancedFeatures
        {
            get { return XmlHasAdvancedFeaturesSpecified ? (bool?)(XmlHasAdvancedFeatures == "true") : null; }
            set
            {
                XmlHasAdvancedFeaturesSpecified = value.HasValue;
                XmlHasAdvancedFeatures = value.GetValueOrDefault() ? "true" : "false";
            }
        }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlHasAdvancedFeaturesSpecified { get; set; }

        [XmlAttribute("hasAdvancedFeatures")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string XmlHasAdvancedFeatures { get; set; }

        /// <summary>
        /// Current DECT synchronization state for this RFP.
        /// </summary>
        [XmlIgnore]
        public RFPSyncStateType? SyncState
        {
            get { return XmlSyncStateSpecified ? (RFPSyncStateType?)XmlSyncState : null; }
            set
            {
                XmlSyncStateSpecified = value.HasValue;
                XmlSyncState = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("syncState")]
        public RFPSyncStateType XmlSyncState;

        [XmlIgnore]
        public bool XmlSyncStateSpecified;

        /// <summary>
        /// Current software version on this RFP in the format:
        /// &lt;majorRelease&gt;.&lt;minorRelease&gt;.{RC x | SP y | &lt;bugfixVersion&gt;}
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
        public bool? BrandingMismatch
        {
            get { return XmlBrandingMismatchSpecified ? (bool?)(XmlBrandingMismatch == "true") : null; }
            set
            {
                XmlBrandingMismatchSpecified = value.HasValue;
                XmlBrandingMismatch = value.GetValueOrDefault() ? "true" : "false";
            }
        }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlBrandingMismatchSpecified { get; set; }

        [XmlAttribute("brandingMismatch")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string XmlBrandingMismatch { get; set; }

        /// <summary>
        /// „1” or “true”, if software version of this RFP and OMM do not fit
        /// together
        /// </summary>
        [XmlIgnore]
        public bool? VersionMismatch
        {
            get { return XmlVersionMismatchSpecified ? (bool?)(XmlVersionMismatch == "true") : null; }
            set
            {
                XmlVersionMismatchSpecified = value.HasValue;
                XmlVersionMismatch = value.GetValueOrDefault() ? "true" : "false";
            }
        }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlVersionMismatchSpecified { get; set; }

        [XmlAttribute("versionMismatch")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string XmlVersionMismatch { get; set; }

        /// <summary>
        /// „1” or “true”, if this RFP has an invalid OMM standby
        /// configuration.
        /// </summary>
        [XmlIgnore]
        public bool? StbMismatch
        {
            get { return XmlStbMismatchSpecified ? (bool?)(XmlStbMismatch == "true") : null; }
            set
            {
                XmlStbMismatchSpecified = value.HasValue;
                XmlStbMismatch = value.GetValueOrDefault() ? "true" : "false";
            }
        }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlStbMismatchSpecified { get; set; }

        [XmlAttribute("stbMismatch")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string XmlStbMismatch { get; set; }

        /// <summary>
        /// „1” or “true”, if the Ethernet link is too slow ( e. g. only 10 MBit/s)
        /// to enable WLAN on this RFP
        /// </summary>
        [XmlIgnore]
        public bool? WlanLinkNok
        {
            get { return XmlWlanLinkNokSpecified ? (bool?)(XmlWlanLinkNok == "true") : null; }
            set
            {
                XmlWlanLinkNokSpecified = value.HasValue;
                XmlWlanLinkNok = value.GetValueOrDefault() ? "true" : "false";
            }
        }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlWlanLinkNokSpecified { get; set; }

        [XmlAttribute("wlanLinkNok")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string XmlWlanLinkNok { get; set; }

        /// <summary>
        /// Used Channel one of 1 to 14, 36, 40, 44, 48, 52, 56, 60, 64, 100,
        /// 104, 108, 112, 116, 120, 124, 128, 132, 136, 140, 147, 151, 155,
        /// 159, 163, 167, 171.
        /// This value is read only.
        /// </summary>
        [XmlIgnore]
        public int? WlanChannelUsed
        {
            get { return XmlWlanChannelUsedSpecified ? (int?)XmlWlanChannelUsed : null; }
            set
            {
                XmlWlanChannelUsedSpecified = value.HasValue;
                XmlWlanChannelUsed = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("wlanChannelUsed")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int XmlWlanChannelUsed { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlWlanChannelUsedSpecified { get; set; }

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
        [XmlIgnore]
        public int? WlanPowerUsed
        {
            get { return XmlWlanPowerUsedSpecified ? (int?)XmlWlanPowerUsed : null; }
            set
            {
                XmlWlanPowerUsedSpecified = value.HasValue;
                XmlWlanPowerUsed = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("wlanPowerUsed")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int XmlWlanPowerUsed { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlWlanPowerUsedSpecified { get; set; }

        /// <summary>
        /// Number of DECT synchronization relations
        /// </summary>
        [XmlIgnore]
        public int? NSyncRels
        {
            get { return XmlNSyncRelsSpecified ? (int?)XmlNSyncRels : null; }
            set
            {
                XmlNSyncRelsSpecified = value.HasValue;
                XmlNSyncRels = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("nSyncRels")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int XmlNSyncRels { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlNSyncRelsSpecified { get; set; }

        /// <summary>
        /// The DECT radio type of this RFP
        /// </summary>
        [XmlIgnore]
        public RfpRadioTypeType? RadioType
        {
            get { return XmlRadioTypeSpecified ? (RfpRadioTypeType?)XmlRadioType : null; }
            set
            {
                XmlRadioTypeSpecified = value.HasValue;
                XmlRadioType = value.GetValueOrDefault();
            }
        }
        [XmlAttribute("radioType")]
        public RfpRadioTypeType XmlRadioType { get; set; }
        [XmlIgnore]
        public bool XmlRadioTypeSpecified { get; set; }

        /// <summary>
        /// „1” or “true”, if this is an outdoor RFP hardware
        /// </summary>
        [XmlIgnore]
        public bool? OutdoorType
        {
            get { return XmlOutdoorTypeSpecified ? (bool?)(XmlOutdoorType == "true") : null; }
            set
            {
                XmlOutdoorTypeSpecified = value.HasValue;
                XmlOutdoorType = value.GetValueOrDefault() ? "true" : "false";
            }
        }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlOutdoorTypeSpecified { get; set; }

        [XmlAttribute("outdoorType")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string XmlOutdoorType { get; set; }

        [XmlIgnore]
        public bool IsOutdoor
        {
            get
            {
                if (!HwType.HasValue) return false;
                return _outdoortypes.Contains(HwType.Value);
            }
        }

        /// <summary>
        /// „1” or “true”, if frequency shift is supported for this RFP
        /// </summary>
        [XmlIgnore]
        public bool? HasFreqShift
        {
            get { return XmlHasFreqShiftSpecified ? (bool?)(XmlHasFreqShift == "true") : null; }
            set
            {
                XmlHasFreqShiftSpecified = value.HasValue;
                XmlHasFreqShift = value.GetValueOrDefault() ? "true" : "false";
            }
        }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlHasFreqShiftSpecified { get; set; }

        [XmlAttribute("hasFreqShift")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string XmlHasFreqShift { get; set; }
    }
}
