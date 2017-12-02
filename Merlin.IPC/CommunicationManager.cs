using System.Net;
using System.Net.Sockets;

namespace Merlin.IPC
{
    public sealed class CommunicationManager
    {
        /// <summary>
        /// Creates the server.
        /// </summary>
        /// <param name="ip">The ip.</param>
        /// <param name="port">The port.</param>
        /// <returns></returns>
        public static CommunicationServer CreateServer(IPAddress ip, int port)
        {
            return new CommunicationServer(ip, port);
        }

        /// <summary>
        /// Creates the client.
        /// </summary>
        /// <param name="ip">The ip.</param>
        /// <param name="port">The port.</param>
        /// <returns></returns>
        public static CommunicationClient CreateClient(IPAddress ip, int port)
        {
            TcpClient client = new TcpClient();
            client.Connect(ip, port);
            return new CommunicationClient(client);
        }
    }
}