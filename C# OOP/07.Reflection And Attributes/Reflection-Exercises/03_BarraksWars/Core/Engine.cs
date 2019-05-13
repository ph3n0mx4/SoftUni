namespace _03BarracksFactory.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;
    using P03_BarraksWars.Core;

    class Engine : IRunnable
    {
        //private IRepository repository;
        //private IUnitFactory unitFactory;
        private ICommandInterpreter commandInterpreter;

        public Engine(IRepository repository, IUnitFactory unitFactory)
        {
            this.commandInterpreter = new CommandInterpreter(repository, unitFactory);
            //this.repository = repository;
            //this.unitFactory = unitFactory;
        }
        
        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    //string result = this.commandInterpreter.InterpretCommand(data, commandName).ToString();
                    Console.WriteLine(this.commandInterpreter.InterpretCommand(data, commandName).Execute());
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        //-------TODO: refactor for Problem 4

        //private string InterpredCommand(string[] data, string commandName)
        //{
        //    string result = string.Empty;
        //    var type = Assembly
        //        .GetExecutingAssembly()
        //        .GetTypes()
        //        .FirstOrDefault(x => x.Name.ToLower() == commandName+"command");

        //    var instance = Activator.CreateInstance(type, data, this.repository, this.unitFactory);
        //    var method = type.GetMethods(BindingFlags.Instance | BindingFlags.Public).First(x => x.Name == "Execute");

            
        //    result = method.Invoke(instance, new object[] { }).ToString();
                
            
        //    return result;
        //}


        //private string ReportCommand(string[] data)
        //{
        //    string output = this.repository.Statistics;
        //    return output;
        //}


        //private string AddUnitCommand(string[] data)
        //{
        //    string unitType = data[1];
        //    IUnit unitToAdd = this.unitFactory.CreateUnit(unitType);
        //    this.repository.AddUnit(unitToAdd);
        //    string output = unitType + " added!";
        //    return output;
        //}
    }
}
