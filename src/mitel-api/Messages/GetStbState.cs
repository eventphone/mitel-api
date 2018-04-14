using System.Xml.Serialization;
using mitelapi.Interfaces;
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
    public class GetStbStateResp : BaseResponse, IStbState
    {
        /// <inheritdoc />
        [XmlAttribute("ommStbState")]
        public OmmStbState StandbyState { get; set; }
        
        /// <inheritdoc />
        [XmlAttribute("ommStbAddr")]
        public string StandbyAddress { get; set; }
    }
}