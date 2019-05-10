using System.Configuration;

namespace MalikP.RunAs
{
    public sealed class Settings
    {
        public string UserName { get; set; } = ConfigurationManager.AppSettings[nameof(UserName)];

        public string Domain { get; set; } = ConfigurationManager.AppSettings[nameof(Domain)];

        public string Password { get; set; } = ConfigurationManager.AppSettings[nameof(Password)];

        public string Command { get; set; } = ConfigurationManager.AppSettings[nameof(Command)];

        public bool UseCustomCommandExecutor { get; set; } = bool.Parse((ConfigurationManager.AppSettings[nameof(UseCustomCommandExecutor)] ?? "false"));

        public string CustomCommandExecutor { get; set; } = ConfigurationManager.AppSettings[nameof(CustomCommandExecutor)];

        public string CommandArgument { get; set; } = ConfigurationManager.AppSettings[nameof(CommandArgument)];
    }
}
