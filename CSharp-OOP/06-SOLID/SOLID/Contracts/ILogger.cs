using LoggerApp.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerApp.Contracts
{
    public interface ILogger
    {
        void Info(string dateTime, string infoMessage);
        void Warning(string dateTime, string infoMessage);
        void Error(string dateTime, string errorMessage);
        void Critical(string dateTime, string infoMessage);
        void Fatal(string dateTime, string infoMessage);
    }
}
