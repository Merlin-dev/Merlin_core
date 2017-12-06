using System;
using System.Diagnostics;
using MInject;
using System.IO;

namespace Merlin.Injector
{
    public class Minject
    {
        /// <summary>
        /// Injects the DLL to specific process.
        /// </summary>
        /// <param name="process">The process.</param>
        /// <param name="file">The file.</param>
        /// <param name="hidden">if set to <c>true</c> file will be hidden from AssemblyLoad callback.</param>
        /// <returns>        
        ///   <c>true</c> injection was successfull; otherwise, <c>false</c>.
        /// </returns>
        public static bool Inject(Process process, string file, bool hidden = false)
        {
            if(MonoProcess.Attach(process, out MonoProcess mp))
            {
                IntPtr domain = mp.GetRootDomain();
                mp.ThreadAttach(domain);
                mp.SecuritySetMode(0);
                if (hidden)
                {
                    mp.DisableAssemblyLoadCallback();
                }

                byte[] rawAssembly = File.ReadAllBytes(file);

                IntPtr imagePtr = mp.ImageOpenFromDataFull(rawAssembly);
                IntPtr assemblyPtr = mp.AssemblyLoadFromFull(imagePtr);
                if (hidden)
                {
                    mp.EnableAssemblyLoadCallback();
                }

                mp.Dispose();

                if(assemblyPtr == IntPtr.Zero)
                {
                    return false;
                }

                return true;
            }
            return false;
        }

        /// <summary>
        /// Hides the assembly loaded in <paramref name="load" /> method.
        /// </summary>
        /// <param name="process">The process.</param>
        /// <param name="load">The method.</param>
        public static bool HideAssemblyLoad(Process process, Action load)
        {
            if (!MonoProcess.Attach(process, out MonoProcess mp))
                return false;

            IntPtr domain = mp.GetRootDomain();
            mp.ThreadAttach(domain);
            mp.SecuritySetMode(0);

            if (!mp.DisableAssemblyLoadCallback())
            {
                mp.Dispose();
                return false;
            }

            load();

            mp.EnableAssemblyLoadCallback();
            mp.Dispose();
            return true;
        }
    }
}
