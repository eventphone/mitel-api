using System.Collections.Generic;
using System.Security.Cryptography;
using System.Xml.Serialization;

namespace mitelapi.Messages
{

    /// <summary>
    /// With this request the client can query common information about the alarm triggers configured.
    /// </summary>
    [XmlRoot("GetAlarmTriggerSummary", Namespace = "")]
    public class GetAlarmTriggerSummary : BaseRequest
    {
    }

    /// <summary>
    /// The reply to this request is an object called GetAlarmTriggerSummaryResp.
    /// </summary>
    public class GetAlarmTriggerSummaryResp: BaseResponse
    {
        /// <summary>
        /// The total number of alarm triggers set up.
        /// </summary>
        [XmlAttribute("nRecords")]
        public int TotalCount { get; set; }

        /// <summary>
        /// The ID of the first alarm trigger set up.
        /// </summary>
        [XmlAttribute("idFirst")]
        public int FirstId { get; set; }
    }
}