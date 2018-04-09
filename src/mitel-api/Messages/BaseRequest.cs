using System.ComponentModel;
using System.Xml.Serialization;

namespace mitelapi.Messages
{
    public abstract class BaseRequest
    {
        /// <summary>
        /// The client may give a unique sequence number to each request it sends.
        /// The response to the request will contain the same sequence number.
        /// This can be used by the client to associate responses to the corresponding requests.
        /// <para/>
        /// The sequence number (seq) is returned by OM AXI transparently in the response. The client may use any kind of cookie which is useful for it.
        /// </summary>
        [XmlAttribute("seq")]
        public int Seq { get; set; }

        [XmlIgnore]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool SeqSpecified
        {
            get { return Seq != 0; }
        }
    }
}