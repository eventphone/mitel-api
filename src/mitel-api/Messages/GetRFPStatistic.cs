using System.Xml.Serialization;
using mitelapi.Types;

namespace mitelapi.Messages
{
    /// <summary>
    /// This request is sent from the client to the OMM.
    /// With this request the client can query the statistic counter of an RFP.
    /// </summary>
    public class GetRFPStatistic : BaseRequest
    {
        /// <summary>
        /// Unique RFP identifier. The numbering starts at 0
        /// </summary>
        [XmlAttribute("id")]
        public int Id { get; set; }

        /// <summary>
        /// Maximal number of records to return. Not more than 20 allowed.
        /// If maxRecord is equal 0, only the record of the RFP addressed by id should be fetched
        /// </summary>
        [XmlAttribute("maxRecords")]
        public int MaxRecords { get; set; }

        /// <summary>
        /// Record set to read
        /// Record 0 identifies the overall counter, 1 the current week, 2 the week before the current week and so on.
        /// </summary>
        [XmlAttribute("recordSet")]
        public int RecordSet { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class GetRFPStatisticResp : BaseResponse
    {
        /// <summary>
        /// Summary of the RFP statistic elements.
        /// The number and meaning of the elements can be read by using the GetRFPStatisticConfig Request.
        /// </summary>
        [XmlElement("rfpStatData")]
        public RFPStatDataType[] Data { get; set; }
    }
}