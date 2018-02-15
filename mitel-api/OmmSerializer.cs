using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using mitelapi.Messages;

namespace mitelapi
{
    public class OmmSerializer
    {
        private readonly XmlSerializer _deserializer;
        private readonly ConcurrentDictionary<Type, XmlSerializer> _serializers = new ConcurrentDictionary<Type, XmlSerializer>();
        private readonly SemaphoreSlim _writeLock = new SemaphoreSlim(1, 1);

        private readonly XmlWriterSettings _writerSettings = new XmlWriterSettings
        {
            Indent = false,
            OmitXmlDeclaration = true,
            CloseOutput = false
        };
        
        private readonly XmlSerializerNamespaces _emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

        public OmmSerializer()
        {
            _deserializer = new XmlSerializer(typeof(OmmResponseWrapper));
        }

        public T Deserialize<T>(string message) where T:BaseResponse
        {
            return (T) Deserialize(message);
        }

        public BaseResponse Deserialize(string message)
        {
            using (var reader = new StringReader($"<root>{message}</root>"))
            {
                var wrapper = (OmmResponseWrapper) _deserializer.Deserialize(reader);
                return wrapper.Element;
            }
        }

        public string Serialize<T>(T request)
        {
            using (var sw = new StringWriter())
            {
                Serialize(request, sw);
                sw.Flush();
                return sw.ToString();
            }
        }

        public async Task Serialize<T>(T request, Stream stream)
        {
            using (var sw = new StreamWriter(stream, Encoding.UTF8, 1024, true))
            {
                await _writeLock.WaitAsync();
                try
                {
                    Serialize(request, sw);
                    stream.WriteByte(0);
                    await sw.FlushAsync();
                }
                finally
                {
                    _writeLock.Release();
                }
            }
        }

        private void Serialize<T>(T request, TextWriter target)
        {
            using (var writer = XmlWriter.Create(target, _writerSettings))
            {
                var serializer = GetSerializer<T>();
                serializer.Serialize(writer, request, _emptyNamepsaces);
            }
        }

        private XmlSerializer GetSerializer<T>()
        {
            return _serializers.GetOrAdd(typeof(T), x => new XmlSerializer(x,String.Empty));
        }
    }
}