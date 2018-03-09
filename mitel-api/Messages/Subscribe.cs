﻿using mitelapi.Types;
using System.ComponentModel;
using System.Xml.Serialization;

namespace mitelapi.Messages
{
    [XmlRoot("Subscribe", Namespace = "")]
    public class Subscribe : BaseRequest
    {
        [XmlElement("e")]
        public SubscribeCmd[] Commands { get; set; }
    }
    
    [XmlRoot("SubscribeResp", Namespace = "")]
    public class SubscribeResp:BaseResponse
    {
        public EventType Event { get; set; }
    }

    public class SubscribeCmd
    {
        public SubscribeCmd()
        {
        }

        public SubscribeCmd(EventType type)
        {
            Cmd = CmdType.On;
            Event = type;
        }

        [XmlAttribute("cmd")]
        public CmdType Cmd { get; set; }

        [XmlAttribute("eventType")]
        public EventType Event { get; set; }
        
        [XmlIgnore]
        public int? Ppn
        {
            get { return XmlPpnSpecified ? (int?)XmlPpn : null; }
            set
            {
                XmlPpnSpecified = value.HasValue;
                XmlPpn = value.GetValueOrDefault();
            }
        }
        
        [XmlAttribute("ppn")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long XmlPpn { get; set; }
        
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlPpnSpecified { get; set; }
        
        [XmlIgnore]
        public int? Uid
        {
            get { return XmlUidSpecified ? (int?)XmlPpn : null; }
            set
            {
                XmlUidSpecified = value.HasValue;
                XmlUid = value.GetValueOrDefault();
            }
        }
        
        [XmlAttribute("uid")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long XmlUid { get; set; }
        
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlUidSpecified { get; set; }
        
        [XmlIgnore]
        public int? RfpId
        {
            get { return XmlRfpIdSpecified ? (int?)XmlPpn : null; }
            set
            {
                XmlRfpIdSpecified = value.HasValue;
                XmlRfpId = value.GetValueOrDefault();
            }
        }
        
        [XmlAttribute("rfpId")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long XmlRfpId { get; set; }
        
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlRfpIdSpecified { get; set; }
        
        [XmlIgnore]
        public int? Omm
        {
            get { return XmlOmmSpecified ? (int?)XmlPpn : null; }
            set
            {
                XmlOmmSpecified = value.HasValue;
                XmlOmm = value.GetValueOrDefault();
            }
        }
        
        [XmlAttribute("omm")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long XmlOmm { get; set; }
        
        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool XmlOmmSpecified { get; set; }
        
        [XmlAttribute("trigger")]
        public string Trigger { get; set; }

        [XmlAttribute("scheme")]
        public string Scheme { get; set; }
    }
}