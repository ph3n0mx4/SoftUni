using LoggerEx.Appenders.Contracts;
using LoggerEx.Layouts.Contracts;
using LoggerEx.Loggers.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerEx.Appenders
{
    public abstract class Appender : IAppender
    {
        private ILayout layout;

        public Appender(ILayout layout)
        {
            this.layout = layout;
        }
        public ReportLevel ReportLevel { get; set; }

        public int MessagesCount { get; set; }

        protected ILayout Layout => this.layout;

        public abstract void Append(string dateTime, ReportLevel reportLevel, string message);
        
    }
}
