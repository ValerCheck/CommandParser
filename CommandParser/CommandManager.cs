using System;
using System.Collections.Generic;
using System.Linq;

namespace CommandParser
{
    /// <summary>
    /// This class is used to manage all supported commands
    /// </summary>
    public class CommandManager
    {
        private List<Command> CommandsToExecute = new List<Command>(); 
        public Dictionary<string,Command> AllowedCommands = new Dictionary<string, Command>();
        public Command PendingCommand;

        public CommandManager()
        {
            var helpCommand = new Command("-help /help /?","HELP");
            var tableCommand = new Command("-k","PRINT TABLE");
            var pingCommand = new Command("-ping", "PING");
            var printValueCommand = new Command("-print", "PRINT");

            helpCommand.SetDesctiption("Show help for CommandParser application!");
            helpCommand.Run = () =>
            {
                Console.WriteLine("\nThis is CommandParser application developed by Kolesnik Valerii.");
                Console.WriteLine("You can run this application with one or more rules.");
                Console.WriteLine("All rules listed below.\n");
                foreach (var command in AllowedCommands.Values.Distinct())
                {
                    var signs = command.Signature.Split(' ');
                    Console.WriteLine("{0}\t{1}", signs[0], command.Description);
                    if (signs.Length > 1)
                    {
                        for(int i=1;i<signs.Length;i++) Console.Write(signs[i]+"\n");
                    }
                    Console.WriteLine();
                    
                }
            };

            tableCommand.SetDesctiption("Outputs inputed parameters in key-value table representation.");
            tableCommand.Run = () =>
            {
                var parametersNumber = tableCommand.Parameters.Length;
                
                if (parametersNumber == 0)
                {
                    Console.WriteLine("No key-value pair found!");
                    return;
                }
                
                for(int i=0;i<parametersNumber;i+=2)
                {
                    var result = tableCommand.Parameters[i] + " - ";
                    result += (i + 1) < parametersNumber ? tableCommand.Parameters[i + 1] : "null";
                    Console.WriteLine(result);
                }
            };

            pingCommand.SetDesctiption("Making a sound.");
            pingCommand.Run = () =>
            {
                Console.WriteLine("Pinging...");
                Console.Beep(330,3000);
            };

            printValueCommand.SetDesctiption("Prints first parameter to the screen.");
            printValueCommand.Run = () => Console.WriteLine(printValueCommand.Parameters[0]);
            
            AllowedCommands.Add("-help",helpCommand);
            AllowedCommands.Add("/help", helpCommand);
            AllowedCommands.Add("/?", helpCommand);
            AllowedCommands.Add("-ping",pingCommand);
            AllowedCommands.Add("-print", printValueCommand);
            AllowedCommands.Add("-k",tableCommand);

        }

        public void AddCommandToExecute(Command command)
        {
            CommandsToExecute.Add(command);
        }

        public void AddCommandToExecute()
        {
            CommandsToExecute.Add(PendingCommand);
        }

        public void RunAllCommands()
        {
            if (PendingCommand != null)
            {
                CommandsToExecute.Add(PendingCommand);
                PendingCommand = null;
            }
            foreach (var command in CommandsToExecute)
            {
                command.Run.Invoke();
                if(command.Parameters!=null) Array.Clear(command.Parameters,0,command.Parameters.Length);
            }
        }
    }
}
