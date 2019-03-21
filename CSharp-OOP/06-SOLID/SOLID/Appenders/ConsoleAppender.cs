using LoggerApp.Contracts;
using LoggerApp.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerApp.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout) : base(layout)
        {
        }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if(reportLevel >= this.ReportLevel)
            {
                Console.WriteLine(string.Format(base.layout.Format, dateTime, reportLevel, message));
                this.MessagesAppended++;
            }
        }
    }
}
