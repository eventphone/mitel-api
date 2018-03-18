using System.Xml.Serialization;
using mitelapi.Types;

namespace mitelapi.Messages
{
    /// <summary>
    /// With this request the client can query information about one or more RFPs from the OMM.
    /// The request contains an RFP-ID from which starting subsequent data sets are to be fetched.The client can
    /// chose the number of records returned.If less than this number of data sets are returned or ENoEnt, the client
    /// knows that it reached end of file.
    /// RFP-IDs usually start at 0, but possibly not all numbers are assigned, i.e.the data set numbering may not be
    /// contiguous.
    /// Only attributes of the RFP used on the present OMM version and accessible with the current user’s permissions
    /// are returned. Refer to chapter 4.48 for details.
    /// The responses are ordered by id, starting with the smallest.
    /// If the client asked for a certain number records but the given id does not exist, subsequent entries will be
    /// returned.
    /// If the client does not specify the number of records to be returned (maxRecords = "0", default), the given id has to
    /// match to a record exactly. If there is a record with this id, it is returned, otherwise ENoEnt.
    /// To acquire all data sets, one could send GetRFP (id = "0", maxRecords = "20"). If the response contains 20
    /// records, take the last id plus one and send another GetRFP. Repeat this until you get less than 20 records back
    /// </summary>
    public class GetRFP : BaseRequest
    {
        /// <summary>
        /// First RFP id of RFPs to get
        /// </summary>
        [XmlAttribute("id")]
        public int Id { get; set; }
        /// <summary>
        /// Maximal number of records to return. Not more than 20
        /// allowed.For special case 0 refer to text.
        /// </summary>
        [XmlAttribute("maxRecords")]
        public int MaxRecords { get; set; }
        /// <summary>
        /// „1” or “true”, if state information is also wanted
        /// </summary>
        [XmlAttribute("withState")]
        public bool WithState { get; set; }
        /// <summary>
        /// „1” or “true”, if details are also wanted.
        /// </summary>
        [XmlAttribute("withDetails")]
        public bool WithDetails { get; set; }
    }

    /// <summary>
    /// The reply to GetRFP is an object called GetRFPResp. It contains following element in addition to the common    /// attributes:
    /// </summary>
    public class GetRFPResp : BaseResponse
    {
        /// <summary>
        /// RFP record, if found
        /// </summary>
        [XmlElement("rfp")]
        public RFPType[] RFPs { get; set; }

    }
}
