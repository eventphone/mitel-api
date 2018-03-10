using System.ComponentModel;
using System.Xml.Serialization;
using mitelapi.Messages;

namespace mitelapi.Types
{
    /// <summary>
    /// This type contains all data fields of a DECT phone device. 
    /// It is used in different requests and responses. 
    /// Not all fields are used in all OMM versions and in all request and response types.
    /// </summary>
    public class PPDevType 
    {
        /// <summary>
        /// Portable part number, unique ID for a DECT phone devices in the OMM. PPNs start at 1, i.e. 0 is an invalid PPN.
        /// </summary>
        [XmlAttribute("ppn")]
        public int Ppn { get; set; }

        /// <summary>
        /// Last change time stamp of this element in seconds since 1970/1/1. 
        /// When this element is not used in a create or set request the element is only changed when the data record differs 
        /// from the record already stored in the OMM database.
        /// </summary>
        [XmlIgnore]
        public long? TimeStamp
        {
            get { return XmlTimeStampSpecified ? (long?)XmlTimeStamp : null; }
            set
            {
                XmlTimeStampSpecified = value.HasValue;
                XmlTimeStamp = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("timeStamp")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long XmlTimeStamp { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlTimeStampSpecified { get; set; }

        /// <summary>
        /// Type or state of a relationship to a DECT phone user
        /// </summary>
        [XmlIgnore]
        public PPRelTypeType? RelType
        {
            get { return XmlRelTypeSpecified ? (PPRelTypeType?)XmlRelType : null; }
            set
            {
                XmlRelTypeSpecified = value.HasValue;
                XmlRelType = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("relType")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PPRelTypeType XmlRelType { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlRelTypeSpecified { get; set; }

        /// <summary>
        /// User ID of the DECT phone user which is linked to this DECT phone device, if any.
        /// </summary>
        [XmlAttribute("uid")]
        public int Uid { get; set; }        

        /// <summary>
        /// IPEI, globally unique identifier for a DECT phone. 
        /// </summary>
        [XmlAttribute("ipei")]
        public string Ipei { get; set; }        

        /// <summary>
        /// Authentication code for DECT subscription
        /// </summary>
        [XmlAttribute("ac")]
        public string AuthenticationCode { get; set; }       

        /// <summary>
        /// DECT subscription state, default = "No"
        /// </summary>
        [XmlIgnore]
        public DECTSubscriptionStateType? SubscriptionState
        {
            get { return XmlSubscriptionStateSpecified ? (DECTSubscriptionStateType?)XmlSubscriptionState : null; }
            set
            {
                XmlSubscriptionStateSpecified = value.HasValue;
                XmlSubscriptionState = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("s")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DECTSubscriptionStateType XmlSubscriptionState { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlSubscriptionStateSpecified { get; set; }

        /// <summary>
        /// Encrypted UAK value
        /// </summary>
        [XmlAttribute("uak")]
        public string Uak { get; set; }       

        /// <summary>
        /// Determines whether DECT encryption is enabled
        /// </summary>
        [XmlIgnore]
        public bool? Encrypt
        {
            get { return XmlEncryptSpecified ? (bool?)XmlEncrypt : null; }
            set
            {
                XmlEncryptSpecified = value.HasValue;
                XmlEncrypt = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("encrypt")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlEncrypt { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlEncryptSpecified { get; set; }

        /// <summary>
        /// Determines whether this device is known to support messaging (read only) 
        /// </summary>
        [XmlIgnore]
        public bool? CapMessaging
        {
            get { return XmlCapMessagingSpecified ? (bool?)XmlCapMessaging : null; }
            set
            {
                XmlCapMessagingSpecified = value.HasValue;
                XmlCapMessaging = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("capMessaging")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlCapMessaging { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlCapMessagingSpecified { get; set; }

        /// <summary>
        /// Determines whether this device is known to support messaging for internal use only (read only)
        /// </summary>
        [XmlIgnore]
        public bool? CapMessagingForInternalUse
        {
            get { return XmlCapMessagingForInternalUseSpecified ? (bool?)XmlCapMessagingForInternalUse : null; }
            set
            {
                XmlCapMessagingForInternalUseSpecified = value.HasValue;
                XmlCapMessagingForInternalUse = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("capMessagingForInternalUse")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlCapMessagingForInternalUse { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlCapMessagingForInternalUseSpecified { get; set; }

        /// <summary>
        /// Determines whether this device is able to provide enhanced locating information (read only) 
        /// </summary>
        [XmlIgnore]
        public bool? CapEnhLocating
        {
            get { return XmlCapEnhLocatingSpecified ? (bool?)XmlCapEnhLocating : null; }
            set
            {
                XmlCapEnhLocatingSpecified = value.HasValue;
                XmlCapEnhLocating = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("capEnhLocating")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlCapEnhLocating { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlCapEnhLocatingSpecified { get; set; }

        /// <summary>
        /// Determines whether this device is able to use blootooth (read only). 
        /// </summary>
        [XmlIgnore]
        public bool? CapBluetooth
        {
            get { return XmlCapBluetoothSpecified ? (bool?)XmlCapBluetooth : null; }
            set
            {
                XmlCapBluetoothSpecified = value.HasValue;
                XmlCapBluetooth = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("capBluetooth")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlCapBluetooth { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlCapBluetoothSpecified { get; set; }

        /// <summary>
        /// Bluetooth ethernet address, format “00:11:22:aa:bb:cc” (read only). 
        /// An empty string means no Bluetooth equipment available at this device
        /// </summary>
        [XmlAttribute("ethAddr")]
        public string EthAddr { get; set; }

        /// <summary>
        /// Detected device type. One of “142d”, “610d”, “620d”, “630d”, “612d”, “622d”, “632d”, “650c”, “740cv”, “GAP”or “Unknown” (read only)
        /// </summary>
        [XmlIgnore]
        public HWTypeType? HwType
        {
            get { return XmlHwTypeSpecified ? (HWTypeType?)XmlHwType : null; }
            set
            {
                XmlHwTypeSpecified = value.HasValue;
                XmlHwType = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("hwType")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HWTypeType XmlHwType { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlHwTypeSpecified { get; set; }

        /// <summary>
        /// Determines whether the DECT phone is able to load DECT phone configuration data. This element is read only.
        /// </summary>
        [XmlIgnore]
        public bool? PpProfileCapability
        {
            get { return XmlPpProfileCapabilitySpecified ? (bool?)XmlPpProfileCapability : null; }
            set
            {
                XmlPpProfileCapabilitySpecified = value.HasValue;
                XmlPpProfileCapability = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("ppProfileCapability")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlPpProfileCapability { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlPpProfileCapabilitySpecified { get; set; }

        /// <summary>
        /// the DECT phone has loaded the default DECT phone configuration data set.
        /// Note: If a user has logged in to this device additional user DECT phone configuration data might have been loaded to this DECT phone.
        /// In this case the value of this element is set to “0” or “false”. This element is read only
        /// </summary>
        [XmlIgnore]
        public bool? PpDefaultProfileLoaded
        {
            get { return XmlPpDefaultProfileLoadedSpecified ? (bool?)XmlPpDefaultProfileLoaded : null; }
            set
            {
                XmlPpDefaultProfileLoadedSpecified = value.HasValue;
                XmlPpDefaultProfileLoaded = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("ppDefaultProfileLoaded")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlPpDefaultProfileLoaded { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlPpDefaultProfileLoadedSpecified { get; set; }

        /// <summary>
        /// Determines whether the DECT phone shall be subscribed only by using the PARI. 
        /// This device cannot roam to other OMMs.
        /// </summary>
        [XmlIgnore]
        public bool? SubscribeToPARIOnly
        {
            get { return XmlSubscribeToPARIOnlySpecified ? (bool?)XmlSubscribeToPARIOnly : null; }
            set
            {
                XmlSubscribeToPARIOnlySpecified = value.HasValue;
                XmlSubscribeToPARIOnly = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("subscribeToPARIOnly")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlSubscribeToPARIOnly { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlSubscribeToPARIOnlySpecified { get; set; }
    }
}