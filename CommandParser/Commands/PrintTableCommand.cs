using System;

namespace CommandParser.Commands
{
    public class PrintTableCommand : Command
    {
        public PrintTableCommand() : base("-k", "PRINT TABLE")
        {
            SetDesctiption("Outputs inputed parameters in key-value table representation.");
            Run = () =>
            {
                var parametersNumber = Parameters.Length;

                if (parametersNumber == 0)
                {
                    Console.WriteLine("No key-value pair found!");
                    return;
                }

                for (var i = 0; i < parametersNumber; i += 2)
                {
                    var result = Parameters[i] + " - ";
                    result += (i + 1) < parametersNumber ? Parameters[i + 1] : "null";
                    Console.WriteLine(result);
                }
            };
        }
    }
}
