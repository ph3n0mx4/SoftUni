namespace _03BarracksFactory.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Assembly assembly = typeof(AppEntryPoint).Assembly;
            var a = assembly.GetTypes().First(x => x.Name == unitType);

            //var typeClass = Type.GetType($"_03BarracksFactory.Models.Units.{unitType}");
            var instance = Activator.CreateInstance(a);
            return (IUnit)instance;
            //TODO: implement for Problem 3
            //throw new NotImplementedException();
        }
    }
}
