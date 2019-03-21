using LoggerApp.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerApp.Contracts
{
    public interface IAppender
    {
        /// <summary>
        /// This method appends a message using the layout and the appender provided.
        /// Console appenders print directly on the console.
        /// File appenders appends a log to a file. It also tracks log size by summing ASCII codes of alphabetical charaters only.
        /// </summary>
        /// <param name="reportLevel">
        /// Report level threshold: It only appends messages with report level above or equal to this one.
        /// If no report level is provided, it is set to INFO.
        /// </param>
        void Append(string dateTime, ReportLevel reportLevel, string message);
        ReportLevel ReportLevel { get; set; }
        int MessagesAppended { get; set; }
    }
}
