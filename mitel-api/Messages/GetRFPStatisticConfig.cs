using System.Xml.Serialization;
using mitelapi.Types;

namespace mitelapi.Messages
{
    /// <summary>
    /// This request is sent from the client to the OMM.
    /// With this request the client can query information about the RFP statistic elements. 
    /// </summary>
    public class GetRFPStatisticConfig : BaseRequest
    {

    }

    public class GetRFPStatisticConfigResp : BaseResponse
    {
        /// <summary>
        /// Summary header of the RFP statistic records
        /// </summary>
        [XmlElement("rfpStatHead")]
        public RFPStatHeadType Head { get; set; }

        /// <summary>
        /// Details of record-elements
        /// </summary>
        [XmlElement("rfpStatName")]
        public RFPStatNameType[] Name { get; set; }
    }
}