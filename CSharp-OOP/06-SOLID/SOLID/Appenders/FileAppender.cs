using LoggerApp.Contracts;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using LoggerApp.Loggers;

namespace LoggerApp.Appenders
{
    public class FileAppender : Appender
    {
        private const string path = @"..\..\..\log.txt";
        private ILogFile logFile;

        public FileAppender(ILayout layout, ILogFile logFile) : base(layout)
        {
            this.logFile = logFile;
        }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if(reportLevel >= this.ReportLevel)
            {
                string logMessage = string.Format(layout.Format, dateTime, reportLevel, message) + "\n";
                File.AppendAllText(path, logMessage);
                this.MessagesAppended++;
                logFile.Write(logMessage);
            }
        }

        public override string ToString()
        {
            return base.ToString() + $", FileSize: {logFile.Size}";
        }
    }
}
