using mitelapi.Types;
using System.Xml.Serialization;

namespace mitelapi.Messages
{
    /// <summary>
    /// With this request the client can acquire one or more alarm trigger data sets from the OMM.
    /// The request contains an id from which starting subsequent data sets are to be fetched.
    /// The client can chose the number of records returned.
    /// If less than this number of data sets are returned or ENoEnt, the client knows that it reached end of file.
    /// These IDs usually start at 0, but possibly not all numbers are assigned, i.e. the numbering may not be contiguous.
    /// The responses are ordered by id, starting with the smallest.
    /// If the client asked for a certain number of records and the given id does not exist, subsequent entries will be returned.
    /// If the client does not specify the number of records to be returned (maxRecords = "0", default), the given id has to match to a record exactly.
    /// If there is a record with this id, this one is returned, otherwise ENoEnt.
    /// To acquire all data sets, one could send GetAlarmTrigger (id = "0", maxRecords = "20").
    /// If the response contains 20 records, take the last ID plus one and send another GetAlarmTrigger.
    /// Repeat this until you get less than 20 records back
    /// </summary>
    public class GetAlarmTrigger : BaseRequest
    {
        /// <summary>
        /// First ID of alarm triggers to get
        /// </summary>
        [XmlAttribute("id")]
        public int Id { get; set; }

        /// <summary>
        /// Maximal number of records to return. Not more than 20 allowed. for special case 0 refer to text.
        /// </summary>
        [XmlAttribute("maxRecords")]
        public int MaxRecords { get; set; }
    }

    public class GetAlarmTriggerResp : BaseResponse
    {
        /// <summary>
        /// alarm trigger records, if found
        /// </summary>
        [XmlElement("trigger")]
        public AlarmTriggerType[] AlarmTrigger { get; set; }
    }
}