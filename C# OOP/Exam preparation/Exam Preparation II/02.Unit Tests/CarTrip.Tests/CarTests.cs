using CarTrip;
using NUnit.Framework;
using System;

namespace CarTrip.Tests
{
    
    public class Tests
    {
        [Test]
        public void ConstructorWorksCorrectly()
        {
            var car = new Car("BMW", 50, 20, 7);
            Assert.AreEqual("BMW", car.Model);
            Assert.AreEqual(50, car.TankCapacity);
            Assert.AreEqual(20, car.FuelAmount);
            Assert.AreEqual(7, car.FuelConsumptionPerKm);
        }

        [Test]
        public void ModelThrowsException()
        {
            //var car = new Car(" ", 50, 20, 7);
            Assert.Throws<ArgumentException>(()=>new Car(" ", 50, 20, 7));
            Assert.Throws<ArgumentException>(()=>new Car(null, 50, 20, 7));
            Assert.Throws<ArgumentException>(()=>new Car("", 50, 20, 7));
        }

        [Test]
        public void FuelAmountThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Car("BMW", 50, 51, 7));
        }

        [Test]
        public void FuelConsumptionPerKmThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Car("BMW", 50, 20, -7));
        }

        [Test]
        public void DriveMethodThrowsException()
        {
            var car = new Car("BMW", 50, 20, 5.5);

            Assert.Throws<InvalidOperationException>(() => car.Drive(4));
        }

        [Test]
        public void DriveMethodWorksCorrectly()
        {
            var car = new Car("BMW", 50, 20, 5);

            string a = car.Drive(4);

            Assert.AreEqual(0, car.FuelAmount);
            Assert.AreEqual("Have a nice trip", a);
        }

        [Test]
        public void RefuelMethodThrowsException()
        {
            var car = new Car("BMW", 50, 20, 5);

            Assert.Throws<InvalidOperationException>(() => car.Refuel(31));
        }

        [Test]
        public void RefuelMethodWorksCorrectly()
        {
            var car = new Car("BMW", 50, 20, 5);

            car.Refuel(20);

            Assert.AreEqual(40, car.FuelAmount);
        }
    }
}