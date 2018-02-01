using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace mitelapi.Messages
{
    [XmlRoot("Ping", Namespace = "")]
    public class Ping : BaseRequest
    {
        public Ping()
        {
            Timestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
        }

        [XmlAttribute("timeStamp")]
        public long Timestamp { get; set; }
    }
    
    [XmlRoot("PingResp", Namespace = "")]
    public class PingResp:BaseResponse
    {
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