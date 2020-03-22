using System.ComponentModel;
using System.Xml.Serialization;
using mitelapi.Types;

namespace mitelapi.Events
{
    /// <summary>
    /// This event is sent by OM AXI telephony state of a DECT phone has changed.
    /// To get this event the client has to subscribe to one of PPState, PPDevState, PPCallState, PPBtState,
    /// PPSipState, PPCallStateCalling, PPCallStatePaging, PPCallStateConnected, PPCallStateIdle, PPCallStateNone,
    /// PPDevStateOnHook, PPDevStateSilentCharging, PPDevStateBatteryLevel, PPDevStateSwVersion,
    /// PPSipStateRegEvent, PPSipStateEndEvent, PPSipStateNotifyEvent, PPSipStateRegistered,
    /// PPSipStateServerType, PPSipStateServerAddr, PPSipStateServerPort or PPDevStateCharging.
    /// This is allowed if the client has at least one of the following permissions: Monitoring.
    /// When a client wants to stay updated about the telephony state of a DECT phone, it can subscribe to notifications of type PPCallState for one or more DECT phones.
    /// Each time one of these DECT phones changes its state (depending on the current subscription and DECT phone state change), an event of this type is sent by OM AXI.
    /// </summary>
    public class EventPPState : BaseEvent
    {
        /// <summary>
        /// PPN being monitored
        /// </summary>
        [XmlAttribute("ppn")]
        public int Ppn { get; set; }


        /// <summary>
        /// „1” or “true”, if this DECT phone is in onHook state
        /// </summary>
        [XmlIgnore]
        public bool? OnHook
        {
            get { return XmlOnHookSpecified ? (bool?) XmlOnHook : null; }
            set
            {
                XmlOnHookSpecified = value.HasValue;
                XmlOnHook = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("onHook")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlOnHook { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlOnHookSpecified { get; set; }


        /// <summary>
        /// „1” or “true”, if this DECT phone is in silent charging state
        /// </summary>
        [XmlIgnore]
        public bool? SilentCharging
        {
            get { return XmlSilentChargingSpecified ? (bool?) XmlSilentCharging : null; }
            set
            {
                XmlSilentChargingSpecified = value.HasValue;
                XmlSilentCharging = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("silentCharging")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlSilentCharging { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlSilentChargingSpecified { get; set; }

        /// <summary>
        /// Current percentage value (0 – 100%) of the DECT phones battery state
        /// The value will only be sent when user monitoring is activated for the user of this DECT phone device.
        /// </summary>
        [XmlIgnore]
        public int? BatteryLevel
        {
            get { return XmlBatteryLevelSpecified ? (int?) XmlBatteryLevel : null; }
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
        /// Current DECT phones software version.
        /// </summary>
        [XmlAttribute("swVersion")]
        public string SwVersion { get; set; }

        /// <summary>
        /// Current call state info of the user of this DECT phone
        /// </summary>
        [XmlAttribute("callState")]
        public PPUserCallStateType CallState { get; set; }


        /// <summary>
        /// New SIP event info for the user of this DECT phone
        /// </summary>
        [XmlIgnore]
        public PPUserSIPEventType? SipEvent
        {
            get { return XmlSipEventSpecified ? (PPUserSIPEventType?)XmlSipEvent : null; }
            set
            {
                XmlSipEventSpecified = value.HasValue;
                XmlSipEvent = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("sipEvent")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PPUserSIPEventType XmlSipEvent { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlSipEventSpecified { get; set; }


        /// <summary>
        /// „1” or “true”, if this DECT phone has successfully performed a SIP registration.
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
        /// </summary>
        [XmlAttribute("regServerType")]
        public string RegServerType { get; set; }

        /// <summary>
        /// Used SIP registrar server address the user is registered.
        /// </summary>
        [XmlAttribute("regServerAddr")]
        public string RegServerAddr { get; set; }


        /// <summary>
        /// Used SIP registrar server port the user is registered.
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


        /// <summary>
        /// „1” or “true”, if this DECT phone is connected to USB else “0” or “false”.
        /// </summary>
        [XmlIgnore]
        public bool? IsUsbConnected
        {
            get { return XmlIsUsbConnectedSpecified ? (bool?)XmlIsUsbConnected : null; }
            set
            {
                XmlIsUsbConnectedSpecified = value.HasValue;
                XmlIsUsbConnected = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("isUsbConnected")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlIsUsbConnected { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlIsUsbConnectedSpecified { get; set; }


        /// <summary>
        /// „1” or “true”, if this DECT phone is beeing charged else “0” or “false”.
        /// </summary>
        [XmlIgnore]
        public bool? IsInCharger
        {
            get { return XmlIsInChargerSpecified ? (bool?)XmlIsInCharger : null; }
            set
            {
                XmlIsInChargerSpecified = value.HasValue;
                XmlIsInCharger = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("isInCharger")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlIsInCharger { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlIsInChargerSpecified { get; set; }
    }
}