using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace mitelapi.Messages
{
    /// <summary>
    /// With this request the client can set the RFP capturing. After setting the OMM automatically captures all not
    /// configured RFPs connecting the OMM.The client can use these RFPs for an easier configuration.
    /// Following fields are defined for the request SetRFPCapture in addition to the common attributes
    /// </summary>
    [XmlRoot("SetRFPCapture", Namespace = "")]
    public class SetRFPCapture : BaseRequest
    {
        [XmlIgnore]
        public bool Enable { get; set; }

        [XmlAttribute("enable")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string EnableSerialize
        {
            get { return Enable ? "true" : "false"; }
            set { Enable = value == "true"; }
        }
    }

    /// <summary>
    /// A client can get a list with all captured but not configured RFPs.
    /// Following fields are defined for this request in addition to the common attributes:
    /// </summary>
    [XmlRoot("SetRFPCaptureResp", Namespace = "")]
    public class SetRFPCaptureResp : BaseResponse
    {
        /// <summary>
        /// „1” or “true”, when RFP capturing is enabled.
        /// </summary>
        [XmlIgnore]
        public bool Enable { get; set; }

        [XmlAttribute("enable")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string EnableSerialize
        {
            get { return Enable ? "true" : "false"; }
            set { Enable = value == "true"; }
        }
    }
}