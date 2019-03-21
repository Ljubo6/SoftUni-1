using LoggerApp.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerApp.Core
{
    public class Engine : IEngine
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            int appendersCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < appendersCount; i++)
            {
                string input = Console.ReadLine();
                commandInterpreter.CreateAppender(input);
            }

            string reportInfo = Console.ReadLine();

            while (reportInfo != "END")
            {
                commandInterpreter.CreateLog(reportInfo);
                reportInfo = Console.ReadLine();
            }

            this.commandInterpreter.PrintInfo();
        }
    }
}
