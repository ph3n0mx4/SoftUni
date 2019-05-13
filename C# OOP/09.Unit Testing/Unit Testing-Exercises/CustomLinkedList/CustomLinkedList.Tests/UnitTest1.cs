namespace CustomLinkedList.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class Tests
    {
        private DynamicList<int> list;
        [SetUp]
        public void Setup()
        {
            list = new DynamicList<int>();
        }

        [Test]
        public void ContructorShouldBeSetCountToZero()
        {
            Assert.That(list.Count, Is.EqualTo(0));
        }

        [Test]
        public void IndexAccessShouldReturn()
        {
            this.list.Add(13);

            Assert.That(list[0], Is.EqualTo(13));
        }

        [Test]
        public void IndexAccessShouldSetValue()
        {
            this.list.Add(13);
            this.list[0]=5;

            Assert.That(list[0], Is.EqualTo(5));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(1)]
        public void IndexOperatorThrowExceptionWhenGettingOnWrongIndex(int index)
        {
            this.list.Add(13);

            int a ;
            Assert.Throws<ArgumentOutOfRangeException>(()=>a= this.list[index]);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(1)]
        public void IndexOperatorThrowExceptionWhenSettingOnWrongIndex(int index)
        {
            //Act
            this.list.Add(13);
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>this.list[index]=100);
        }

        [Test]
        public void AddMethodShouldAddElement()
        {
            //Act
            this.list.Add(15);
            this.list.Add(99);
            this.list.Add(42);
            //Assert
            Assert.AreEqual(3, this.list.Count);
        }

        [Test]
        public void RemoveAtMethodShouldRemoveEntityCorrectly()
        {
            //Arrange
            for (int i = 0; i < 3; i++)
            {
                this.list.Add(i);
            }

            var tempList = new DynamicList<int>();
            tempList.Add(0);
            tempList.Add(2);
            //Act
            this.list.RemoveAt(1);
            //Assert
            for (int i = 0; i < this.list.Count; i++)
            {
                Assert.AreEqual(tempList[i], this.list[i]);
            }
        }

        [Test]
        public void RemoveAtMethodShouldReturnEntityCorrectly()
        {
            //Arrange
            for (int i = 0; i < 3; i++)
            {
                this.list.Add(i);
            }
            
            //Act
            int removedEntity = this.list.RemoveAt(1);
            //Assert
            
            Assert.AreEqual(1, removedEntity);
        }

        [Test]
        public void RemoveAtMethodThrowExceptionForWrongIndex()
        {
            //Arrange
            for (int i = 0; i < 3; i++)
            {
                this.list.Add(i);
            }
            //Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => this.list.RemoveAt(3));
        }

        [Test]
        public void RemoveAtMethodShouldReturnDecreaseCount()
        {
            //Arrange
            for (int i = 0; i < 3; i++)
            {
                this.list.Add(i);
            }
            int expectedCount = this.list.Count - 1;
            //Act
            this.list.RemoveAt(1);
            //Assert
            Assert.AreEqual(expectedCount, this.list.Count);
        }

        [Test]
        public void RemoveMethodShouldReturnIndexOnExistingEntity()
        {
            //Arrange
            for (int i = 0; i < 3; i++)
            {
                this.list.Add(i);
            }
            //Act
            int index = this.list.Remove(1);
            //Assert
            Assert.AreEqual(1, index);
        }

        [Test]
        public void RemoveMethodShouldReturnIndexOnNonExistingEntity()
        {
            //Arrange
            for (int i = 0; i < 3; i++)
            {
                this.list.Add(i);
            }
            //Act
            int index = this.list.Remove(3);
            //Assert
            Assert.AreEqual(-1, index);
        }

        [Test]
        public void RemoveExistingItemShouldDecreaseTheCount()
        {
            //Arrange
            for (int i = 0; i < 3; i++)
            {
                this.list.Add(i);
            }
            int expectedCount = this.list.Count - 1;
            //Act
            this.list.Remove(1);
            //Assert
            Assert.AreEqual(expectedCount, this.list.Count);
        }

        [Test]
        public void IndexOfMethodreturnIndexFromExistingEntity()
        {
            //Arrange
            this.list.Add(33);
            this.list.Add(1);
            this.list.Add(5);
            //Act
            int index = this.list.IndexOf(1);
            //Assert
            Assert.AreEqual(1, index);
        }

        [Test]
        public void IndexOfMethodreturnIndexFromNonExistingEntity()
        {
            //Arrange
            this.list.Add(33);
            this.list.Add(1);
            this.list.Add(5);
            //Act
            int index = this.list.IndexOf(2);
            //Assert
            Assert.AreEqual(-1, index);
        }

        [Test]
        public void ContainsMethodShouldReturnTrueForExistingItem()
        {
            //Arrange
            this.list.Add(33);
            this.list.Add(1);
            this.list.Add(5);
            bool expected = true;
            //Act
            bool found = this.list.Contains(1);
            //Assert
            Assert.AreEqual(expected, found);
        }

        [Test]
        public void ContainsMethodShouldReturnFalseForNonExistingItem()
        {
            //Arrange
            this.list.Add(33);
            this.list.Add(1);
            this.list.Add(5);
            bool expected = false;
            //Act
            bool found = this.list.Contains(2);
            //Assert
            Assert.AreEqual(expected, found);
        }
    }
}