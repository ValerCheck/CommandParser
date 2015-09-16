using System;
using System.Collections.Generic;

namespace CommandParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var commandManager = new CommandManager();
            var parameters = new List<string>();
            var input = args;
            while (true)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (IsCommand(input[i]))
                    {
                        if (commandManager.PendingCommand != null)
                            AddParametersToPending(parameters, commandManager);
                        if (!ValidateCommand(input[i], commandManager)) return;
                    }
                    else
                    {
                        parameters.Add(input[i]);
                        if (i != input.Length - 1 || commandManager.PendingCommand == null) continue;
                        AddParametersToPending(parameters, commandManager);
                    }
                }
                if (input.Length == 0) ValidateCommand("/?", commandManager);
                commandManager.RunAllCommands();
                Console.Write("\nCommandParser>>");
                input = Console.ReadLine().Split(' ');

            }

        }

        public static void AddParametersToPending(List<string> parameters, CommandManager manager)
        {
            manager.PendingCommand.SetParameters(parameters.ToArray());
            manager.AddCommandToExecute();
            parameters.Clear();
            manager.PendingCommand = null;
        }

        public static bool ValidateCommand(string sign, CommandManager manager)
        {
            if (!manager.AllowedCommands.ContainsKey(sign))
            {
                Console.WriteLine("Command {0} is not supported.", sign);
                Console.WriteLine("Use CommandParser.exe /? to see set of allowed commands");
                return false;
            }
            manager.PendingCommand = manager.AllowedCommands[sign];
            return true;
        }
        
        public static bool IsCommand(string sign)
        {
            return sign.Contains("/") || sign.Contains("-");
        }
    }
}
