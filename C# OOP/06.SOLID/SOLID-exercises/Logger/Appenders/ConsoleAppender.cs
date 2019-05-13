using LoggerEx.Appenders.Contracts;
using LoggerEx.Layouts.Contracts;
using LoggerEx.Loggers.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerEx.Appenders 
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout) 
            : base(layout)
        {
        }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if(this.ReportLevel<=reportLevel)
            {
                Console.WriteLine(string.Format(base.Layout.Format, dateTime, reportLevel, message));
                this.MessagesCount++;
            }
            
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {base.ReportLevel}, Messages appended: {MessagesCount}";
        }
    }
}
