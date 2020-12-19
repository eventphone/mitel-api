using System.Xml.Serialization;

namespace mitelapi.Messages
{
    //<RequestRFPEnrollment />
    public class RequestRFPEnrollment:BaseRequest
    {
        /// <summary>
        /// id of the RFP that needs to be enrolled again
        /// </summary>
        [XmlAttribute("rfpId")]
        public uint RfpId;
    }

    public class RequestRFPEnrollmentResp : BaseResponse
    {
    }
}