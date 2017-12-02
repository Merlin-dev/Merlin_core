namespace Merlin.Communication
{
    /// <summary>
    /// Command packet, which allows you to send specific commands to specific thread
    /// </summary>
    /// <remarks>
    /// Currently limitted to "Abort" command only
    /// </remarks>
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