using mitelapi.Types;
using System.Xml.Serialization;

namespace mitelapi.Events
{
    /// <summary>
    /// This event is sent by OM AXI each time when SYNC quality data of at least one RFP changes. Refer to chapter
    /// 4.1.4 on how to set up a notification session.
    /// To get this event the client has to subscribe to RFPSyncQuality.This is allowed if the client has at least one of
    /// the following permissions: Monitoring.
    /// </summary>
    [XmlRoot("EventRFPSyncQuality", Namespace = "")]
    public class EventRFPSyncQuality : BaseEvent 
    {
        /// <summary>
        /// SYNC quality data records
        /// </summary>
        [XmlElement("syncQuality")]
        public SyncQualityType[] SyncQuality { get; set; }
    }
}