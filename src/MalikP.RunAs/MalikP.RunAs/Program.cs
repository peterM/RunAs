using System;
using System.Configuration;
using System.IO;
using System.Runtime.InteropServices;

using MalikP.RunAs.Win32Api;

namespace MalikP.RunAs
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName = ConfigurationManager.AppSettings["UserName"];
            string domain = ConfigurationManager.AppSettings["Domain"];
            string password = ConfigurationManager.AppSettings["Password"];
            string command = ConfigurationManager.AppSettings["Command"];

            //Example: 
            // "C:\Windows\System32\dsa.msc /domain=something.local"
            if (args.Length == 4)
            {
                userName = args[0];
                domain = args[1];
                password = args[2];
                command = args[3];
            }

            StartupInfo startupInfo = new StartupInfo
            {
                cb = Marshal.SizeOf(typeof(StartupInfo)),
                title = $"Impersonated command prompt - [{domain}\\{userName}]"
            };

            string appFileName = Path.Combine(Environment.SystemDirectory, "cmd.exe");
            string arguments = String.Format("/c \"{0}\"", command);

            ProcessInfo processInfo = new ProcessInfo();
            if (Win32Wrapper.CreateProcessWithLogonW(userName, domain, password, LogonFlags.LOGON_NETCREDENTIALS_ONLY, appFileName, arguments, 0, IntPtr.Zero, null, ref startupInfo, out processInfo))
            {
                Win32Wrapper.CloseHandle(processInfo.hProcess);
                Win32Wrapper.CloseHandle(processInfo.hThread);
            }
            else
            {
                string errorString = Marshal.GetLastWin32Error().ToString();
                Console.WriteLine(errorString);
            }
        }
    }
}