namespace DatabaseExtend.Tests
{
    using FluentAssertions;
    using NUnit.Framework;
    using System.Collections;
    using System.Linq;
    using System.Collections.Generic;
    using System;

    [TestFixture]
    public class Tests
    {
        private Database people;
        private Person firstPerson;
        private Person secondPerson;
        [SetUp]
        public void Setup()
        {
            
            this.firstPerson = new Person("Ivan", 123);
            this.secondPerson = new Person("Pesho", 456);
        }

        [Test]
        public void ContructorShouldInitializeCorrect()
        {
            var expected = new Person[] {firstPerson,secondPerson};
            this.people = new Database(firstPerson, secondPerson);

            CollectionAssert.AreEqual(expected, this.people.Fetch());
        }

        [Test]
        public void AddMethodThrowExceptionForExictingUsername()
        {
            this.people = new Database(firstPerson, secondPerson);
            Assert.Throws<InvalidOperationException>(() => this.people.Add("Ivan", 123));
        }

        [Test]
        public void AddMethodThrowExceptionForExictingId()
        {
            this.people = new Database(firstPerson, secondPerson);
            Assert.Throws<InvalidOperationException>(() => this.people.Add("Ivan", 123));
        }

        [Test]
        public void FindByUsernameThrowExceptionForEmptyOrNullUsername()
        {
            this.people = new Database(firstPerson, secondPerson);
            Assert.Throws<ArgumentNullException>(() => this.people.FindByUsername(""));
        }

        [Test]
        public void FindByUsernameThrowExceptionForNotExcistingUsername()
        {
            this.people = new Database(firstPerson, secondPerson);
            Assert.Throws<InvalidOperationException>(() => this.people.FindByUsername("Gosho"));
        }

        [Test]
        public void FindByIDThrowExceptionForNotExcistingId()
        {
            this.people = new Database(firstPerson, secondPerson);
            Assert.Throws<InvalidOperationException>(() => this.people.FindById(122));
        }

        [Test]
        public void FindByIDThrowExceptionForNegativeId()
        {
            this.people = new Database(firstPerson, secondPerson);
            Assert.Throws<ArgumentOutOfRangeException>(() => this.people.FindById(-122));
        }
        [Test]
        public void AddMethodWorksCorrect()
        {
            //Arrange
            string username = "Ivo";
            long id = 3333;
            var a = new Person(username, id);
            this.people = new Database(firstPerson, secondPerson);
            
            this.people.Add(username, id);

            //Assert
            CollectionAssert.Contains(this.people.DatabaseElements, people.FindByUsername(username));
        }

    }
}