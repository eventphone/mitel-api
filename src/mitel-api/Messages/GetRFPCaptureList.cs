using mitelapi.Types;
using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace mitelapi.Messages
{
    /// <summary>
    /// A client can get a list with all captured but not configured RFPs.
    /// </summary>
    [XmlRoot("GetRFPCaptureList", Namespace = "")]
    public class GetRFPCaptureList : BaseRequest
    {
    }

    /// <summary>
    /// The reply to this request is an object called GetRFPCaptureListResp
    /// </summary>
    [XmlRoot("GetRFPCaptureListResp", Namespace = "")]
    public class GetRFPCaptureListResp : BaseResponse
    {
        /// <summary>
        /// All captured RFP records, if any
        /// </summary>
        [XmlElement("rfp")]
        public RFPType[] rfp { get; set; }

    }
}