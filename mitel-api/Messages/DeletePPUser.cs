using System.ComponentModel;
using System.Xml.Serialization;

namespace mitelapi.Messages
{
    [XmlRoot("DeletePPUser", Namespace = "")]
    public class DeletePPUser : BaseRequest
    {
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

        [XmlAttribute("uid")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int XmlUid { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlUidSpecified { get; set; }
    }

    [XmlRoot("DeletePPUserResp", Namespace = "")]
    public class DeletePPUserResp : BaseResponse
    {
    }
}