using System;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace mitelapi.Types
{
    /// <summary>
    /// This type contains all data fields of a DECT phone device. 
    /// It is used in different requests and responses. 
    /// Not all fields are used in all OMM versions and in all request and response types.
    /// </summary>
    public class PPUserType 
    {
        /// <summary>
        /// User ID, numbering starts at 1, 0 is invalid
        /// </summary>
        [XmlAttribute("uid")]
        public int Uid { get; set; } 

        /// <summary>
        /// Last change time stamp of this element in seconds since 1970/1/1. 
        /// When this element is not used in a create or set request the element is only changed when the data record differs from the record already stored in the OMM database.
        /// </summary>
        [XmlAttribute("timeStamp")]
        public long TimeStamp { get; set; }

        /// <summary>
        /// Type or state of a relationship to a DECT phone device
        /// </summary>
        [XmlAttribute("relType")]
        public PPRelTypeType RelType { get; set; }

        /// <summary>
        /// PPN of the DECT phone device which is linked to this DECT phone user, if any 
        /// </summary>
        [XmlAttribute("ppn")]
        public int Ppn { get; set; }

        /// <summary>
        /// User name
        /// </summary>
        [XmlAttribute("name")]
        public string Name { get; set; }

        /// <summary>
        /// Phone number or SIP user ID. Also used as user credential account for the server authentication 
        /// process to user configuration file on the server (when login=Number in PPLoginVariant). 
        /// </summary>
        [XmlAttribute("num")]
        public string Num { get; set; }

        /// <summary>
        /// Description hierarchy level 1, free format text. Maximal 16 UTF-8 characters. 
        /// </summary>
        [XmlAttribute("hierarchy1")]
        public string Hierarchy1 { get; set; }

        /// <summary>
        /// Description hierarchy level 2, free format text. Maximal 16 UTF-8 characters.
        /// </summary>
        [XmlAttribute("hierarchy2")]
        public string Hierarchy2 { get; set; }
        
        /// <summary>
        /// Additional ID/User Login Id, either “AdditonalId”/user pin for the subscription process or “User Login Id” for the DECT phone login process with unbound devices. 
        /// Also used as user credential account for the server authentication process to user configuration file on the server (when login=Id in PPLoginVariant). 
        /// </summary>
        [XmlAttribute("addId")]
        public string AddId { get; set; }
        
        /// <summary>
        /// PIN number, for the DECT phone 
        /// login process with unbound devices - encrypted with public key
        /// </summary>
        [XmlAttribute("pin")]
        public string Pin { get; set; }
        
        /// <summary>
        /// SIP authentication user
        /// </summary>
        [XmlAttribute("sipAuthId")]
        public string SipAuthId { get; set; }
        
        /// <summary>
        /// SIP authentication password, encrypted with public ke
        /// </summary>
        [XmlAttribute("sipPw")]
        public string SipPw { get; set; }
        
        /// <summary>
        /// SOS number
        /// </summary>
        [XmlAttribute("sosNum")]
        public string SosNum { get; set; }
        
        /// <summary>
        /// Voicebox number 
        /// </summary>
        [XmlAttribute("voiceboxNum")]
        public string VoiceboxNum { get; set; }
        
        /// <summary>
        /// MANDOWN number
        /// </summary>
        [XmlAttribute("manDownNum")]
        public string ManDownNum { get; set; }
        
        /// <summary>
        /// Call forwarding setting
        /// </summary>
        [XmlAttribute("forwardState")]
        public CallForwardStateType ForwardState { get; set; }
        
        /// <summary>
        /// Time for call forward
        /// </summary>
        [XmlAttribute("forwardTime")]
        public int ForwardTime { get; set; }
        
        /// <summary>
        /// Call forward destination
        /// </summary>
        [XmlAttribute("forwardDest")]
        public string ForwardDest { get; set; }
        
        /// <summary>
        /// User language, read only 
        /// </summary>
        [XmlAttribute("lang")]
        public PPLanguageType Lang { get; set; }
        
        /// <summary>
        /// Hold ring back time, 0 for off, time steps 1..5 
        /// </summary>
        [XmlAttribute("holdRingBackTime")]
        public int HoldRingBackTime { get; set; }
        
        /// <summary>
        /// Auto-answer setting for incoming calls.
        /// </summary>
        [XmlAttribute("autoAnswer")]
        public CallSettingType AutoAnswer { get; set; }
        
        /// <summary>
        /// Warning tone setting for incoming calls.
        /// </summary>
        [XmlAttribute("warningTone")]
        public CallSettingType WarningTone { get; set; }
        
        /// <summary>
        /// Allow barge in setting for incoming calls.
        /// </summary>
        [XmlAttribute("allowBargeIn")]
        public CallSettingType AllowBargeIn { get; set; }
        
        /// <summary>
        /// Determines whether call waiting is disabled
        /// </summary>
        [XmlAttribute("callWaitingDisabled")]
        public bool callWaitingDisabled { get; set; }
        
        /// <summary>
        /// Determines whether this data set comes from an external server 
        /// </summary>
        [XmlAttribute("external")]
        public bool External { get; set; }
        
        /// <summary>
        /// Determines whether the location of this user is being tracked 
        /// </summary>
        [XmlAttribute("trackingActive")]
        public bool TrackingActive { get; set; }
        
        /// <summary>
        /// Determines whether the position of this user may be locatable and trackable
        /// </summary>
        [XmlAttribute("locatable")]
        public bool Locatable { get; set; }
        
        /// <summary>
        /// Determines whether the position of this user may be locatable and trackable by a Bluetooth beacon
        /// </summary>
        [XmlAttribute("BTlocatable")]
        public bool BTlocatable { get; set; }  
        
        /// <summary>
        /// Bluetooth module sensitivity. One of “low”, “medium” or “high”
        /// </summary>
        [XmlAttribute("BTsensitivity")]
        public string BTsensitivity { get; set; } 
        
        /// <summary>
        /// Determines whether this user may locate other users which are locatable
        /// </summary>
        [XmlAttribute("locRight")]
        public bool LocRight { get; set; } 
        
        /// <summary>
        /// Determines whether this user may send messages. Default setting is “1”
        /// </summary>
        [XmlAttribute("msgRight")]
        public bool MsgRight { get; set; }
        
        /// <summary>
        /// Determines whether this user has the permission to send Vcard entries. Default setting is “1”
        /// </summary>
        [XmlAttribute("sendVcardRight")]
        public bool SendVcardRight { get; set; }
        
        /// <summary>
        /// Determines whether this user has the permission to receive Vcard entries
        /// </summary>
        [XmlAttribute("recvVcardRight")]
        public bool RecvVcardRight { get; set; }   
        
        /// <summary>
        /// Determines whether this user may keep the phonebook in the DECT phone after a user logout.
        /// </summary>
        [XmlAttribute("keepLocalPB")]
        public bool KeepLocalPB { get; set; } 
        
        /// <summary>
        /// Determines whether this user is priorisized with its SIP registration
        /// </summary>
        [XmlAttribute("vip")]
        public bool Vip { get; set; } 
        
        /// <summary>
        /// Determines whether this user is used for the PBX SIP register check. 
        /// Note: Only one user in the system can be set for this register check. 
        /// Setting this attribute to “false” results to the default setting (the user with the lowest num will automatically set this attribute to true). 
        /// Setting this attribute to “true” results to setting this attribute to “false” for the user having this attribute set. 
        /// </summary>
        [XmlAttribute("sipRegisterCheck")]
        public bool SipRegisterCheck { get; set; } 
        
        /// <summary>
        /// Determines whether this user is is allowed to use video streaming of video devices
        /// </summary>
        [XmlAttribute("allowVideoStream")]
        public bool AllowVideoStream { get; set; }  
                
        /// <summary>
        /// Type of the user specific conference server. One of “None”, “External”, “Integrated”, “ExternalBlindTransfer” or “Global”. 
        /// </summary>
        [XmlAttribute("conferenceServerType")]
        public string ConferenceServerType { get; set; }   
        
        /// <summary>
        /// URI for the user specific conference server. 
        /// </summary>
        [XmlAttribute("conferenceServerURI")]
        public string ConferenceServerURI { get; set; }   
        
        /// <summary>
        /// User monitoring state one of “Off”, “Passive” or Aktive”
        /// </summary>
        [XmlAttribute("monitoringMode")]
        public string MonitoringMode { get; set; }      
        
        /// <summary>
        /// Current combined user monitoring state (CUS) of all User monitoring states. Cannot be set.
        /// </summary>
        [XmlAttribute("CUS")]
        public MonitoringStateType CUS { get; set; }  
              
        /// <summary>
        /// Current user monitoring state of the DECT phone assignment status (HAS). Cannot be set. 
        /// </summary>
        [XmlAttribute("HAS")]
        public MonitoringStateType HAS { get; set; }   
              
        /// <summary>
        /// Current user monitoring state of the DECT phone subscription status (HSS). Cannot be set.
        /// </summary>
        [XmlAttribute("HSS")]
        public MonitoringStateType HSS { get; set; }  
              
        /// <summary>
        /// Current user monitoring state of the DECT phone registration status (HRS). Cannot be set.
        /// </summary>
        [XmlAttribute("HRS")]
        public MonitoringStateType HRS { get; set; }  
              
        /// <summary>
        /// Current user monitoring state of the DECT phone activity status (HCS). Cannot be set
        /// </summary>
        [XmlAttribute("HCS")]
        public MonitoringStateType HCS { get; set; }  
              
        /// <summary>
        /// Current user monitoring state of the SIP user registration status (SRS). Cannot be set.
        /// </summary>
        [XmlAttribute("SRS")]
        public MonitoringStateType SRS { get; set; }  
              
        /// <summary>
        /// Current user monitoring state of the silent charging status (SCS). Cannot be set.
        /// </summary>
        [XmlAttribute("SCS")]
        public MonitoringStateType SCS { get; set; }   
              
        /// <summary>
        /// Current user monitoring state of the Call delivery status (CDS). Cannot be set.
        /// </summary>
        [XmlAttribute("CDS")]
        public MonitoringStateType CDS { get; set; }   
              
        /// <summary>
        /// Current user monitoring state of the DECT phone DECT phone battery status (HBS). Cannot be set. 
        /// </summary>
        [XmlAttribute("HBS")]
        public MonitoringStateType HBS { get; set; }   
              
        /// <summary>
        /// Current user monitoring state of the  DECT phone Bluetooth status (BTS). Cannot be set.
        /// </summary>
        [XmlAttribute("BTS")]
        public MonitoringStateType BTS { get; set; }     
              
        /// <summary>
        /// Current user monitoring state of the  DECT phone software status (SWS). Cannot be set.
        /// </summary>
        [XmlAttribute("SWS")]
        public MonitoringStateType SWS { get; set; }    
              
        /// <summary>
        /// User credential password for user authentication to get the user configuration file from the external server - encrypted with public key.
        /// This value is used when the access to the user data server requires user credentials, see Set/Get/EventUserDataServer(Cnf). This value is normaly set at  DECT phone during login. 
        /// </summary>
        [XmlAttribute("credentialPw")]
        public string CredentialPw { get; set; }  
        
        /// <summary>
        /// Determines whether DECT phone user configuration data (DECT phone profile or user specific configuration data) for this user has been downloaded successfully to the  DECT phone. This value is read only.
        /// </summary>
        [XmlAttribute("configurationDataLoaded")]
        public bool ConfigurationDataLoaded { get; set; }     
              
        /// <summary>
        /// Configuration data to be downloaded to the DECT phone for this user. 
        /// The data consists of a sequence of lines containing one setting per line. 
        /// E. g.:
        ///     # display-einstellungen
        ///     UD_DispLanguage=en
        ///     UD_DispFont=large
        ///     UD_DispColor=black
        ///     # ringer-einstellungen
        ///     UD_RingerVolumeIntern=level-1
        /// Maximal size is 4 kByte. 
        /// Note: Before loading the DECT phone profile data into the  DECT phone the DECT phone configuration data are merged. 
        /// First the DECT phone default configuration data are used second the DECT phone profile data of this id are used and finally the user individual DECT phone configuration data.
        /// </summary>
        [XmlAttribute("ppData")]
        public string PpData { get; set; }
              
        /// <summary>
        /// Id of the DECT phone profile to be loaded into the  DECT phone for this user. 
        /// If this value is 0, no profile has to be loaded into the  DECT phone. 
        /// Note: Before loading the DECT phone profile data into the  DECT phone the DECT phone configuration data are merged.
        /// First the DECT phone default configuration data are used second the DECT phone profile data of this id are used and finally the user individual DECT phone configuration data. 
        /// </summary>
        [XmlAttribute("ppProfileId")]
        public int PpProfileId { get; set; }
              
        /// <summary>
        /// Explicitly used SIP port for registering the user at the call server. If fixedSipPort=0, no specific port is used for this user and the calculatedSipPort is used. 
        /// </summary>
        [XmlAttribute("fixedSipPort")]
        public int FixedSipPort { get; set; }
              
        /// <summary>
        /// Calculated SIP port for registering the user at the call server. If calculatedSipPort=0, the fixedSipPort is used. This value is read only.
        /// </summary>
        [XmlAttribute("calculatedSipPort")]
        public int CalculatedSipPort { get; set; }

        private static byte[] StringToByteArray(string hex)
        {
            byte[] bytes = new byte[hex.Length / 2];
            for (int i = 0; i < hex.Length; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        public static string EncryptData(string modulus, string exponent, string data)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.ImportParameters(new RSAParameters()
            {
                Modulus = StringToByteArray(modulus),
                Exponent = StringToByteArray(exponent)
            });
            var crypted = rsa.Encrypt(Encoding.ASCII.GetBytes(data), false);
            return Convert.ToBase64String(crypted);
        }
    }
}