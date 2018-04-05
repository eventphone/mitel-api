using System.Xml.Serialization;
using mitelapi.Types;

namespace mitelapi.Messages
{
    /// <summary>
    /// The client can send this request to OM AXI to change an RFP data set. The id has to be filled in by the client to
    /// identify the record to be changed.Additionally the attributes of the RFP which have to be changed must be filled
    /// in by the client.
    /// Note that attributes describing transient properties are ignored
    /// </summary>
    public class SetRFP : BaseRequest
    {
        /// <summary>
        /// Data of RFP to chang
        /// </summary>
        [XmlElement("rfp")]
        public RFPType Rfp { get; set; }
    }

    /// <summary>
    /// If the RFP change was successful, the reply contains all RFP attributes which GetRFP would return, but no state
    /// information.Some data fields may be changed or set by the OMM.If the creation fails, the OM AXI returns an
    /// error code.If applicable, the attributes will contain the data fields which lead to the error (which was wrong,
    /// missing etc.).
    /// The reply to this request is called SetRFPResp. It contains all actual set attributes, all attributes are optional.
    /// </summary>
    public class SetRFPResp : BaseResponse
    {

    }
}
