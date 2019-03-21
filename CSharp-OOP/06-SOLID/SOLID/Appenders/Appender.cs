using LoggerApp.Contracts;
using LoggerApp.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerApp.Appenders
{
    public abstract class Appender : IAppender
    {
        protected ILayout layout;

        protected Appender(ILayout layout)
        {
            this.layout = layout;
        }

        public ReportLevel ReportLevel { get; set; }
        public int MessagesAppended { get; set; }

        public abstract void Append(string dateTime, ReportLevel reportLevel, string message);

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.layout.GetType().Name}, " +
                $"Report level: {this.ReportLevel}, Messages appended: {this.MessagesAppended}";
        }
    }
}
