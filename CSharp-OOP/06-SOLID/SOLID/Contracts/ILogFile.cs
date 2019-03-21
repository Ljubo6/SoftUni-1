using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerApp.Contracts
{
    public interface ILogFile
    {
        long Size { get; }
        void Write(string logMessage);
    }
}
