using System;
using System.Collections.Concurrent;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using mitelapi.Events;
using mitelapi.Messages;

namespace mitelapi
{
    public class OmmSerializer
    {
        private readonly XmlSerializer _deserializer;
        private readonly ConcurrentDictionary<Type, XmlSerializer> _serializers = new ConcurrentDictionary<Type, XmlSerializer>();
        private readonly SemaphoreSlim _writeLock = new SemaphoreSlim(1, 1);

        private readonly byte[] _nullByte = new byte[]{0};

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
            var wrapper = DeserializeWrapper(message);
            return (T) wrapper.Response;
        }

        public T DeserializeEvent<T>(string message) where T:BaseEvent
        {
            var wrapper = DeserializeWrapper(message);
            return (T) wrapper.Event;
        }

        internal OmmResponseWrapper DeserializeWrapper(string message)
        {
            using (var reader = new StringReader($"<root>{message}</root>"))
            {
                return(OmmResponseWrapper) _deserializer.Deserialize(reader);
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

        public async Task<string> SerializeAsync<T>(T request, Stream stream, CancellationToken cancellationToken)
        {
            using (var sw = new StreamWriter(stream, new UTF8Encoding(false), 1024, true))
            {
                await _writeLock.WaitAsync(cancellationToken).ConfigureAwait(false);
                try
                {
                    var result = Serialize(request);
                    await sw.WriteAsync(result).ConfigureAwait(false);
                    await sw.FlushAsync().ConfigureAwait(false);
                    await stream.WriteAsync(_nullByte, 0, 1, cancellationToken).ConfigureAwait(false);
                    await stream.FlushAsync(cancellationToken).ConfigureAwait(false);
                    return result;
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