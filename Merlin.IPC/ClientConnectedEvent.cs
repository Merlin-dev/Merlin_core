using System;

namespace Merlin.IPC
{
    public class ClientConnectedEventArgs : EventArgs
    {
        public CommunicationClient Client { get; set; }
        public CommunicationServer Server { get; set; }

        public ClientConnectedEventArgs(CommunicationClient client, CommunicationServer server)
        {
            Client = client;
            Server = server;
        }
    }

    public delegate void ClientConnectedEventHandler(object sender, ClientConnectedEventArgs e);
}