using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace mitelapi.Messages
{
    /// <summary>
    /// A client can delete the list with all captured RFPs.
    /// </summary>
    [XmlRoot("DeleteRFPCaptureList", Namespace = "")]
    public class DeleteRFPCaptureList : BaseRequest
    {
    }

    /// <summary>
    /// The reply to this request is an object called DeleteRFPCaptureListResp.
    /// </summary>
    [XmlRoot("DeleteRFPCaptureListResp", Namespace = "")]
    public class DeleteRFPCaptureListResp : BaseResponse
    {
    }
}