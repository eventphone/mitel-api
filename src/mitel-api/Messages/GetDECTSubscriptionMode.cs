using mitelapi.Types;
using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace mitelapi.Messages
{
    /// <summary>
    /// With this request the client can query the current state of the DECT subscription mode.
    /// Following fields are defined for this request in addition to the common attributes
    /// </summary>
    [XmlRoot("GetDECTSubscriptionMode", Namespace = "")]
    public class GetDECTSubscriptionMode : BaseRequest
    {
    }

    /// <summary>
    /// The reply to this request is an object called GetDECTSubscriptionModeResp. It contains following fields in
    /// addition to the common attributes:
    /// </summary>
    [XmlRoot("GetDECTSubscriptionModeResp", Namespace = "")]
    public class GetDECTSubscriptionModeResp : BaseResponse
    {
        /// <summary>
        /// Same modes as defined in chapter 4.30.2
        /// </summary>
        [XmlAttribute("mode")]
        public DECTSubscriptionModeType Mode { get; set; }

    }
}