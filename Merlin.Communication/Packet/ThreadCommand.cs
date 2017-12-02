using System.Runtime.InteropServices;

namespace Merlin.Communication
{
    /// <summary>
    /// Command packet, which allows you to send specific commands to specific thread
    /// </summary>
    /// <remarks>
    /// Currently limitted to "Abort" command only
    /// </remarks>
    [Guid("70fb4d37-d356-471f-9464-ef56c2b95a22")]
    public class ThreadCommand
    {
        /// <summary>
        /// The ID of thread
        /// </summary>
        public int ID;

        /// <summary>
        /// The command (note: only "Abort" command implemented)
        /// </summary>
        public string Command;
    }
}