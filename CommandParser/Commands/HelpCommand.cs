using System;
using System.Linq;

namespace CommandParser.Commands
{
    public class HelpCommand:Command
    {
        private CommandManager Manager { get; set; }

        public HelpCommand(CommandManager manager) : base("-help /help /?", "HELP")
        {
            Manager = manager;
            SetDesctiption("Show help for CommandParser application!");
            Run = () =>
            {
                Console.WriteLine("\nThis is CommandParser application developed by Kolesnik Valerii.");
                Console.WriteLine("You can run this application with one or more rules.");
                Console.WriteLine("All rules listed below.\n");
                foreach (var command in Manager.AllowedCommands.Values.Distinct())
                {
                    var signs = command.Signature.Split(' ');
                    Console.WriteLine("{0}\t{1}", signs[0], command.Description);
                    if (signs.Length > 1)
                    {
                        for (int i = 1; i < signs.Length; i++) Console.Write(signs[i] + "\n");
                    }
                    Console.WriteLine();

                }
            };
        }
    }
}
