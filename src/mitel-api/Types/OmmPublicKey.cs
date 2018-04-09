using System.Xml.Serialization;

namespace mitelapi.Types
{
    public class OmmPublicKey
    {
        /// <summary>
        /// Hexadecimal encoded public key modulus n
        /// </summary>
        [XmlAttribute("modulus")]
        public string Modulus { get; set; }

        /// <summary>
        /// Hexadecimal encoded public key exponent e
        /// </summary>
        [XmlAttribute("exponent")]
        public string Exponent { get; set; }
    }
}