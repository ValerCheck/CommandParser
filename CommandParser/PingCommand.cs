﻿using System;

namespace CommandParser
{
    public class PingCommand : Command
    {
        public PingCommand() : base("-ping", "PING")
        {
            SetDesctiption("Making a sound.");
            Run = () =>
            {
                Console.WriteLine("Pinging...");
                Console.Beep(330, 3000);
            };
        }
    }
}
