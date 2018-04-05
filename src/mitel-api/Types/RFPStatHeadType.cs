using System.Xml.Serialization;

namespace mitelapi.Types
{
    /// <summary>
    /// This type contains information about the RFP statistic elements (counter).
    /// The different elements are combined to a record set.
    /// Record set 0 always exists, it contains the overall counter.
    /// History record sets may be exists.
    /// </summary>
    public class RFPStatHeadType
    {
        /// <summary>
        /// Number of different elements per RFP record
        /// </summary>
        [XmlAttribute("numElemPerRec")]
        public int ElementCount { get; set; }

        /// <summary>
        /// Number of history record sets
        /// Record 0 identifies the overall counter, 1 the current week, 2 the week before the current week and so on
        /// </summary>
        [XmlAttribute("recordSets")]
        public int RecordSetCount { get; set; }

        /// <summary>
        /// resolution of the history data sets
        /// </summary>
        [XmlAttribute("resolution")]
        public string Resolution { get; set; }
    }
}