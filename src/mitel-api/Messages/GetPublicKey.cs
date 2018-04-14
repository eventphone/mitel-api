using System.Xml.Serialization;

namespace mitelapi.Messages
{
    /// <summary>
    /// With this request the client can obtain the public RSA key to be used to encrypt certain attributes.
    /// </summary>
    [XmlRoot("GetPublicKey")]
    public class GetPublicKey : BaseRequest
    {

    }

    public class GetPublicKeyResp : BaseResponse
    {
        /// <summary>
        /// Hexadecimal encoded public modulus n
        /// </summary>
        [XmlAttribute("modulus")]
        public string Modulus { get; set; }

        /// <summary>
        /// Hexadecimal encoded public exponent e
        /// </summary>
        [XmlAttribute("exponent")]
        public string Exponent { get; set; }
    }
}