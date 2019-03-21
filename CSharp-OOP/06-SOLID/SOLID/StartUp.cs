using LoggerApp.Appenders;
using LoggerApp.Contracts;
using LoggerApp.Core;
using LoggerApp.Layouts;
using LoggerApp.Loggers;
using System;

namespace LoggerApp
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            var engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}
