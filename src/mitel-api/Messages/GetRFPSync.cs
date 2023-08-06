using System.Xml.Serialization;
using mitelapi.Types;

namespace mitelapi.Messages
{
    /// <summary>
    /// With this request a client can get the current synchronization state of an RFP.
    /// Following fields are defined for the request GetRFPSync in addition to the common attributes:
    /// </summary>
    public class GetRFPSync : BaseRequest
    {
        /// <summary>
        /// RFP id
        /// </summary>
        [XmlAttribute("id")]
        public int Id { get; set; }
    }

    /// <summary>
    /// The reply to GetRFPSync is an object called GetRFPSyncResp. It contains following attributes in addition to the
    /// common attributes:
    /// </summary>
    public class GetRFPSyncResp : BaseResponse
    {
        /// <summary>
        /// RFP id
        /// </summary>
        [XmlAttribute("id")]
        public int Id { get; set; }

        /// <summary>
        /// State info
        /// </summary>
        [XmlAttribute("syncState")]
        public RFPSyncStateType SyncState { get; set; }

        /// <summary>
        /// Relations to neighbor RFPs, if available
        /// </summary>
        [XmlElement("forward")]
        public SyncOffsetType[] Forward { get; set; }

        /// <summary>
        /// Relations from neighbor RFPs, if available
        /// </summary>
        [XmlElement("backward")]
        public SyncOffsetType[] Backward { get; set; }
    }
}