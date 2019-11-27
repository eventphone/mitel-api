using System.ComponentModel;
using System.Xml.Serialization;

namespace mitelapi.Types
{
    /// <summary>
    /// This type contains all fields of a message.
    /// It is used in different requests and notifications.
    /// </summary>
    public class MessageType
    {
        /// <summary>
        /// Original send time in seconds since 01.01.1970 00:00 as it shall be used to display the send time at the DECT phone
        /// (note that the DECT phone and the AXI client might be in different time zones – this will not be adjusted for the DECT phone).
        /// </summary>
        [XmlAttribute("sendTime")]
        public uint SendTime { get; set; }

        /// <summary>
        /// Message ID. sendTime and id together should be chosen to be unique.
        /// This may be left out if the message does not need to be identified later.
        /// The default setting is 0.
        /// Since SIP-DECT 7.0 the value has to less than 1048576.
        /// </summary>
        [XmlIgnore]
        public uint? Id
        {
            get { return XmlIdSpecified ? (uint?) XmlId : null; }
            set
            {
                XmlIdSpecified = value.HasValue;
                XmlId = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("id")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint XmlId { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlIdSpecified { get; set; }

        /// <summary>
        /// If sent from a DECT phone: PPN
        /// </summary>
        [XmlIgnore]
        public int? Ppn
        {
            get { return XmlPpnSpecified ? (int?) XmlPpn : null; }
            set
            {
                XmlPpnSpecified = value.HasValue;
                XmlPpn = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("ppn")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int XmlPpn { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlPpnSpecified { get; set; }

        /// <summary>
        /// Sender address.
        /// In URI format, e. g. “mailto:foo@bar.org”, “tel:4711”.
        /// The maximal length is 64 bytes/characters(UTF-8 characters might be more than 1 byte).
        /// The client can feel free to use this address.
        /// An address like „alarmserver:alarmtype“ would be correct.
        /// It is up to the client use this address on how messages handled internally.
        /// </summary>
        [XmlAttribute("fromAddr")]
        public string FromAddr { get; set; }

        /// <summary>
        /// Human readable name of the sender, if available.
        /// The maximal length is 64 bytes/characters(UTF-8 characters might be more than 1 byte).
        /// </summary>
        [XmlAttribute("fromName")]
        public string FromName { get; set; }

        /// <summary>
        /// Recipient address in URI format.
        /// This may also be an explicit PPN, e. g. "ppn:23" to address a physical DECT phone.
        /// The maximal length is 128 bytes/characters(UTF-8 characters might be more than 1 byte).
        /// </summary>
        [XmlAttribute("toAddr")]
        public string ToAddr { get; set; }

        /// <summary>
        /// Human readable name of the recipient, if available.
        /// The maximal length is 64 bytes/characters(UTF-8 characters might be more than 1 byte).
        /// </summary>
        [XmlAttribute("toName")]
        public string ToName { get; set; }

        /// <summary>
        /// Callback address in URI format.
        /// This must be an explicit "cb:<calling party number>" to address a physical DECT phone.
        /// The maximal length is 64 bytes/characters(UTF-8 characters might be more than 1 byte).
        /// </summary>
        [XmlAttribute("callbackAddr")]
        public string CallbackAddr { get; set; }

        /// <summary>
        /// Human readable callback name of the callback receiver, if available.
        /// The maximal length is 64 bytes/characters(UTF-8 characters might be more than 1 byte).
        /// </summary>
        [XmlAttribute("callbackName")]
        public string CallbackName { get; set; }

        /// <summary>
        /// Automatic call establishment from the recipient DECT phone of the message to the callback address party.
        /// Default=False
        /// Note: autoCallback is not supported to a video device.
        /// </summary>
        [XmlIgnore]
        public bool? AutoCallback
        {
            get { return XmlAutoCallbackSpecified ? (bool?)XmlAutoCallback : null; }
            set
            {
                XmlAutoCallbackSpecified = value.HasValue;
                XmlAutoCallback = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("autoCallback")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlAutoCallback { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlAutoCallbackSpecified { get; set; }

        /// <summary>
        /// One of “Info”, “Low”, “Normal”, “High”, “Emergency”, “LocatingAlert”.
        /// </summary>
        [XmlIgnore]
        public MessagePriorityType? Priority
        {
            get { return XmlPrioritySpecified ? (MessagePriorityType?)XmlPriority : null; }
            set
            {
                XmlPrioritySpecified = value.HasValue;
                XmlPriority = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("priority")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MessagePriorityType XmlPriority { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlPrioritySpecified { get; set; }

        /// <summary>
        /// Where to store the message.
        /// </summary>
        [XmlIgnore]
        public FolderType? Folder
        {
            get { return XmlFolderSpecified ? (FolderType?)XmlFolder : null; }
            set
            {
                XmlFolderSpecified = value.HasValue;
                XmlFolder = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("folder")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FolderType XmlFolder { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlFolderSpecified { get; set; }

        /// <summary>
        /// „1” or “true”, if the receiver must not reply to this message
        /// </summary>
        [XmlAttribute("noReply")]
        public bool NoReply { get; set; }

        /// <summary>
        /// „1” or “true”, if the message has to be deleted after it reached its final state (i.e. all required confirmations sent)
        /// </summary>
        [XmlAttribute("autoDelete")]
        public bool AutoDelete { get; set; }

        /// <summary>
        /// „1” or “true”, for additional pop-up window
        /// </summary>
        [XmlAttribute("popUp")]
        public bool PopUp { get; set; }

        /// <summary>
        /// One of “UTF-8”
        /// </summary>
        [XmlIgnore]
        public EncodingType? Encoding
        {
            get { return XmlEncodingSpecified ? (EncodingType?)XmlEncoding : null; }
            set
            {
                XmlEncodingSpecified = value.HasValue;
                XmlEncoding = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("encoding")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public EncodingType XmlEncoding { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlEncodingSpecified { get; set; }

        /// <summary>
        /// One of “text/plain”, “text/x-vcard”.
        /// </summary>
        [XmlIgnore]
        public ContentTypeType? ContentType
        {
            get { return XmlContentTypeSpecified ? (ContentTypeType?)XmlContentType : null; }
            set
            {
                XmlContentTypeSpecified = value.HasValue;
                XmlContentType = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("contentType")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContentTypeType XmlContentType { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlContentTypeSpecified { get; set; }

        /// <summary>
        /// Confirmations and their choices wanted for this message.
        /// </summary>
        [XmlElement("confirm")]
        public MessageConfirmType[] Confirm { get; set; }

        /// <summary>
        /// Message content.
        /// </summary>
        [XmlAttribute("content")]
        public string Content { get; set; }

        /// <summary>
        /// One of “text/plain”, “text/x-vcard”.
        /// </summary>
        [XmlIgnore]
        public MelodyType? Melody
        {
            get { return XmlMelodySpecified ? (MelodyType?)XmlMelody : null; }
            set
            {
                XmlMelodySpecified = value.HasValue;
                XmlMelody = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("melody")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MelodyType XmlMelody { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlMelodySpecified { get; set; }

        /// <summary>
        /// Optional explicit tone selection to be signaled.
        /// The string values of the tone to be sound is specified the table further below and depends on the DECT phone model.
        /// If this element is used the melody element is obsolete.
        /// Depending on the DECT phone model not all the strings may work at the DECT phone.
        /// The string value is not check for correctness.
        /// Therefore wrong or unknown string values are ignored.
        /// </summary>
        [XmlAttribute("explicitToneSelection")]
        public string ExplicitToneSelection { get; set; }

        /// <summary>
        /// Optional acoustical signalling volume parameter when the message is received at the DECT phone (value 0/local volume or 1 till 100% volume), default is 0.
        /// Please note: If the parameter "ringerTone", "melody", "vibrator", "increasingVolume" or "noInbandSignalling" is set, the default "signallingVolume" is "no tone", equal of the configured setting in the phone.
        /// In this case a signallingVolume must be specified to have an acoustic ringing.
        /// To force a message without notification set ringerTone to true and signallingVolume to 0.
        /// </summary>
        [XmlIgnore]
        public int? SignallingVolume
        {
            get { return XmlSignallingVolumeSpecified ? (int?) XmlSignallingVolume : null; }
            set
            {
                XmlSignallingVolumeSpecified = value.HasValue;
                XmlSignallingVolume = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("signallingVolume")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int XmlSignallingVolume { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlSignallingVolumeSpecified { get; set; }

        /// <summary>
        /// „1” or “true”, if increasing volume shall be active, when the message is received at the DECT phone.
        /// Otherwise the local DECT phone setting is used.
        /// The default setting is “false”.
        /// Note: Increasing volume does not work with all used tones.
        /// </summary>
        [XmlIgnore]
        public bool? IncreasingVolume
        {
            get { return XmlIncreasingVolumeSpecified ? (bool?)XmlIncreasingVolume : null; }
            set
            {
                XmlIncreasingVolumeSpecified = value.HasValue;
                XmlIncreasingVolume = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("increasingVolume")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlIncreasingVolume { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlIncreasingVolumeSpecified { get; set; }

        /// <summary>
        /// „1” or “true”, if vibration signalling shall be active, when the message is received at the DECT phone.
        /// Otherwise the local DECT phone setting is used.
        /// The default setting is “false”.
        /// </summary>
        [XmlAttribute("vibraCall")]
        public bool VibraCall { get; set; }

        /// <summary>
        /// Optional parameter to set the DECT phone into idle state prior (e. g. an established call will be disconnected) when the message is received.
        /// </summary>
        [XmlIgnore]
        public bool? DisconnectCallOnReceive
        {
            get { return XmlDisconnectCallOnReceiveSpecified ? (bool?)XmlDisconnectCallOnReceive : null; }
            set
            {
                XmlDisconnectCallOnReceiveSpecified = value.HasValue;
                XmlDisconnectCallOnReceive = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("discCallOnRecv")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlDisconnectCallOnReceive { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlDisconnectCallOnReceiveSpecified { get; set; }

        /// <summary>
        /// „1” or “true”, if no inband signalling shall be active, when the message is received at the DECT phone.
        /// Otherwise the local DECT phone setting is used.
        /// The default setting is “false”.
        /// </summary>
        [XmlAttribute("noInbandSignalling")]
        public bool NoInbandSignalling { get; set; }

        /// <summary>
        /// „1” or “true”, if ringer tone shall be active, when the message is received at the DECT phone.
        /// Otherwise the local DECT phone setting is used.
        /// The default setting is “false”.
        /// </summary>
        [XmlAttribute("ringerTone")]
        public bool RingerTone { get; set; }

        /// <summary>
        /// Optional red text message colour parameter when the message is received at the DECT phone (value -1/no red background colour or 0 till 255), default is -1.
        /// </summary>
        [XmlIgnore]
        public int? TextColourR
        {
            get { return XmlTextColourRSpecified ? (int?)XmlTextColourR : null; }
            set
            {
                XmlTextColourRSpecified = value.HasValue;
                XmlTextColourR = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("textColourR")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int XmlTextColourR { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlTextColourRSpecified { get; set; }

        /// <summary>
        /// Optional green text message colour parameter when the message is received at the DECT phone (value -1/no green background colour or 0 till 255), default is -1.
        /// </summary>
        [XmlIgnore]
        public int? TextColourG
        {
            get { return XmlTextColourGSpecified ? (int?)XmlTextColourG : null; }
            set
            {
                XmlTextColourGSpecified = value.HasValue;
                XmlTextColourG = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("textColourG")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int XmlTextColourG { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlTextColourGSpecified { get; set; }

        /// <summary>
        /// Optional blue text message colour parameter when the message is received at the DECT phone (value -1/no blue background colour or 0 till 255), default is -1.
        /// </summary>
        [XmlIgnore]
        public int? TextColourB
        {
            get { return XmlTextColourBSpecified ? (int?)XmlTextColourB : null; }
            set
            {
                XmlTextColourBSpecified = value.HasValue;
                XmlTextColourB = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("textColourB")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int XmlTextColourB { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlTextColourBSpecified { get; set; }

        /// <summary>
        /// Optional red background message colour parameter when the message is received at the DECT phone (value -1/no red text colour or 0 till 255), default is -1.
        /// </summary>
        [XmlIgnore]
        public int? BackgroundColourR
        {
            get { return XmlBackgroundColourRSpecified ? (int?)XmlBackgroundColourR : null; }
            set
            {
                XmlBackgroundColourRSpecified = value.HasValue;
                XmlBackgroundColourR = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("bgColourR")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int XmlBackgroundColourR { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlBackgroundColourRSpecified { get; set; }

        /// <summary>
        /// Optional green background message colour parameter when the message is received at the DECT phone (value -1/no green text colour or 0 till 255), default is -1.
        /// </summary>
        [XmlIgnore]
        public int? BackgroundColourG
        {
            get { return XmlBackgroundColourGSpecified ? (int?)XmlBackgroundColourG : null; }
            set
            {
                XmlBackgroundColourGSpecified = value.HasValue;
                XmlBackgroundColourG = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("bgColourG")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int XmlBackgroundColourG { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlBackgroundColourGSpecified { get; set; }

        /// <summary>
        /// Optional blue background message color parameter when the message is received at the DECT phone (value -1/no blue text colour or 0 till 255), default is -1.
        /// </summary>
        [XmlIgnore]
        public int? BackgroundColourB
        {
            get { return XmlBackgroundColourBSpecified ? (int?)XmlBackgroundColourB : null; }
            set
            {
                XmlBackgroundColourBSpecified = value.HasValue;
                XmlBackgroundColourB = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("bgColourB")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int XmlBackgroundColourB { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlBackgroundColourBSpecified { get; set; }
    }
}