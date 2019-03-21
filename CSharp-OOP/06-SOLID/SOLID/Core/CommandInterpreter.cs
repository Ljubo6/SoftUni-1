using LoggerApp.Appenders;
using LoggerApp.Contracts;
using LoggerApp.Layouts;
using LoggerApp.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerApp.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private List<IAppender> appenders;

        public CommandInterpreter()
        {
            this.appenders = new List<IAppender>();
        }

        public void CreateAppender(string input)
        {
            string[] appenderInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string appenderType = appenderInfo[0];
            string layoutType = appenderInfo[1];
            ReportLevel reportLevel = ReportLevel.INFO;

            try
            {
                if (appenderInfo.Length == 3)
                {
                reportLevel = Enum.Parse<ReportLevel>(appenderInfo[2]);
                }
            
                ILayout layout = LayoutFactory.Create(layoutType);
                IAppender appender = AppenderFactory.Create(appenderType, layout);
                appender.ReportLevel = reportLevel;
                appenders.Add(appender);
            }
            catch (Exception argEx)
            {
                Console.WriteLine(argEx.Message);
            }
        }

        public void CreateLog(string report)
        {
            string[] reportInfo = report.Split("|", StringSplitOptions.RemoveEmptyEntries);

            ReportLevel reportLevel = Enum.Parse<ReportLevel>(reportInfo[0]);
            string dateTime = reportInfo[1];
            string message = reportInfo[2];

            foreach (IAppender appender in appenders)
            {
                appender.Append(dateTime, reportLevel, message);
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine("Logger info");
            foreach (IAppender appender in appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}
