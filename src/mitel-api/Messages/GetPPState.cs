using System.ComponentModel;
using System.Xml.Serialization;
using mitelapi.Types;

namespace mitelapi.Messages
{
    public class GetPPState : BaseRequest
    {
        /// <summary>
        /// Portable part number being requested.
        /// </summary>
        [XmlAttribute("ppn")]
        public int Ppn { get; set; }
    }

    public class GetPPStateResp : BaseResponse
    {
        /// <summary>
        /// Portable part number being requested.
        /// </summary>
        [XmlAttribute("ppn")]
        public int Ppn { get; set; }

        /// <summary>
        /// true if this DECT phone is in onHook state.
        /// </summary>
        [XmlAttribute("onHook")]
        public bool OnHook { get; set; }

        /// <summary>
        /// true if this DECT phone is in silent charging state.
        /// </summary>
        [XmlAttribute("silentCharging")]
        public bool SilentCharging { get; set; }

        /// <summary>
        /// Current call state info of the user of this DECT phone
        /// </summary>
        [XmlAttribute("callState")]
        public PPUserCallStateType CallState { get; set; }

        /// <summary>
        /// Current percentage value (0 – 100%) of the DECT phones battery state.
        /// Missing, when the DECT phones battery state is unknown or cannot be detected.
        /// </summary>
        [XmlIgnore]
        public int? BatteryLevel
        {
            get { return XmlBatteryLevelSpecified ? (int?)XmlBatteryLevel : null; }
            set
            {
                XmlBatteryLevelSpecified = value.HasValue;
                XmlBatteryLevel = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("batteryLevel")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int XmlBatteryLevel { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlBatteryLevelSpecified { get; set; }

        /// <summary>
        /// true if this DECT phone is in Bluetooth operational mode.
        /// </summary>
        [XmlIgnore]
        public bool? Bluetooth
        {
            get { return XmlBluetoothSpecified ? (bool?)XmlBluetooth : null; }
            set
            {
                XmlBluetoothSpecified = value.HasValue;
                XmlBluetooth = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("bluetooth")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlBluetooth { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlBluetoothSpecified { get; set; }

        /// <summary>
        /// Current DECT phones software version.
        /// </summary>
        [XmlAttribute("swVersion")]
        public string SwVersion { get; set; }

        /// <summary>
        /// true if this DECT phone is in Bluetooth operational mode.
        /// </summary>
        [XmlIgnore]
        public bool? Registered
        {
            get { return XmlRegisteredSpecified ? (bool?)XmlRegistered : null; }
            set
            {
                XmlRegisteredSpecified = value.HasValue;
                XmlRegistered = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("registered")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlRegistered { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlRegisteredSpecified { get; set; }

        /// <summary>
        /// Used SIP registrar server the user is registered. One of “None”, “Primary”, “Secondary” or “Tertiary”.
        /// Only contained, if a user is assigned to this DECT phone.
        /// </summary>
        [XmlAttribute("regServerType")]
        public string RegServerType { get; set; }

        /// <summary>
        /// Used SIP registrar server address the user is registered.
        /// Only contained, if a user is assigned to this DECT phone.
        /// </summary>
        [XmlAttribute("regServerAddr")]
        public string RegServerAddr { get; set; }

        /// <summary>
        /// Used SIP registrar server port the user is registered.
        /// Only contained, if a user is assigned to this DECT phone.
        /// </summary>
        [XmlIgnore]
        public int? RegServerPort
        {
            get { return XmlRegServerPortSpecified ? (int?)XmlRegServerPort : null; }
            set
            {
                XmlRegServerPortSpecified = value.HasValue;
                XmlRegServerPort = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("regServerPort")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int XmlRegServerPort { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlRegServerPortSpecified { get; set; }
    }
}