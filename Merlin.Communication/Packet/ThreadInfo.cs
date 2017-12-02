using System;
using System.Runtime.InteropServices;

namespace Merlin.Communication
{
    /// <summary>
    /// Info packet used to store information about parallel threads used in the Hook
    /// </summary>
    [Guid("0e266bb8-35ec-4f05-8f31-92830a4fde68")]
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