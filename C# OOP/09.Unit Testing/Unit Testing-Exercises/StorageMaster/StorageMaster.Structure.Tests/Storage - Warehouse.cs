using NUnit.Framework;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Storage;
using StorageMaster.Entities.Vehicles;
using System;
using System.Linq;
using System.Reflection;

namespace Tests
{
    public class StorageTests
    {
        private Storage warehouse;

        [SetUp]
        public void Setup()
        {
            //this.warehouse = new Warehouse("a");
        }

        [Test]
        public void GetVehicleMethodReturnVehicle()
        {
            this.warehouse = new Warehouse("a");
            //Arrange
            var garage = this.warehouse.Garage.ToList();
            var expectedVehicle = garage[1];
            //Act
            Vehicle vehicle = this.warehouse.GetVehicle(1);
            //Assert
            Assert.AreEqual(expectedVehicle, vehicle);
        }

        [Test]
        public void GetVehicleMethodThrowsExceptionForInvalidIndex()
        {
            this.warehouse = new Warehouse("a");
            //Assert//Act
            Assert.Throws<InvalidOperationException>(() => this.warehouse.GetVehicle(this.warehouse.GarageSlots));
        }

        [Test]
        public void GetVehicleMethodThrowsExceptionForEmptyIndex()
        {
            this.warehouse = new Warehouse("a");
            //Assert//Act
            Assert.Throws<InvalidOperationException>(() => this.warehouse.GetVehicle(5));
        }

        [Test]
        public void AddVehicleMethodWorksCorrectly()
        {
            this.warehouse = new Warehouse("a");
            //Arrange
            Vehicle newVehicle = new Truck();
            var method = typeof(Storage)
                .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(m => m.Name == "AddVehicle");
            int expectedIndex= 3;
            
            //Act
            int index = (int)method.Invoke(warehouse, new object[] { newVehicle });

            var expectedVehicle = this.warehouse.GetVehicle(expectedIndex);
            //Assert
            Assert.AreEqual(expectedIndex, index);
            Assert.AreEqual(expectedVehicle, newVehicle);
        }

        [Test]
        public void SendVehicleToMethodWorksCorrectly()
        {
            this.warehouse = new Warehouse("a");
            //Assert
            int garageSlot = 2;
            Storage deliveryLocation = new DistributionCenter("deliveryLocation");
            var vehicleToSend = this.warehouse.GetVehicle(garageSlot);
            int expectedIndex = 3;
            //Act
            int index = this.warehouse.SendVehicleTo(garageSlot, deliveryLocation);
            var expectedVehicle = deliveryLocation.GetVehicle(expectedIndex);
            //Assert
            Assert.Throws<InvalidOperationException>(() => this.warehouse.GetVehicle(garageSlot));
            Assert.AreEqual(expectedVehicle, vehicleToSend);
            Assert.AreEqual(expectedIndex, index);
        }

        [Test]
        public void SendVehicleToMethodThrowsExceptionOnGarageIsFull()
        {
            this.warehouse = new Warehouse("a");
            //Arrange
            Storage deliveryLocation = new DistributionCenter("deliveryLocation");
            var method = typeof(Storage)
                .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(m => m.Name == "AddVehicle");
            Vehicle newVehicle = new Truck();
            //Act
            for (int i = 0; i < 2; i++)
            {
                method.Invoke(deliveryLocation, new object[] { newVehicle });
            }
            //Assert
            Assert.Throws<InvalidOperationException>(() => this.warehouse.SendVehicleTo(2, deliveryLocation));
        }

        [Test]
        public void UnloadVehicleMethodWorksCorrectly()
        {
            this.warehouse = new Warehouse("a");
            //Arrange
            this.warehouse.GetVehicle(0).LoadProduct(new HardDrive(2.5));
            int expectedIndex = 2;//local =1, global =2 ???
            //Act
            int indexA =this.warehouse.UnloadVehicle(0);
            //Assert
            Assert.AreEqual(expectedIndex, indexA);
        }

        [Test]
        public void UnloadVehicleMethodThrowsExceptionOnGarageIsFull()
        {
            this.warehouse = new Warehouse("a");
            //Arrange
            for (int i = 0; i < 10; i++)
            {
                this.warehouse.GetVehicle(0).LoadProduct(new HardDrive(2.5));
                int index = this.warehouse.UnloadVehicle(0);
            }
            this.warehouse.GetVehicle(0).LoadProduct(new HardDrive(2.5));
            //Act//Assert
            Assert.Throws<InvalidOperationException>(() => this.warehouse.UnloadVehicle(0));
        }
    }
}