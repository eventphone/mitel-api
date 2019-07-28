using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace mitelapi.Messages
{
    /// <summary>
    /// With this request the client can enable or disable auto-create on subscription
    /// Following fields are defined for this request in addition to the common attributes:
    /// </summary>
    [XmlRoot("SetDevAutoCreate", Namespace = "")]
    public class SetDevAutoCreate : BaseRequest
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
            get { return Enable ? "true" : "false"; }
            set { Enable = value == "true"; }
        }
    }

    /// <summary>
    /// Following fields are defined for this request in addition to the common attributes:
    /// </summary>
    [XmlRoot("SetDevAutoCreateResp", Namespace = "")]
    public class SetDevAutoCreateResp : BaseResponse
    {

    }
}