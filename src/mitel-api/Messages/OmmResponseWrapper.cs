using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using mitelapi.Events;

namespace mitelapi.Messages
{
    [XmlRoot("root")]
    public class OmmResponseWrapper:IXmlSerializable
    {
        public BaseResponse Response { get; set; }
        
        public BaseEvent Event { get; set; }

        public XmlSchema GetSchema()
        {
            throw new System.NotImplementedException();
        }

        public void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement("root");
            if (reader.NodeType != XmlNodeType.Element)
                throw new NotSupportedException();
            var name = reader.Name;
            var serializer = ResolveType(name);
            var content = serializer.Deserialize(reader);
            if (content is BaseEvent baseEvent)
                Event = baseEvent;
            else if (content is BaseResponse baseResponse)
                Response = baseResponse;
            reader.ReadEndElement();
        }

        public void WriteXml(XmlWriter writer)
        {
            throw new System.NotImplementedException();
        }

        private static readonly ConcurrentDictionary<string, XmlSerializer> _typeCache = new ConcurrentDictionary<string, XmlSerializer>();
        private static readonly Assembly _assembly = typeof(OmmResponseWrapper).Assembly;
        private static XmlSerializer ResolveType(string name)
        {
            return _typeCache.GetOrAdd(name, FindType);
        }

        private static XmlSerializer FindType(string name)
        {
            if (name.StartsWith("Event"))
            {
                var type = _assembly.GetTypes()
                    .Where(x => x.Namespace == typeof(BaseEvent).Namespace)
                    .FirstOrDefault(x => x.Name == name);
                if (type != null)
                    return new XmlSerializer(type);
            }
            if (name.EndsWith("Resp"))
            {
                var type = _assembly.GetTypes()
                    .Where(x => x.Namespace == typeof(BaseResponse).Namespace)
                    .FirstOrDefault(x => x.Name == name);
                if (type != null)
                    return new XmlSerializer(type);
            }
            throw new NotSupportedException($"{name} is not supported");
        }
    }
}