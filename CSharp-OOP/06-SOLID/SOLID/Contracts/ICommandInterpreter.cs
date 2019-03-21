using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerApp.Contracts
{
    public interface ICommandInterpreter
    {
        void CreateAppender(string input);
        void CreateLog(string report);
        void PrintInfo();
    }
}
