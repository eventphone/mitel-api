using System;
using System.ComponentModel;
using System.Xml.Serialization;
using mitelapi.Types;

namespace mitelapi.Messages
{
    [XmlRoot("Open")]
    public class Open:BaseRequest
    {
        /// <summary>
        /// User name for authentication
        /// </summary>
        [XmlAttribute("username")]
        public string Username { get; set; }

        /// <summary>
        /// Password for authentication
        /// </summary>
        [XmlAttribute("password")]
        public string Password { get; set; }

        [XmlAttribute("UserDeviceSyncClient")]
        public bool UserDeviceSyncClient { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool UserDeviceSyncClientSpecified {
            get { return UserDeviceSyncClient; }
            set {}
        }
    }

    public class OpenResp : BaseResponse
    {
        /// <summary>
        /// Full version string of the OMM:
        /// &lt;majorRelease&gt;.&lt;minorRelease&gt;.{RC x | SP y | &lt;bugfixVersion&gt;} [ Build z] [version description],
        /// e. g. „2.1 RC4”, „2.1 SP1”, „2.1.5”, „2.1SP1 Build 2”,r „3.0 RC1 Build 1 - OpenMobility SIP 3.0RC1-Internal”.
        /// RCx: Release candidate number x
        /// SPy: Release service pack number y
        /// bugfixVersion: Old bugfix release version number
        /// Build z: Build release number z for internal use
        /// </summary>
        [XmlAttribute("ommVersion")]
        public string OmmVersion { get; set; }

        [XmlAttribute("axiVersion")]
        public string AxiVersion { get; set; }

        /// <summary>
        /// Version string of the used OM AXI spezification (e. g. “6.1”).
        /// </summary>
        [XmlAttribute("ommAxiSpecVersion")]
        public string OmmAxiSpecVersion { get; set; }
        
        /// <summary>
        /// This is the OM AXI protocol version.
        /// The protocolVersion changes when at least one minor or major version number changes.
        /// </summary>
        [XmlAttribute("protocolVersion")]
        public int ProtocolVersion { get; set; }
        
        /// <summary>
        /// Number of currently connected AXI clients
        /// </summary>
        [XmlIgnore]
        public int? AxiClients
        {
            get { return XmlAxiClientsSpecified ? (int?)XmlAxiClients : null; }
            set
            {
                XmlAxiClientsSpecified = value.HasValue;
                XmlAxiClients = value.GetValueOrDefault();
            }
        }
        
        [XmlAttribute("axiClients")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int XmlAxiClients { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlAxiClientsSpecified { get; set; }

        /// <summary>
        /// Public key
        /// </summary>
        [XmlElement("publicKey")]
        public OmmPublicKey PublicKey { get; set; }
    }
}
