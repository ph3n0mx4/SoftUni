using NUnit.Framework;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Vehicles;
using System;

namespace Tests
{
    public class VehicleTests
    {
        private Vehicle van;

        [SetUp]
        public void Setup()
        {
            this.van = new Van();
        }

        [Test]
        public void LoadMethodWorksCorrectly()
        {
            //Arrange
            Product product = new Ram(2.57);
            //Act
            this.van.LoadProduct(product);
            int expectedCount = 1;
            //Assert
            Assert.AreEqual(expectedCount, this.van.Trunk.Count);
        }

        [Test]
        public void LoadMethodThrowException()
        {
            //Arrange
            Product product = new Ram(2.57);
            for (int i = 0; i < 20; i++)
            {
                this.van.LoadProduct(product);
            }
            int expectedCount = 20;
            //Act//Assert
            Assert.AreEqual(expectedCount, this.van.Trunk.Count);
            Assert.Throws<InvalidOperationException>(() => this.van.LoadProduct(product));
        }

        [Test]
        public void UnloadMethodWorksCorretcly()
        {
            //Arrange
            Product product = new Ram(2.57);
            for (int i = 0; i < 2; i++)
            {
                this.van.LoadProduct(product);
            }

            Product lastProdust = new HardDrive(5.55);
            this.van.LoadProduct(lastProdust);
            int expectedCount = 2;
            //Act
            Product result = this.van.Unload();
            //Assert
            Assert.AreEqual(expectedCount, this.van.Trunk.Count);
            Assert.AreEqual(lastProdust, result);
        }

        [Test]
        public void UnloadMethodThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => this.van.Unload());
        }

        [Test]
        public void IsEmptyReturnTrue()
        {
            //Act
            bool result = this.van.IsEmpty;
            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsEmptyReturnFalse()
        {
            //Arrange
            Product product = new Ram(2.22);
            this.van.LoadProduct(product);
            //Act
            bool result = this.van.IsEmpty;
            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsFullReturnTrue()
        {
            //Arrange
            Product product = new Ram(2.57);
            for (int i = 0; i < 20; i++)
            {
                this.van.LoadProduct(product);
            }
            //Act
            bool result = this.van.IsFull;
            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsFullReturnFalse()
        {
            //Arrange
            Product product = new Ram(2.22);
            this.van.LoadProduct(product);
            //Act
            bool result = this.van.IsFull;
            //Assert
            Assert.IsFalse(result);
        }
    }
}