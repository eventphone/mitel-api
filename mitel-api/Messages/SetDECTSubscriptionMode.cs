using mitelapi.Types;
using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace mitelapi.Messages
{
    /// <summary>
    /// A client can send this request to the OMM to enable or disable DECT subscription modes. Once started, the
    /// subscription modes will be stopped by timers in the OMM.Additionally, they can be stopped explicitly with
    /// another SetDECTSubscriptionMode request.
    /// Use the mode Wildcard to enable wildcard subscriptions, i.e.subscriptions of DECT phones which’s IPEIs are not
    /// configured in the OMM yet.Use Configured to enable subscription of configured IPEIs only.Disable any
    /// subscription by using mode Off.
    /// Enabling Wildcard will also implicitly allow the Configured mode.
    /// The Configured mode does always have a timeout of 24 hours, no matter if it was started explicitly or implicitly
    /// with Wildcard.These 24 hours will not be extended automatically.
    /// The Wildcard mode can be started with a timeout between 1 minute and 60 minutes.Each time a wildcard
    /// subscription actually took place, the timeout will be extended by the time interval once given in the request.
    /// Activating one of these Subscription modes while there still a subscription mode enabled will have the same
    /// result as stopping the old mode before starting the new mode.
    /// To keep track of the states of subscription modes, there is a notification event defined, refer to chapter 4.30.3.    /// Following fields are defined for the request SetDECTSubscriptionMode in addition to the common attributes:
    /// </summary>
    [XmlRoot("SetDECTSubscriptionMode", Namespace = "")]
    public class SetDECTSubscriptionMode : BaseRequest
    {
        /// <summary>
        /// Mode to be set.
        /// </summary>
        [XmlAttribute("mode")]
        public DECTSubscriptionModeType Mode;

        /// <summary>
        /// Timeout for Wildcard mode. Default 3 minutes. Ignored
        /// in other modes.
        /// </summary>
        [XmlAttribute("timeout")]
        public int Timeout { get; set; }
    }

    /// <summary>
    /// The reply to this request is called SetDECTSubscriptionModeResp. It contains all actual set attributes, all
    /// attributes are optional.
    /// </summary>
    [XmlRoot("SetDECTSubscriptionModeResp", Namespace = "")]
    public class SetDECTSubscriptionModeResp : BaseResponse
    {
        
    }
}