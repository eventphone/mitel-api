using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace mitelapi.Messages
{
    /// <summary>
    /// A client can get a list with all captured but not configured RFPs.
    /// </summary>
    [XmlRoot("GetRFPCapture", Namespace = "")]
    public class GetRFPCapture : BaseRequest
    {
    }

    /// <summary>
    /// The reply to this request is an object called GetRFPCaptureResp. It contains following element in addition to the
    /// common attributes:
    /// </summary>
    [XmlRoot("GetRFPCaptureResp", Namespace = "")]
    public class GetRFPCaptureResp : BaseResponse
    {
        /// <summary>
        /// „1” or “true”, if auto-create is enabled
        /// </summary>
        [XmlIgnore]
        public bool Enable { get; set; }

        [XmlAttribute("enable")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string EnableSerialize
        {
            get { return Enable ? "1" : "0"; }
            set { Enable = value == "1"; }
        }
    }
}