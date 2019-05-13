namespace LoggerEx.Appenders
{
    using LoggerEx.Appenders.Contracts;
    using LoggerEx.Layouts.Contracts;
    using LoggerEx.Loggers.Contracts;
    using LoggerEx.Loggers.Enums;
    using System;
    using System.IO;

    public class FileAppender : Appender
    {
        private const string Path = @"..\..\..\log.txt";
        private ILogFile logFile;

        public FileAppender(ILayout layout, ILogFile logFile) : base(layout)
        {
            this.logFile = logFile;
        }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (this.ReportLevel <= reportLevel)
            {
                string content = string.Format(base.Layout.Format, dateTime, reportLevel, message) + Environment.NewLine;
                File.AppendAllText(Path, content);
                this.MessagesCount++;
            }
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {base.ReportLevel}, Messages appended: {MessagesCount}, File size: {this.logFile.Size}";
        }
    }
}
