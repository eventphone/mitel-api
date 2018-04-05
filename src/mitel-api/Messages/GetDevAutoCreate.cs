using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace mitelapi.Messages
{
    /// <summary>
    /// With this request the client can query if auto-create devices on DECT subscription is enabled.
    /// Following fields are defined for this request in addition to the common attributes:
    /// </summary>
    [XmlRoot("GetDevAutoCreate", Namespace = "")]
    public class GetDevAutoCreate : BaseRequest
    {
    }

    /// <summary>
    /// The reply is an object called GetDevAutoCreateResp. It contains following fields in addition to the common
    /// attributes:
    /// </summary>
    [XmlRoot("GetDevAutoCreateResp", Namespace = "")]
    public class GetDevAutoCreateResp : BaseResponse
    {
        /// <summary>
        /// „1” or “true”, if auto-create is enabled
        /// </summary>
        [XmlIgnore]
        public bool Enable { get; set; }

        [XmlAttribute("enable")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string EnableSerialize
        {
            get { return Enable ? "1" : "0"; }
            set { Enable = value == "1"; }
        }
    }
}