namespace MalikP.RunAs
{
    public sealed class RunAsContext
    {
        public RunAsContext(string executor, string command)
        {
            Command = command;
            Executor = executor;
        }

        public string Command { get; }
        public string Executor { get; }
    }
}
