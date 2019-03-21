using LoggerApp.Contracts;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerApp.Loggers
{
    public class Logger : ILogger
    {
        private IAppender consoleAppender;
        private IAppender fileAppender;

        public Logger(IAppender consoleAppender)
        {
            this.consoleAppender = consoleAppender;
        }

        public Logger(IAppender consoleAppender, IAppender fileAppender)
        {
            this.consoleAppender = consoleAppender;
            this.fileAppender = fileAppender;
        }

        public void Info(string dateTime, string message)
        {
            Logging(dateTime, Enum.Parse<ReportLevel>(MethodBase.GetCurrentMethod().Name), message);
        }

        public void Warning(string dateTime, string message)
        {
            Logging(dateTime, Enum.Parse<ReportLevel>(MethodBase.GetCurrentMethod().Name), message);
        }

        public void Error(string dateTime, string message)
        {
            Logging(dateTime, Enum.Parse<ReportLevel>(MethodBase.GetCurrentMethod().Name), message);
        }

        public void Critical(string dateTime, string message)
        {
            Logging(dateTime, Enum.Parse<ReportLevel>(MethodBase.GetCurrentMethod().Name), message);
        }

        public void Fatal(string dateTime, string message)
        {
            Logging(dateTime, Enum.Parse<ReportLevel>(MethodBase.GetCurrentMethod().Name), message);
        }

        private void Logging(string dateTime, ReportLevel reportLevel, string message)
        {
            consoleAppender?.Append(dateTime, reportLevel, message);
            fileAppender?.Append(dateTime, reportLevel, message);
        }
    }
}
