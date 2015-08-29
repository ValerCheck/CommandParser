using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;

namespace CommandParser
{
    enum Commands
    {
        Initial,
        Unknown,
        Help,
        PrintTable,
        Ping,
        PrintMessage
    }

    class Program
    {
        static void Main(string[] args)
        {
            var commandManager = new CommandManager();
            var parameters = new List<string>();
            for (int i = 0; i < args.Length; i++)
            {
                if (IsCommand(args[i]))
                {
                    if (commandManager.PendingCommand != null)
                        AddParametersToPending(parameters, commandManager);
                    if (!ValidateCommand(args[i], commandManager)) return;
                }
                else
                {
                    parameters.Add(args[i]);
                    if (i != args.Length - 1 || commandManager.PendingCommand == null) continue;
                    AddParametersToPending(parameters, commandManager);
                }
            }
            if (args.Length == 0) ValidateCommand("/?", commandManager);
            commandManager.RunAllCommands();

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
