using LoggerEx.Core.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoggerEx.Core
{
    public class Engine : IEngine
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter )
        {
            this.commandInterpreter = commandInterpreter;
        }
        public void Run()
        {
            int appendersCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < appendersCount; i++)
            {
                var appenderArgs = Console.ReadLine()
                    .Split()
                    .ToArray();

                this.commandInterpreter.AddAppender(appenderArgs);
            }

            var input = Console.ReadLine();

            while (input!="END")
            {
                var reportArgs = input
                    .Split("|")
                    .ToArray();

                this.commandInterpreter.AddReport(reportArgs);
                input = Console.ReadLine();
            }

            this.commandInterpreter.PrintInfo();
        }
    }
}
