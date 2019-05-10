// MIT License
//
// Copyright (c) 2019 Peter M.
// 
// File: Program.cs 
// Company: MalikP.
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System;
using System.IO;
using System.Runtime.InteropServices;

using MalikP.RunAs.Win32Api;

namespace MalikP.RunAs
{
    class Program
    {
        private static readonly Settings _settings = new Settings();

        static void Main(string[] args)
        {
            //Example: 
            // "C:\Windows\System32\dsa.msc /domain=something.local"
            if (args.Length >= 4)
            {
                _settings.UserName = args[0];
                _settings.Domain = args[1];
                _settings.Password = args[2];
                _settings.Command = args[3];

                if (args.Length == 7)
                {
                    _settings.UseCustomCommandExecutor = bool.Parse(args[4]);
                    _settings.CustomCommandExecutor = args[5];
                    _settings.CommandArgument = args[6];
                }
            }

            StartupInfo startupInfo = new StartupInfo
            {
                cb = Marshal.SizeOf(typeof(StartupInfo)),
                title = $"Impersonated command prompt - [{_settings.Domain}\\{_settings.UserName}]"
            };

            RunAsContext runAsContext = SetupRunAsContext(_settings);

            ProcessInfo processInfo = new ProcessInfo();
            if (Win32Wrapper.CreateProcessWithLogonW(_settings.UserName, _settings.Domain, _settings.Password, LogonFlags.LOGON_NETCREDENTIALS_ONLY, runAsContext.Executor, runAsContext.Command, 0, IntPtr.Zero, null, ref startupInfo, out processInfo))
            {
                Win32Wrapper.CloseHandle(processInfo.hProcess);
                Win32Wrapper.CloseHandle(processInfo.hThread);
            }
            else
            {
                string errorString = Marshal.GetLastWin32Error().ToString();
                Console.WriteLine(errorString);

                Console.WriteLine("\n\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        private static RunAsContext SetupRunAsContext(Settings settings)
        {
            string appFileName = Path.Combine(Environment.SystemDirectory, "cmd.exe");
            string arguments = String.Format("/c \"{0}\"", settings.Command);

            if (settings.UseCustomCommandExecutor)
            {
                appFileName = settings.CustomCommandExecutor;
                arguments = String.Format("{0} \"{1}\"", settings.CommandArgument, settings.Command);
            }

            return new RunAsContext(appFileName, arguments);
        }
    }
}