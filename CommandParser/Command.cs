using System;

namespace CommandParser
{
    public class Command
    {
        public string Signature { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string[] Parameters { get; private set; }

        public Command(string signature, string name)
        {
            Signature = signature;
            Name = name;
        }

        public void SetDesctiption(string description)
        {
            Description = description;
        }

        public void SetParameters(string[] args)
        {
            Parameters = (string[])args.Clone();
        }

        public Action Run;
    }
}
