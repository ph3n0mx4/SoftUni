using LoggerEx.Appenders;
using LoggerEx.Appenders.Contracts;
using LoggerEx.Core.Contract;
using LoggerEx.Layouts;
using LoggerEx.Layouts.Contracts;
using LoggerEx.Loggers.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerEx.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private ICollection<IAppender> appenders;
        private IAppenderFactory appenderFactory;
        private ILayoutFactory layoutFactory;

        public CommandInterpreter()
        {
            this.appenders = new List<IAppender>();
            this.appenderFactory = new AppenderFactory();
            this.layoutFactory = new LayoutFactory();
        }
        public void AddAppender(string[] args)
        {
            string typeAppender = args[0];
            string typeLayout = args[1];

            var reportLevel = ReportLevel.INFO;

            if(args.Length==3)
            {
                reportLevel = Enum.Parse<ReportLevel>(args[2]);
            }

            ILayout layout = this.layoutFactory.CreateLayout(typeLayout);
            IAppender appender = this.appenderFactory.CreateAppender(typeAppender, layout);
            appender.ReportLevel = reportLevel;

            appenders.Add(appender);
        }

        public void AddReport(string[] args)
        {
            string type = args[0];
            string dateTime = args[1];
            string message = args[2];
            var reportLevel = ReportLevel.INFO;
            reportLevel = Enum.Parse<ReportLevel>(type);

            //if (args.Length == 3)
            //{
            //    reportLevel = Enum.Parse<ReportLevel>(type);
            //}

            foreach (var appender in appenders)
            {
                appender.Append(dateTime, reportLevel, message);
            }
        }

        public void PrintInfo()
        {
            foreach (var ap in appenders)
            {
                Console.WriteLine(ap);
            }
        }
    }
}
