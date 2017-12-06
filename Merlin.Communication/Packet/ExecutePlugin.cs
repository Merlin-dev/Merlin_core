using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Merlin.Communication
{
    /// <summary>
    /// Loads and executes DLL, and launches the scripts
    /// </summary>
    public class ExecutePlugin
    {
        /// <summary>
        /// The plugin name
        /// </summary>
        public string PluginName;
        /// <summary>
        /// The path to DLL
        /// </summary>
        public string AssemblyPath;
    }
}
