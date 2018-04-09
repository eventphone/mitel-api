using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace mitelapi.Messages
{
    /// <summary>
    /// A client can delete one captured RFP from the captured RFPs list.
    /// </summary>
    [XmlRoot("DeleteRFPCaptureListElem", Namespace = "")]
    public class DeleteRFPCaptureListElem : BaseRequest
    {
        [XmlAttribute("ethAddr")]
        public string EthAddr;
    }

    /// <summary>
    /// The reply to this request is an object called DeleteRFPCaptureListElemResp.
    /// </summary>
    public class DeleteRFPCaptureListElemResp : BaseResponse
    {
    }
}