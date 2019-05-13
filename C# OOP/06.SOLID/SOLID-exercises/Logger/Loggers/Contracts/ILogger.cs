using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerEx.Loggers.Contracts
{
    public interface ILogger
    {
        void Error(string dateTime, string errorMessage);
        void Info(string dateTime, string infoMessage);
        void Warning(string dateTime, string warningMessage);
        void Critical(string dateTime, string criticalMessage);
        void Fatal(string dateTime, string fatalMessage);
    }
}
