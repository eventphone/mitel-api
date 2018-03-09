
using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace mitelapi.Messages
{
    //<Open protocolVersion="45" username="omm" password="aa" OMPClient="1" />
    [XmlRoot("Open",Namespace = "")]
    public class Open:BaseRequest
    {
        [XmlAttribute("username")]
        public string Username { get; set; }

        [XmlAttribute("password")]
        public string Password { get; set; }

        [XmlAttribute("UserDeviceSyncClient")]
        public bool UserDeviceSyncClient { get; set; }

        [XmlIgnore]
        public bool UserDeviceSyncClientSpecified {
            get { return UserDeviceSyncClient; }
            set {}
        }
    }

    //<OpenResp ommStbState="None" ommVersion="OpenMobility Manager SIP-DECT 7.1-CK14" axiVersion="171101" ommAxiSpecVersion="7.1.1" protocolVersion="45" errCode="EAuth" />
    [XmlRoot("OpenResp", Namespace = "")]
    public class OpenResp : BaseResponse
    {
        [XmlAttribute("ommVersion")]
        public string OmmVersion { get; set; }

        [XmlAttribute("axiVersion")]
        public string AxiVersion { get; set; }

        [XmlAttribute("ommAxiSpecVersion")]
        public string OmmAxiSpecVersion { get; set; }

        [XmlAttribute("protocolVersion")]
        public int ProtocolVersion { get; set; }
        
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

        [XmlElement("publicKey")]
        public OmmPublicKey PublicKey { get; set; }
    }

    public class OmmPublicKey
    {
        [XmlAttribute("modulus")]
        public string Modulus { get; set; }

        [XmlAttribute("exponent")]
        public string Exponent { get; set; }
    }
}
