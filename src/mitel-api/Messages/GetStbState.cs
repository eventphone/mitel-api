using System.Xml.Serialization;
using mitelapi.Types;

namespace mitelapi.Messages
{
    /// <summary>
    /// With this requests the client can ask for information about the current OMM standby state.
    /// </summary>
    [XmlRoot("GetStbState")]
    public class GetStbState : BaseRequest
    {

    }

    /// <summary>
    /// Contains information about the OMM standby feature.
    /// </summary>
    public class GetStbStateResp : BaseResponse
    {
        /// <summary>
        /// State of the OMM standby feature.
        /// </summary>
        [XmlAttribute("ommStbState")]
        public OmmStbState StandbyState { get; set; }

        /// <summary>
        /// In case of OMM standby is active: IP address of the other OMM
        /// </summary>
        [XmlAttribute("ommStbAddr")]
        public string StandbyAddress { get; set; }
    }
}