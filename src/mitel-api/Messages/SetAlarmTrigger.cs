using mitelapi.Types;
using System.Xml.Serialization;

namespace mitelapi.Messages
{
    /// <summary>
    /// The client can send this request to OM AXI to change an alarm trigger data set.
    /// The id has to be filled in by the client to identify the record to be changed.
    /// Additionally the attributes which have to be changed must be filled in by the client.
    /// </summary>
    public class SetAlarmTrigger : BaseRequest
    {
        /// <summary>
        /// Data of alarm trigger to change.
        /// </summary>
        [XmlElement("trigger")]
        public AlarmTriggerType Trigger { get; set; }
    }

    public class SetAlarmTriggerResp : BaseResponse
    {
        /// <summary>
        /// alarm trigger records, if found
        /// </summary>
        [XmlElement("trigger")]
        public AlarmTriggerType[] AlarmTrigger { get; set; }
    }
}