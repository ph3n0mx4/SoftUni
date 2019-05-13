namespace Skeleton.Tests
{
    using FluentAssertions;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AxeTest
    {
        [Test]
        public void axeLosesDurabilityAfterAttack()
        {
            //Arrange
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);

            //Act
            axe.Attack(dummy);

            //Assert
            axe.DurabilityPoints.Should().Be(9);
        }
        
        [Test]
        public void attackWithBrokenAxe()
        {
            //Arrange
            Axe axe = new Axe(10, 0);
            Dummy dummy = new Dummy(10, 10);
            //axe.Attack(dummy);

            //Act
            //Assert
            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy),"");
        }
    }
}
