using System;

namespace MalikP.RunAs.Win32Api
{
    [Flags]
    public enum LogonFlags
    {
        LOGON_WITH_PROFILE = 0x00000001,
        LOGON_NETCREDENTIALS_ONLY = 0x00000002
    }
}