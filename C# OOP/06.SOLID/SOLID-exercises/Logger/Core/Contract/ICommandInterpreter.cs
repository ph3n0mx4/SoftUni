using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerEx.Core.Contract
{
    public interface ICommandInterpreter
    {
        void AddAppender(string[] args);

        void AddReport(string[] args);

        void PrintInfo();
    }
}
