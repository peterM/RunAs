using System;
using System.Runtime.InteropServices;

namespace MalikP.RunAs.Win32Api
{
    public static class Win32Wrapper
    {
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = true)]
        public static extern bool CreateProcessWithLogonW(
            string principal,
            string authority,
            string password,
            LogonFlags logonFlags,
            string appName,
            string cmdLine,
            CreationFlags creationFlags,
            IntPtr environmentBlock,
            string currentDirectory,
            ref StartupInfo startupInfo,
            out ProcessInfo processInfo);

        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(IntPtr h);
    }
}