using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;

namespace AnimalCentre.Tests
{
    

    public class Tests
    {
        private static readonly Assembly ProjectAssembly = typeof(StartUp).Assembly;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var animalParam = new object[]
        {
            "Molly", 15, 20, 10
        };

            var animal = Activator.CreateInstance(GetType("Pig"), animalParam);

            var fitness = Activator.CreateInstance(GetType("Fitness"));

            var fitnessObject = new object[]
            {
            animal, 5
            };
            fitness.GetType().GetMethod("DoService").Invoke(fitness, fitnessObject);
            Assert.That(GetType("Animal")
                .GetProperty("Energy", (BindingFlags)62)
                .GetValue(animal), Is.EqualTo(25), "Energy is not getting higher");

            Assert.That(GetType("Animal")
                .GetProperty("Happiness", (BindingFlags)62)
                .GetValue(animal), Is.EqualTo(17), "Happiness is not getting lower");
           
        }

        private static Type GetType(string name)
        {
            var type = ProjectAssembly
                .GetTypes()
                .FirstOrDefault(t => t.Name == name);

            return type;
        }
    }
}