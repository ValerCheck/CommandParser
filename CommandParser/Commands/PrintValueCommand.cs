using System;
using System.Linq;

namespace CommandParser.Commands
{
    public class PrintValueCommand : Command
    {
        public PrintValueCommand() : base("-print","PRINT")
        {
            SetDesctiption("Prints first parameter to the screen.");
            Run = () =>
            {
                var printResult = Parameters.Aggregate("", (current, param) => current + (param + " "));
                Console.WriteLine(printResult);
            };
        }
    }
}
