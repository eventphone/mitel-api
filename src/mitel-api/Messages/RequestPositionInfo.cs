using System.Xml.Serialization;

namespace mitelapi.Messages
{
    /// <summary>
    /// With this request a client can locate a DECT phone.
    /// </summary>
    [XmlRoot("RequestPositionInfo")]
    public class RequestPositionInfo : BaseRequest
    {
        /// <summary>
        /// PPN of DECT phone to be found
        /// </summary>
        [XmlAttribute("ppn")]
        public int Ppn { get; set; }
    }

    public class RequestPositionInfoResp : BaseResponse
    {

    }
}