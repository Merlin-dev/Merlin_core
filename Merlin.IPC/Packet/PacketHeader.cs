using System;
using System.Runtime.InteropServices;

namespace Merlin.IPC
{
    /// <summary>
    /// Header of every packet sent via TCP network, used to identify packet when deserializing
    /// </summary>
    [Guid("783c242d-b60e-45d9-b35e-5c1219e39915")]
    public struct PacketHeader
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