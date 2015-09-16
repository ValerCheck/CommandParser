using System;

namespace CommandParser
{
    public class ExitCommand : Command
    {
        public ExitCommand() : base("-exit", "EXIT")
        {
            SetDesctiption("Exit from current instance of the CommandParser Application");
            Run = () => Environment.Exit(0);
        }
    }
}
