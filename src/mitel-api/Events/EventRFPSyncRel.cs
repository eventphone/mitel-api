using mitelapi.Types;
using System.Xml.Serialization;

namespace mitelapi.Events
{
    /// <summary>
    /// This event is sent by OM AXI each time when the set of synchronization relations of an RFP changes. Refer to
    /// chapter 4.1.4 on how to set up a notification session.
    /// To get this event the client has to subscribe to RFPSync.This is allowed if the client has at least one of the
    /// following permissions: Monitoring.
    /// Note that this event does only report changed forward relations. It is sent if there is a subscription for at least one
    /// of the two RFPs involved into the relation.
    /// If a forward relation of one RFP changes, the client must imply a change of a backward relation of the other RFP.
    /// When an RFP state changes from Synced to any other state, the client must imply that all relations got lost in    /// both directions. For this reason the client should also evaluate EventRFPState (see 4.42.8).
    /// </summary>
    public class EventRFPSyncRel : BaseEvent 
    {
        /// <summary>
        /// RFP-ID
        /// </summary>        
        [XmlElement("id")]
        public int Id { get; set;}

        /// <summary>
        /// Relations to neighbor RFPs, if available
        /// </summary>
        [XmlElement("forward")]
        public SyncOffsetType[] Forward { get; set; }
    }
}