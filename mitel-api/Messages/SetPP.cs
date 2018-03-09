using mitelapi.Types;
using System.Xml.Serialization;

namespace mitelapi.Messages
{
    
    [XmlRoot("SetPP", Namespace = "")]
    public class SetPP : BaseRequest
    {
        
        [XmlElement("pp")]
        public PPDevType PortablePart {get; set;}

        [XmlElement("user")]
        public PPUserType User {get; set;}
    }

    [XmlRoot("SetPPResp", Namespace = "")]
    public class SetPPResp : BaseResponse 
    {
        [XmlElement("pp")]
        public PPDevType PortablePart {get; set;}

        [XmlElement("user")]
        public PPUserType User {get; set;}
    }
}