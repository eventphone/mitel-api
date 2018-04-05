using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace mitelapi.Messages
{
    /// <summary>
    /// With this request the client can delete an RFP record in the OMM. The key used to delete an RFP is its id.
    /// Consider the license restrictions for this command (see 5.5).
    /// Following fields are defined for the request DeleteRFP in addition to the common attributes:
    /// </summary>
    [XmlRoot("DeleteRFP", Namespace = "")]
    public class DeleteRFP : BaseRequest
    {
        /// <summary>
        /// id of RFP to delete
        /// </summary>
        [XmlAttribute("id")]
        public int Id;
    }

    [XmlRoot("DeleteRFP", Namespace = "")]
    public class DeleteRFPResp : BaseResponse
    {

    }
}