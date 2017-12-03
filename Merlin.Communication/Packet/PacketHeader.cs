using System;

namespace Merlin.Communication
{
    /// <summary>
    /// Header of every packet sent via TCP network, used to identify packet when deserializing
    /// </summary>
    public class PacketHeader
    {
        public Guid GUID;

        /// <summary>
        /// Initializes a new instance of the <see cref="PacketHeader"/> struct.
        /// </summary>
        /// <param name="packet">The packet.</param>
        public PacketHeader(object packet)
        {
            this = new PacketHeader(packet.GetType());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PacketHeader"/> struct.
        /// </summary>
        /// <param name="type">The type.</param>
        public PacketHeader(Type type)
        {
            GUID = type.GUID;
        }
    }
}