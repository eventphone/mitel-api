using System;
using System.Linq;
using System.Xml.Serialization;

namespace mitelapi.Types
{
    /// <summary>
    /// The type RFPStatDataType contains the elements of one record set of a single RFP.
    /// </summary>
    public class RFPStatDataType
    {
        /// <summary>
        /// Unique RFP identifier. The numbering starts at 0
        /// </summary>
        [XmlAttribute("id")]
        public int Id { get; set; }

        /// <summary>
        /// This string contains all elements of one RFP statistic record as a comma separated list.
        /// </summary>
        [XmlAttribute("counter")]
        public string Counter { get; set; }

        private long[] _values;

        [XmlIgnore]
        public long[] Values
        {
            get
            {
                if (_values != null) return _values;
                _values = Counter.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(Int64.Parse)
                    .ToArray();
                return _values;
            }
        }
    }
}