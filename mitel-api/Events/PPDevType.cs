using System.Xml.Serialization;
using mitelapi.Messages;

namespace mitelapi.Events
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
        [XmlAttribute("timeStamp")]
        public long TimeStamp { get; set; }

        /// <summary>
        /// Type or state of a relationship to a DECT phone user
        /// </summary>
        [XmlAttribute("relType")]
        public PPRelTypeType RelType { get; set; }        

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
        [XmlAttribute("s")]
        public DECTSubscriptionStateType SubscriptionState { get; set; }       

        /// <summary>
        /// Encrypted UAK value
        /// </summary>
        [XmlAttribute("uak")]
        public string Uak { get; set; }       

        /// <summary>
        /// Determines whether DECT encryption is enabled
        /// </summary>
        [XmlAttribute("encrypt")]
        public bool Encrypt { get; set; }         

        /// <summary>
        /// Determines whether this device is known to support messaging (read only) 
        /// </summary>
        [XmlAttribute("capMessaging")]
        public bool CapMessaging { get; set; }      

        /// <summary>
        /// Determines whether this device is known to support messaging for internal use only (read only)
        /// </summary>
        [XmlAttribute("capMessagingForInternalUse")]
        public bool CapMessagingForInternalUse { get; set; }

        /// <summary>
        /// Determines whether this device is able to provide enhanced locating information (read only) 
        /// </summary>
        [XmlAttribute("capEnhLocating")]
        public bool CapEnhLocating { get; set; }

        /// <summary>
        /// Determines whether this device is able to use blootooth (read only). 
        /// </summary>
        [XmlAttribute("capBluetooth")]
        public bool CapBluetooth { get; set; }

        /// <summary>
        /// Bluetooth ethernet address, format “00:11:22:aa:bb:cc” (read only). 
        /// An empty string means no Bluetooth equipment available at this device
        /// </summary>
        [XmlAttribute("ethAddr")]
        public string EthAddr { get; set; }

        /// <summary>
        /// Detected device type. One of “142d”, “610d”, “620d”, “630d”, “612d”, “622d”, “632d”, “650c”, “740cv”, “GAP”or “Unknown” (read only)
        /// </summary>
        [XmlAttribute("hwType")]
        public HWTypeType HwType { get; set; }

        /// <summary>
        /// Determines whether the DECT phone is able to load DECT phone configuration data. This element is read only.
        /// </summary>
        [XmlAttribute("ppProfileCapability")]
        public bool PpProfileCapability { get; set; }

        /// <summary>
        /// the DECT phone has loaded the default DECT phone configuration data set.
        /// Note: If a user has logged in to this device additional user DECT phone configuration data might have been loaded to this DECT phone.
        /// In this case the value of this element is set to “0” or “false”. This element is read only
        /// </summary>
        [XmlAttribute("ppDefaultProfileLoaded")]
        public bool PpDefaultProfileLoaded { get; set; }

        /// <summary>
        /// Determines whether the DECT phone shall be subscribed only by using the PARI. 
        /// This device cannot roam to other OMMs.
        /// </summary>
        [XmlAttribute("subscribeToPARIOnly")]
        public bool SubscribeToPARIOnly{ get; set; }     
    }
}