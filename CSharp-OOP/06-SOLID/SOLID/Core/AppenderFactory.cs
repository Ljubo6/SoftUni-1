using LoggerApp.Appenders;
using LoggerApp.Contracts;
using LoggerApp.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerApp.Core
{
    /// <summary>
    /// Represents a standard factory-pattern utility for generating new appenders.
    /// </summary>
    public static class AppenderFactory
    {
        /// <summary>
        /// Creates a new appender based on type provided. Throws ArgumentException when type is invalid in current context.
        /// </summary>
        /// <param name="appender"></param>
        /// <param name="layout"></param>
        /// <returns></returns>
        public static IAppender Create(string appenderType, ILayout layout)
        {
            switch (appenderType.ToLower())
            {
                case "consoleappender":
                    return new ConsoleAppender(layout);
                case "fileappender":
                    return new FileAppender(layout, new LogFile());
                default:
                    throw new ArgumentException("Invalid appender type provided!");
            }
        }
    }
}
