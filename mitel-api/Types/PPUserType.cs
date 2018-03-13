using System;
using System.ComponentModel;
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
        /// Type or state of a relationship to a DECT phone device
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
        [XmlIgnore]
        public CallForwardStateType? ForwardState
        {
            get { return XmlForwardStateSpecified ? (CallForwardStateType?)XmlForwardState : null; }
            set
            {
                XmlForwardStateSpecified = value.HasValue;
                XmlForwardState = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("forwardState")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CallForwardStateType XmlForwardState { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlForwardStateSpecified { get; set; }

        /// <summary>
        /// Time for call forward
        /// </summary>
        [XmlIgnore]
        public int? ForwardTime
        {
            get { return XmlForwardTimeSpecified ? (int?)XmlForwardTime : null; }
            set
            {
                XmlForwardTimeSpecified = value.HasValue;
                XmlForwardTime = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("forwardTime")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int XmlForwardTime { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlForwardTimeSpecified { get; set; }

        /// <summary>
        /// Call forward destination
        /// </summary>
        [XmlAttribute("forwardDest")]
        public string ForwardDest { get; set; }
        
        /// <summary>
        /// User language, read only 
        /// </summary>
        [XmlIgnore]
        public PPLanguageType? Lang
        {
            get { return XmlLangSpecified ? (PPLanguageType?)XmlLang : null; }
            set
            {
                XmlLangSpecified = value.HasValue;
                XmlLang = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("lang")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PPLanguageType XmlLang { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlLangSpecified { get; set; }

        /// <summary>
        /// Hold ring back time, 0 for off, time steps 1..5 
        /// </summary>
        [XmlIgnore]
        public int? HoldRingBackTime
        {
            get { return XmlHoldRingBackTimeSpecified ? (int?)XmlHoldRingBackTime : null; }
            set
            {
                XmlHoldRingBackTimeSpecified = value.HasValue;
                XmlHoldRingBackTime = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("holdRingBackTime")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int XmlHoldRingBackTime { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlHoldRingBackTimeSpecified { get; set; }

        /// <summary>
        /// Auto-answer setting for incoming calls.
        /// </summary>
        [XmlIgnore]
        public CallSettingType? AutoAnswer
        {
            get { return XmlAutoAnswerSpecified ? (CallSettingType?)XmlAutoAnswer : null; }
            set
            {
                XmlAutoAnswerSpecified = value.HasValue;
                XmlAutoAnswer = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("autoAnswer")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CallSettingType XmlAutoAnswer { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlAutoAnswerSpecified { get; set; }

        /// <summary>
        /// Warning tone setting for incoming calls.
        /// </summary>
        [XmlIgnore]
        public CallSettingType? WarningTone
        {
            get { return XmlWarningToneSpecified ? (CallSettingType?)XmlWarningTone : null; }
            set
            {
                XmlWarningToneSpecified = value.HasValue;
                XmlWarningTone = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("warningTone")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CallSettingType XmlWarningTone { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlWarningToneSpecified { get; set; }

        /// <summary>
        /// Allow barge in setting for incoming calls.
        /// </summary>
        [XmlIgnore]
        public CallSettingType? AllowBargeIn
        {
            get { return XmlAllowBargeInSpecified ? (CallSettingType?)XmlAllowBargeIn : null; }
            set
            {
                XmlAllowBargeInSpecified = value.HasValue;
                XmlAllowBargeIn = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("allowBargeIn")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CallSettingType XmlAllowBargeIn { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlAllowBargeInSpecified { get; set; }

        /// <summary>
        /// Determines whether call waiting is disabled
        /// </summary>
        [XmlIgnore]
        public bool? CallWaitingDisabled
        {
            get { return XmlCallWaitingDisabledSpecified ? (bool?)XmlCallWaitingDisabled : null; }
            set
            {
                XmlCallWaitingDisabledSpecified = value.HasValue;
                XmlCallWaitingDisabled = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("callWaitingDisabled")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlCallWaitingDisabled { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlCallWaitingDisabledSpecified { get; set; }

        /// <summary>
        /// Determines whether this data set comes from an external server 
        /// </summary>
        [XmlIgnore]
        public bool? External
        {
            get { return XmlExternalSpecified ? (bool?)XmlExternal : null; }
            set
            {
                XmlExternalSpecified = value.HasValue;
                XmlExternal = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("external")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlExternal { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlExternalSpecified { get; set; }

        /// <summary>
        /// Determines whether the location of this user is being tracked 
        /// </summary>
        [XmlIgnore]
        public bool? TrackingActive
        {
            get { return XmlTrackingActiveSpecified ? (bool?)XmlTrackingActive : null; }
            set
            {
                XmlTrackingActiveSpecified = value.HasValue;
                XmlTrackingActive = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("trackingActive")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlTrackingActive { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlTrackingActiveSpecified { get; set; }

        /// <summary>
        /// Determines whether the position of this user may be locatable and trackable
        /// </summary>
        [XmlIgnore]
        public bool? Locatable
        {
            get { return XmlLocatableSpecified ? (bool?)XmlLocatable : null; }
            set
            {
                XmlLocatableSpecified = value.HasValue;
                XmlLocatable = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("locatable")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlLocatable { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlLocatableSpecified { get; set; }

        /// <summary>
        /// Determines whether the position of this user may be locatable and trackable by a Bluetooth beacon
        /// </summary>
        [XmlIgnore]
        public bool? BTlocatable
        {
            get { return XmlBTlocatableSpecified ? (bool?)XmlBTlocatable : null; }
            set
            {
                XmlBTlocatableSpecified = value.HasValue;
                XmlBTlocatable = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("BTlocatable")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlBTlocatable { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlBTlocatableSpecified { get; set; }

        /// <summary>
        /// Bluetooth module sensitivity. One of “low”, “medium” or “high”
        /// </summary>
        [XmlAttribute("BTsensitivity")]
        public string BTsensitivity { get; set; } 
        
        /// <summary>
        /// Determines whether this user may locate other users which are locatable
        /// </summary>
        [XmlIgnore]
        public bool? LocRight
        {
            get { return XmlLocRightSpecified ? (bool?)XmlLocRight : null; }
            set
            {
                XmlLocRightSpecified = value.HasValue;
                XmlLocRight = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("locRight")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlLocRight { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlLocRightSpecified { get; set; }

        /// <summary>
        /// Determines whether this user may send messages. Default setting is “1”
        /// </summary>
        [XmlIgnore]
        public bool? MsgRight
        {
            get { return XmlMsgRightSpecified ? (bool?)XmlMsgRight : null; }
            set
            {
                XmlMsgRightSpecified = value.HasValue;
                XmlMsgRight = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("msgRight")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlMsgRight { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlMsgRightSpecified { get; set; }

        /// <summary>
        /// Determines whether this user has the permission to send Vcard entries. Default setting is “1”
        /// </summary>
        [XmlIgnore]
        public bool? SendVcardRight
        {
            get { return XmlSendVcardRightSpecified ? (bool?)XmlSendVcardRight : null; }
            set
            {
                XmlSendVcardRightSpecified = value.HasValue;
                XmlSendVcardRight = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("sendVcardRight")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlSendVcardRight { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlSendVcardRightSpecified { get; set; }

        /// <summary>
        /// Determines whether this user has the permission to receive Vcard entries
        /// </summary>
        [XmlIgnore]
        public bool? RecvVcardRight
        {
            get { return XmlRecvVcardRightSpecified ? (bool?)XmlRecvVcardRight : null; }
            set
            {
                XmlRecvVcardRightSpecified = value.HasValue;
                XmlRecvVcardRight = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("recvVcardRight")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlRecvVcardRight { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlRecvVcardRightSpecified { get; set; }

        /// <summary>
        /// Determines whether this user may keep the phonebook in the DECT phone after a user logout.
        /// </summary>
        [XmlIgnore]
        public bool? KeepLocalPB
        {
            get { return XmlKeepLocalPBSpecified ? (bool?)XmlKeepLocalPB : null; }
            set
            {
                XmlKeepLocalPBSpecified = value.HasValue;
                XmlKeepLocalPB = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("keepLocalPB")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlKeepLocalPB { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlKeepLocalPBSpecified { get; set; }

        /// <summary>
        /// Determines whether this user is priorisized with its SIP registration
        /// </summary>
        [XmlIgnore]
        public bool? Vip
        {
            get { return XmlVipSpecified ? (bool?)XmlVip : null; }
            set
            {
                XmlVipSpecified = value.HasValue;
                XmlVip = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("vip")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlVip { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlVipSpecified { get; set; }

        /// <summary>
        /// Determines whether this user is used for the PBX SIP register check. 
        /// Note: Only one user in the system can be set for this register check. 
        /// Setting this attribute to “false” results to the default setting (the user with the lowest num will automatically set this attribute to true). 
        /// Setting this attribute to “true” results to setting this attribute to “false” for the user having this attribute set. 
        /// </summary>
        [XmlIgnore]
        public bool? SipRegisterCheck
        {
            get { return XmlSipRegisterCheckSpecified ? (bool?)XmlSipRegisterCheck : null; }
            set
            {
                XmlSipRegisterCheckSpecified = value.HasValue;
                XmlSipRegisterCheck = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("sipRegisterCheck")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlSipRegisterCheck { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlSipRegisterCheckSpecified { get; set; }

        /// <summary>
        /// Determines whether this user is is allowed to use video streaming of video devices
        /// </summary>
        [XmlIgnore]
        public bool? AllowVideoStream
        {
            get { return XmlAllowVideoStreamSpecified ? (bool?)XmlAllowVideoStream : null; }
            set
            {
                XmlAllowVideoStreamSpecified = value.HasValue;
                XmlAllowVideoStream = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("allowVideoStream")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlAllowVideoStream { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlAllowVideoStreamSpecified { get; set; }

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
        [XmlIgnore]
        public MonitoringStateType? CUS
        {
            get { return XmlCUSSpecified ? (MonitoringStateType?)XmlCUS : null; }
            set
            {
                XmlCUSSpecified = value.HasValue;
                XmlCUS = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("CUS")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MonitoringStateType XmlCUS { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlCUSSpecified { get; set; }

        /// <summary>
        /// Current user monitoring state of the DECT phone assignment status (HAS). Cannot be set. 
        /// </summary>
        [XmlIgnore]
        public MonitoringStateType? HAS
        {
            get { return XmlHASSpecified ? (MonitoringStateType?)XmlHAS : null; }
            set
            {
                XmlHASSpecified = value.HasValue;
                XmlHAS = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("HAS")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MonitoringStateType XmlHAS { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlHASSpecified { get; set; }

        /// <summary>
        /// Current user monitoring state of the DECT phone subscription status (HSS). Cannot be set.
        /// </summary>
        [XmlIgnore]
        public MonitoringStateType? HSS
        {
            get { return XmlHSSSpecified ? (MonitoringStateType?)XmlHSS : null; }
            set
            {
                XmlHSSSpecified = value.HasValue;
                XmlHSS = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("HSS")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MonitoringStateType XmlHSS { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlHSSSpecified { get; set; }

        /// <summary>
        /// Current user monitoring state of the DECT phone registration status (HRS). Cannot be set.
        /// </summary>
        [XmlIgnore]
        public MonitoringStateType? HRS
        {
            get { return XmlHRSSpecified ? (MonitoringStateType?)XmlHRS : null; }
            set
            {
                XmlHRSSpecified = value.HasValue;
                XmlHRS = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("HRS")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MonitoringStateType XmlHRS { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlHRSSpecified { get; set; }

        /// <summary>
        /// Current user monitoring state of the DECT phone activity status (HCS). Cannot be set
        /// </summary>
        [XmlIgnore]
        public MonitoringStateType? HCS
        {
            get { return XmlHCSSpecified ? (MonitoringStateType?)XmlHCS : null; }
            set
            {
                XmlHCSSpecified = value.HasValue;
                XmlHCS = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("HCS")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MonitoringStateType XmlHCS { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlHCSSpecified { get; set; }

        /// <summary>
        /// Current user monitoring state of the SIP user registration status (SRS). Cannot be set.
        /// </summary>
        [XmlIgnore]
        public MonitoringStateType? SRS
        {
            get { return XmlSRSSpecified ? (MonitoringStateType?)XmlSRS : null; }
            set
            {
                XmlSRSSpecified = value.HasValue;
                XmlSRS = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("SRS")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MonitoringStateType XmlSRS { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlSRSSpecified { get; set; }

        /// <summary>
        /// Current user monitoring state of the silent charging status (SCS). Cannot be set.
        /// </summary>
        [XmlIgnore]
        public MonitoringStateType? SCS
        {
            get { return XmlSCSSpecified ? (MonitoringStateType?)XmlSCS : null; }
            set
            {
                XmlSCSSpecified = value.HasValue;
                XmlSCS = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("SCS")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MonitoringStateType XmlSCS { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlSCSSpecified { get; set; }

        /// <summary>
        /// Current user monitoring state of the Call delivery status (CDS). Cannot be set.
        /// </summary>
        [XmlIgnore]
        public MonitoringStateType? CDS
        {
            get { return XmlCDSSpecified ? (MonitoringStateType?)XmlCDS : null; }
            set
            {
                XmlCDSSpecified = value.HasValue;
                XmlCDS = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("CDS")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MonitoringStateType XmlCDS { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlCDSSpecified { get; set; }

        /// <summary>
        /// Current user monitoring state of the DECT phone DECT phone battery status (HBS). Cannot be set. 
        /// </summary>
        [XmlIgnore]
        public MonitoringStateType? HBS
        {
            get { return XmlHBSSpecified ? (MonitoringStateType?)XmlHBS : null; }
            set
            {
                XmlHBSSpecified = value.HasValue;
                XmlHBS = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("HBS")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MonitoringStateType XmlHBS { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlHBSSpecified { get; set; }

        /// <summary>
        /// Current user monitoring state of the  DECT phone Bluetooth status (BTS). Cannot be set.
        /// </summary>
        [XmlIgnore]
        public MonitoringStateType? BTS
        {
            get { return XmlBTSSpecified ? (MonitoringStateType?)XmlBTS : null; }
            set
            {
                XmlBTSSpecified = value.HasValue;
                XmlBTS = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("BTS")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MonitoringStateType XmlBTS { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlBTSSpecified { get; set; }

        /// <summary>
        /// Current user monitoring state of the  DECT phone software status (SWS). Cannot be set.
        /// </summary>
        [XmlIgnore]
        public MonitoringStateType? SWS
        {
            get { return XmlSWSSpecified ? (MonitoringStateType?)XmlSWS : null; }
            set
            {
                XmlSWSSpecified = value.HasValue;
                XmlSWS = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("SWS")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MonitoringStateType XmlSWS { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlSWSSpecified { get; set; }

        /// <summary>
        /// User credential password for user authentication to get the user configuration file from the external server - encrypted with public key.
        /// This value is used when the access to the user data server requires user credentials, see Set/Get/EventUserDataServer(Cnf). This value is normaly set at  DECT phone during login. 
        /// </summary>
        [XmlAttribute("credentialPw")]
        public string CredentialPw { get; set; }  
        
        /// <summary>
        /// Determines whether DECT phone user configuration data (DECT phone profile or user specific configuration data) for this user has been downloaded successfully to the  DECT phone. This value is read only.
        /// </summary>
        [XmlIgnore]
        public bool? ConfigurationDataLoaded
        {
            get { return XmlConfigurationDataLoadedSpecified ? (bool?)XmlConfigurationDataLoaded : null; }
            set
            {
                XmlConfigurationDataLoadedSpecified = value.HasValue;
                XmlConfigurationDataLoaded = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("configurationDataLoaded")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlConfigurationDataLoaded { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlConfigurationDataLoadedSpecified { get; set; }

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
        [XmlIgnore]
        public int? PpProfileId
        {
            get { return XmlPpProfileIdSpecified ? (int?)XmlPpProfileId : null; }
            set
            {
                XmlPpProfileIdSpecified = value.HasValue;
                XmlPpProfileId = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("ppProfileId")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int XmlPpProfileId { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlPpProfileIdSpecified { get; set; }

        /// <summary>
        /// Explicitly used SIP port for registering the user at the call server. If fixedSipPort=0, no specific port is used for this user and the calculatedSipPort is used. 
        /// </summary>
        [XmlIgnore]
        public int? FixedSipPort
        {
            get { return XmlFixedSipPortSpecified ? (int?)XmlFixedSipPort : null; }
            set
            {
                XmlFixedSipPortSpecified = value.HasValue;
                XmlFixedSipPort = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("fixedSipPort")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int XmlFixedSipPort { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlFixedSipPortSpecified { get; set; }

        /// <summary>
        /// Calculated SIP port for registering the user at the call server. If calculatedSipPort=0, the fixedSipPort is used. This value is read only.
        /// </summary>
        [XmlIgnore]
        public int? CalculatedSipPort
        {
            get { return XmlCalculatedSipPortSpecified ? (int?)XmlCalculatedSipPort : null; }
            set
            {
                XmlCalculatedSipPortSpecified = value.HasValue;
                XmlCalculatedSipPort = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("calculatedSipPort")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int XmlCalculatedSipPort { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlCalculatedSipPortSpecified { get; set; }

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