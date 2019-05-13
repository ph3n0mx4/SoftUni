using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Database.Tests
{
    [TestFixture]
    public class Tests
    {
        private Database database;
        [SetUp]
        public void Setup()
        {
            this.database = new Database(1, 2, 3, 4, 5, 6);
        }

        [Test]
        public void AddMethodThrowExceptionOnFullDatabase()
        {
            //Act
            for (int i = 0; i < 10; i++)
            {
                database.Add(99);
            }
            //Assert
            Assert.Throws<InvalidOperationException>(()=>database.Add(0));
        }

        [Test]
        public void AddMethodAddsNumberToDatabase()
        {
            //Arrange
            int databaseCountBefore = database.DatabaseElements.Length;

            //Act
            this.database.Add(99);

            //Assert
            this.database.DatabaseElements.Length
                .Should().Be(databaseCountBefore + 1);
        }

        [Test]
        public void RemoveMethodThrowExceptionOnDatabase()
        {
            for (int i = 0; i < 6; i++)
            {
                this.database.Remove();
            }

            Assert.Throws<InvalidOperationException>(() => this.database.Remove());
        }

        [Test]
        public void RemoveMethodWorksCorrect()
        {
            //Arrange
            int databaseCountBefore = database.DatabaseElements.Length;

            //Act
            this.database.Remove();

            //Assert
            this.database.DatabaseElements.Length.Should().Be(databaseCountBefore - 1);
        }

        [Test]
        public void ContructorShouldInitializeCorrect()
        {
            //Assert
            this.database.DatabaseElements.Length.Should().Be(6);
        }

        [Test]
        [TestCase()]
        [TestCase(1,2,3,4,5,6,7,8,9,0,1,2,3,4,5,6,7)]
        public void ContructorThrowException(params int[] collection)
        {
            //Assert
            Assert.Throws<InvalidOperationException>(()=> this.database = new Database(collection));
        }

        [Test]
        public void PropertyDatabaseElementsSetCorrectly()
        {
            //Arrange
            var collections = new List<int>() { 1, 2, 3, 4, 5, 6 };
            //Assert
            CollectionAssert.AreEqual(collections, this.database.DatabaseElements);
        }

        [Test]
        public void PropertyDatabaseElementsGetCorrectly()
        {
            //Assert
            this.database.DatabaseElements.Length.Should().Be(6);
        }
    }
}