using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LoggerApp.Contracts;

namespace LoggerApp.Loggers
{
    public class LogFile : ILogFile
    {
        public long Size { get; private set; }

        public void Write(string logMessage)
        {
            this.Size += logMessage.Where(x => char.IsLetter(x)).Sum(x => x);
        }

    }
}
