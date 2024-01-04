using System.Xml.Serialization;
using mitelapi.Types;

namespace mitelapi.Messages
{
    /// <summary>
    /// The client can send this request to OM AXI to create a new RFP data set. Refer to chapter 4.42.1 for information
    /// about which attributes of an RFP have to be set in a create request.
    /// Consider the license restrictions for this command (see 5.5).
    /// If there is no id assigned by the client, the OMM will choose one. If the client assigns an id, it must not exist yet.
    /// Note that attributes describing transient properties are ignored, e. g. connected.
    /// </summary>
    public class CreateRFP : BaseRequest
    {
        /// <summary>
        /// Data of RFP to create
        /// </summary>
        [XmlElement("rfp")]
        public RFPType Rfp { get; set; }
    }

    /// <summary>
    /// If the RFP creation was successful, the reply contains all RFP attributes which GetRFP would return, but no state
    /// information.Some data fields may be changed or set by the OMM.If the creation fails, the OM AXI returns an
    /// error code.If applicable, the attributes will contain the data fields which lead to the error (which was wrong,
    /// missing etc.).
    /// </summary>
    public class CreateRFPResp : BaseResponse
    {
        /// <summary>
        /// Data of created RFP
        /// </summary>
        [XmlElement("rfp")]
        public RFPType Rfp { get; set; }
    }
}
