using System;
using System.Net;
using System.Net.Sockets;

namespace Merlin.Communication
{
    /// <summary>
    /// Class wrapping <see cref="TcpListener"/> class, used as a server for IPC Communication
    /// </summary>
    public class CommunicationServer
    {
        private TcpListener _tcpListener;

        /// <summary>
        /// Occurs when client connected.
        /// </summary>
        public event ClientConnectedEventHandler ClientConnected;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommunicationServer"/> class.
        /// </summary>
        /// <param name="ip">The ip.</param>
        /// <param name="port">The port.</param>
        public CommunicationServer(IPAddress ip, int port)
        {
            _tcpListener = new TcpListener(ip, port);
        }

        /// <summary>
        /// Starts the server.
        /// </summary>
        /// <returns></returns>
        public bool Start()
        {
            try
            {
                _tcpListener.Start();
                BeginAcceptClient();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void BeginAcceptClient()
        {
            _tcpListener.BeginAcceptTcpClient(AcceptClient, null);
        }

        private void AcceptClient(IAsyncResult ar)
        {
            TcpClient client = _tcpListener.EndAcceptTcpClient(ar);
            BeginAcceptClient();
            CommunicationClient cc = new CommunicationClient(client);
            OnClientConnected(this, new ClientConnectedEventArgs(cc, this));
        }

        protected virtual void OnClientConnected(object sender, ClientConnectedEventArgs e)
        {
            ClientConnected?.Invoke(sender, e);
        }
    }
}