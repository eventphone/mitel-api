using System.ComponentModel;
using System.Xml.Serialization;

namespace mitelapi.Messages
{
    public abstract class BaseRequest
    {
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