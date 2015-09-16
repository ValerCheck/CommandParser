using System;
using System.Collections.Generic;

namespace CommandParser
{
    /// <summary>
    /// This class is used to manage all supported commands
    /// </summary>
    public class CommandManager
    {
        private readonly List<Command> _commandsToExecute = new List<Command>(); 
        public Dictionary<string,Command> AllowedCommands = new Dictionary<string, Command>();
        public Command PendingCommand;

        public CommandManager()
        {
            AddAllowedCommand(new ExitCommand());
            AddAllowedCommand(new PrintValueCommand());
            AddAllowedCommand(new PingCommand());
            AddAllowedCommand(new PrintTableCommand());
            AddAllowedCommand(new HelpCommand(this));
        }

        private void AddAllowedCommand(Command commandToAdd)
        {
            foreach (var sign in commandToAdd.Signature.Split(' ')) AllowedCommands.Add(sign, commandToAdd);
        }

        public void AddCommandToExecute(Command command)
        {
            _commandsToExecute.Add(command);
        }

        public void AddCommandToExecute()
        {
            _commandsToExecute.Add(PendingCommand);
        }

        public void RunAllCommands()
        {
            if (PendingCommand != null)
            {
                AddCommandToExecute(PendingCommand);
                PendingCommand = null;
            }
            foreach (var command in _commandsToExecute)
            {
                command.Run.Invoke();
                if(command.Parameters!=null) Array.Clear(command.Parameters,0,command.Parameters.Length);
            }
            _commandsToExecute.Clear();
        }
    }
}
