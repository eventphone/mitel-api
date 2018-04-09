using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace mitelapi.Messages
{
    [XmlRoot("Ping")]
    public class Ping : BaseRequest
    {
        public Ping()
        {
            Timestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
        }

        /// <summary>
        /// The client requests with the time stamp (in seconds since 1970/1/1) the current time stamp from the AXI server (OMM).
        /// </summary>
        [XmlAttribute("timeStamp")]
        public long Timestamp { get; set; }
    }
    
    public class PingResp:BaseResponse
    {
        /// <summary>
        /// Current time stamp (in seconds since 1970/1/1) response by the AXI server (OMM) when the client requires the time stamp to verify whether the current time is correctly used.
        /// </summary>
        [XmlIgnore]
        public long? TimeStamp
        {
            get { return XmlTimeStampSpecified ? (long?)XmlTimeStamp : null; }
            set
            {
                XmlTimeStampSpecified = value.HasValue;
                XmlTimeStamp = value.GetValueOrDefault();
            }
        }
        
        [XmlAttribute("timeStamp")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long XmlTimeStamp { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlTimeStampSpecified { get; set; }

    }
}