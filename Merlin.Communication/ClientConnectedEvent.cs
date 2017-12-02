using System;

namespace Merlin.Communication
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class ClientConnectedEventArgs : EventArgs
    {
        /// <summary>
        /// Client which connected.
        /// </summary>
        public CommunicationClient Client { get; set; }

        /// <summary>
        /// Server to which client got connected
        /// </summary>
        public CommunicationServer Server { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientConnectedEventArgs"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="server">The server.</param>
        public ClientConnectedEventArgs(CommunicationClient client, CommunicationServer server)
        {
            Client = client;
            Server = server;
        }
    }

    /// <summary>
    /// Delegate for Client Connected event raised when <see cref="CommunicationClient"/> connects to <see cref="CommunicationServer"/>
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="ClientConnectedEventArgs"/> instance containing the event data.</param>
    public delegate void ClientConnectedEventHandler(object sender, ClientConnectedEventArgs e);
}