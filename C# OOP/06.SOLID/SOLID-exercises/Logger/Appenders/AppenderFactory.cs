using LoggerEx.Appenders.Contracts;
using LoggerEx.Layouts.Contracts;
using LoggerEx.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerEx.Appenders
{
    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout)
        {
            string typeAsLower = type.ToLower();

            switch (typeAsLower)
            {
                case "consoleappender":
                    return new ConsoleAppender(layout);
                case "fileappender":
                    return new FileAppender(layout, new LogFile());
                default:
                    throw new ArgumentException("invalid appender type");
            }
        }
    }
}
