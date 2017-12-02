using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;

namespace Merlin.Communication
{
    /// <summary>
    /// Class wrapping <see cref="TcpClient"/> class, used as a client for IPC communication
    /// </summary>
    public class CommunicationClient
    {
        private TcpClient _tcpClient;

        private Stream _stream;
        private BinaryReader _reader;
        private BinaryWriter _writer;

        private object _sendLock = new object();
        private object _receiveLock = new object();
        private object _getTypeFromGuidLock = new object();

        private static Dictionary<Guid, Type> _guidTypeCache = new Dictionary<Guid, Type>();

        /// <summary>
        /// Initializes a new instance of the <see cref="CommunicationClient"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        public CommunicationClient(TcpClient client)
        {
            _tcpClient = client;

            _stream = client.GetStream();
            _reader = new BinaryReader(_stream);
            _writer = new BinaryWriter(_stream);
        }

        /// <summary>
        /// Sends data to server in serialized form
        /// </summary>
        /// <param name="data">Data object to send</param>
        public void Send(object data)
        {
            lock (_sendLock)
            {
                InternalSend(new PacketHeader(data));
                InternalSend(data);
            }
        }

        /// <summary>
        /// Receives data from server and deserializes them
        /// </summary>
        /// <returns>Deserialized object</returns>
        public object Receive()
        {
            lock (_receiveLock)
            {
                PacketHeader info = InternalReceive<PacketHeader>();
                return InternalReceive(GetTypeFromGuid(info.GUID));
            }
        }

        private void InternalSend(object data)
        {
            byte[] serialized = InternalSerialize(data);
            _writer.Write(serialized.Length);
            _writer.Write(serialized);
            _writer.Flush();
        }

        private object InternalReceive(Type type)
        {
            int count = _reader.ReadInt32();
            byte[] serialized = _reader.ReadBytes(count);
            return InternalDeserialize(serialized, type);
        }

        private T InternalReceive<T>() where T : struct
        {
            return (T)InternalReceive(typeof(T));
        }

        private static byte[] InternalSerialize(object data)
        {
            using (StringWriter writer = new StringWriter())
            {
                XmlSerializer serializer = new XmlSerializer(data.GetType());
                serializer.Serialize(writer, data);
                return Encoding.Unicode.GetBytes(writer.ToString());
            }
        }

        private static object InternalDeserialize(byte[] data, Type type)
        {
            using (StringReader reader = new StringReader(Encoding.Unicode.GetString(data)))
            {
                XmlSerializer serializer = new XmlSerializer(type);
                return serializer.Deserialize(reader);
            }
        }

        private static T InternalDeserialize<T>(byte[] data) where T : struct
        {
            return (T)InternalDeserialize(data, typeof(T));
        }

        private Type GetTypeFromGuid(Guid guid)
        {
            lock (_getTypeFromGuidLock)
            {
                if (!_guidTypeCache.ContainsKey(guid))
                {
                    _guidTypeCache[guid] = Assembly.GetExecutingAssembly().GetTypes().Single((Type i) => i.GUID == guid);
                }
                return _guidTypeCache[guid];
            }
        }
    }
}