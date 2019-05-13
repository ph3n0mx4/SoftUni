using LoggerEx.Layouts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerEx.Appenders.Contracts
{
    public interface IAppenderFactory
    {
        IAppender CreateAppender(string type, ILayout layout);
    }
}
