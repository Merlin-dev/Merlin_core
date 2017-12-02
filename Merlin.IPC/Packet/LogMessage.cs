using System;
using System.Runtime.InteropServices;

namespace Merlin.IPC
{
    /// <summary>
    /// Log message
    /// </summary>
    [Guid("6556a9af-4b23-4eb6-ab24-b443f60bb87a")]
    public struct LogMessage
    {
        /// <summary>
        /// Should log be cleared?
        /// </summary>
        /// <remarks>
        /// Used when you want to clear the chat, for example when bot instance was closed etc..
        /// </remarks>
        public bool ClearLog;

        /// <summary>
        /// Time when log message was sent
        /// </summary>
        public DateTime CurentTime;

        /// <summary>
        /// Category of message (Log, Exception etc...)
        /// </summary>
        public string Category;

        /// <summary>
        /// The message
        /// </summary>
        public string Message;
    }
}