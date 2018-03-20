using System.Xml.Serialization;
using mitelapi.Types;

namespace mitelapi.Messages
{
    /// <summary>
    /// With this request a client can get the current SYNC quality data list of RFPs.
    /// Following fields are defined for the request GetRFPSyncQuality in addition to the common attributes:
    /// </summary>
    public class GetRFPSyncQuality : BaseRequest
    {
        /// <summary>
        /// First RFP id of RFP SYNC quality data records to get
        /// </summary>
        [XmlAttribute("id")]
        public int Id { get; set; }

        /// <summary>
        /// Maximal number of records to return. Not more than 20
        /// allowed.For special case 0 refer to text.
        /// </summary>
        [XmlAttribute("maxRecords")]
        public int MaxRecords { get; set; }
    }

    /// <summary>
    /// The reply to GetRFPSyncQuality is an object called GetRFPSyncQualityResp. It contains following attributes in
    /// addition to the common attributes:
    /// </summary>
    public class GetRFPSyncQualityResp : BaseResponse
    {
        /// <summary>
        /// All found SYNC quality data records
        /// </summary>
        [XmlElement("syncQuality")]
        public SyncQualityType[] SyncQuality { get; set; }
    }
}