using _03BarracksFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace P03_BarraksWars.Core
{
    public class CommandInterpreter :  ICommandInterpreter
    {
        private IRepository repository;
        private IUnitFactory unitFactory;
        private string result;

        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }
        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            var type = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name.ToLower() == commandName + "command");

            var instance = Activator.CreateInstance(type, data, this.repository, this.unitFactory);
            var method = type.GetMethods(BindingFlags.Instance | BindingFlags.Public).First(x => x.Name == "Execute");
            var execute = method.Invoke(instance, new object[] { });
            this.result = execute.ToString();
            return execute;
        }

        
    }
}
