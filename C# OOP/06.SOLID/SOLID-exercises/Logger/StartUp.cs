namespace LoggerEx
{
    using Appenders;
    using Appenders.Contracts;
    using Layouts;
    using Layouts.Contracts;
    using LoggerEx.Core;
    using LoggerEx.Core.Contract;
    using LoggerEx.Loggers.Enums;
    using Loggers;
    using Loggers.Contracts;
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            //ILayout simpleLayout = new SimpleLayout();
            //IAppender consoleAppender = new ConsoleAppender(simpleLayout);
            //ILogger logger = new Logger(consoleAppender);

            //logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            //logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");

            //

            //var simpleLayout = new SimpleLayout();
            //var consoleAppender = new ConsoleAppender(simpleLayout);

            //var file = new LogFile();
            //var fileAppender = new FileAppender(simpleLayout, file);

            //var logger = new Logger(consoleAppender, fileAppender);
            //logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            //logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");

            //

            //var xmlLayout = new XmlLayout();
            //var consoleAppender = new ConsoleAppender(xmlLayout);
            //var logger = new Logger(consoleAppender);

            //logger.Fatal("3/31/2015 5:23:54 PM", "mscorlib.dll does not respond");
            //logger.Critical("3/31/2015 5:23:54 PM", "No connection string found in App.config");

            //ILayout simpleLayout = new SimpleLayout();
            //IAppender consoleAppender = new ConsoleAppender(simpleLayout);
            //consoleAppender.ReportLevel = ReportLevel.Error;

            //ILayout fileLayout = new SimpleLayout();
            //IAppender fileAppender = new FileAppender(simpleLayout,new LogFile());
            //fileAppender.ReportLevel = ReportLevel.Error;

            //ILogger logger = new Logger(consoleAppender,fileAppender);

            //logger.Info("3/31/2015 5:33:07 PM", "Everything seems fine");
            //logger.Warning("3/31/2015 5:33:07 PM", "Warning: ping is too high - disconnect imminent");
            //logger.Error("3/31/2015 5:33:07 PM", "Error parsing request");
            //logger.Critical("3/31/2015 5:33:07 PM", "No connection string found in App.config");
            //logger.Fatal("3/31/2015 5:33:07 PM", "mscorlib.dll does not respond");
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            var engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}
