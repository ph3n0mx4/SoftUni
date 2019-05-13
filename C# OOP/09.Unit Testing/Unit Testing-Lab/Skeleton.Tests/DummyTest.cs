namespace Skeleton.Tests
{
    using FluentAssertions;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Text;

    [TestFixture]
    public class DummyTest
    {
        [Test]
        public void DummyLoseHealtOnAttack()
        {
            //Arrange
            Dummy dummy = new Dummy(10, 10);

            //Act
            dummy.TakeAttack(4);

            //Assert
            dummy.Health.Should().Be(6);
        }

        [Test]
        public void DeadDummyThrowsExceptionOnAttacked()
        {
            //Arrange
            Dummy dummy = new Dummy(0, 10);

            //Act
            //Assert
            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(1));
        }

        [Test]
        public void DeadDummyCanGiveXP()
        {
            //Arrange
            Dummy dummy = new Dummy(0, 10);

            //Act
            int experience = dummy.GiveExperience();

            //Assert
            experience.Should().Be(10);
        }

        [Test]
        public void AliveDummyCantGiveXP()
        {
            //Arrange
            Dummy dummy = new Dummy(1, 10);

            //Act
            //Assert
            Assert.Throws<InvalidOperationException>(() =>dummy.GiveExperience());
        }
    }
}
