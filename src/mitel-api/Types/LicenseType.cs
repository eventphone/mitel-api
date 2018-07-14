using System.Xml.Serialization;

namespace mitelapi.Types
{
    /// <summary>
    /// This type contains all license RFP data fields. It is used in license the event and license responses defined in this chapter.
    /// </summary>
    public abstract class LicenseType
    {
        /// <summary>
        /// License key string
        /// </summary>
        [XmlAttribute("key")]
        public string Key { get; set; }

        /// <summary>
        ///Up to this number the license is valid depending on the license type.
        /// <remarks>
        /// <para>OMM system license:
        /// Number of RFPs to be used</para>
        /// <para>OMM locating license:
        /// Number of DECT phones allowed users to locate other users</para> 
        /// </remarks>
        /// </summary>
        [XmlAttribute("number")]
        public int Number { get; set; }
    }


    /// <inheritdoc/>
    public class SysLicenseType : LicenseType
    {
        /// <summary>
        /// OMM system license
        /// <remarks>
        /// <para>
        /// “x.y”, specifies the major release number “x” and the minor release number “y” of the OMM release the license is valid for.
        /// </para>
        /// </remarks>
        /// </summary>
        [XmlAttribute("systemLicenseVersion")]
        public string SystemLicenseVersion { get; set; }
    }

    /// <inheritdoc />
    public class MsgLicenseType:LicenseType
    {
        /// <summary>
        /// "1" or "true", if the license is valid to receive messages at the DECT phones.
        /// </summary>
        [XmlAttribute("messagingLicenseRcvMsgs")]
        public bool MessagingLicenseRcvMsgs { get; set; }
    }

    /// <inheritdoc />
    public class LocLicenseType : LicenseType
    {
        /// <summary>
        /// "1" or "true", if the license is valid to run the licensed external location application.
        /// </summary>
        [XmlAttribute("locatingLicense")]
        public bool LocatingLicense { get; set; }
    }
}