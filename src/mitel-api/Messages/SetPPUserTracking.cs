using System.ComponentModel;
using System.Xml.Serialization;

namespace mitelapi.Messages
{
    /// <summary>
    /// The client can send this request to OM AXI to change the attribute trackingActive of a DECT phone user data set.
    /// The User ID (uid) has to be filled in by the client to identify the record to be changed.
    /// </summary>
    [XmlRoot("SetPPUserTracking")]
    public class SetPPUserTracking : BaseRequest
    {
        /// <summary>
        /// User ID, numbering starts at 1, 0 is invalid
        /// </summary>
        [XmlAttribute("uid")]
        public int Uid { get; set; }

        /// <summary>
        /// „1” or “true”, if the location of this user has to be tracked
        /// </summary>
        [XmlAttribute("trackingActive")]
        public bool TrackingActive { get; set; }
    }

    public class SetPPUserTrackingResp : BaseResponse
    {
        /// <summary>
        /// User ID, numbering starts at 1, 0 is invalid
        /// </summary>
        [XmlIgnore]
        public int? Uid
        {
            get { return XmlUidSpecified ? (int?)XmlUid : null; }
            set
            {
                XmlUidSpecified = value.HasValue;
                XmlUid = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("Uid")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int XmlUid { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlUidSpecified { get; set; }


        /// <summary>
        /// „1” or “true”, if the location of this user has to be tracked
        /// </summary>
        [XmlIgnore]
        public bool? TrackingActive
        {
            get { return XmlTrackingActiveSpecified ? (bool?)XmlTrackingActive : null; }
            set
            {
                XmlTrackingActiveSpecified = value.HasValue;
                XmlTrackingActive = value.GetValueOrDefault();
            }
        }

        [XmlAttribute("TrackingActive")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlTrackingActive { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlTrackingActiveSpecified { get; set; }

    }
}