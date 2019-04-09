using System;
using System.Runtime.InteropServices;

namespace MalikP.RunAs.Win32Api
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ProcessInfo
    {
        public IntPtr hProcess;
        public IntPtr hThread;
        public uint dwProcessId;
        public uint dwThreadId;
    }
}