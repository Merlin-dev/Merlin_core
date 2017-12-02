using System;
using System.Runtime.InteropServices;

namespace Merlin.Communication
{
    /// <summary>
    /// Info packet used to store information about parallel threads used in the Hook
    /// </summary>
    public class ThreadInfo
    {
        /// <summary>
        /// The ID of this thread
        /// </summary>
        public int ManagedThreadId;

        /// <summary>
        /// The ID of parent thread
        /// </summary>
        public int ParentManagedThreadId;

        /// <summary>
        /// The name of the thread
        /// </summary>
        public string Name;

        /// <summary>
        /// The state of the thread
        /// </summary>
        public string State;
    }
}