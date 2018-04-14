using System.Xml.Serialization;
using mitelapi.Interfaces;
using mitelapi.Types;

namespace mitelapi.Events
{
    /// <summary>
    /// This event is sent by OM AXI when the OMM standby state has changed.
    /// To get this event the client has to subscribe to SystemState.
    /// This is allowed if the client has at least one of the following permissions: AllCnfRead.
    /// </summary>
    public class EventStbStateChange : BaseEvent, IStbState
    {
        /// <inheritdoc/>
        [XmlAttribute("ommStbState")]
        public OmmStbState StandbyState { get; set; }

        /// <inheritdoc />
        [XmlAttribute("ommStbAddr")]
        public string StandbyAddress { get; set; }
    }
}