using System;
using NUnit.Framework;

namespace BankAccount.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldSetCorrectly()
        {
            var bank = new BankAccount("Gosho", 1000);
            Assert.AreEqual("Gosho", bank.Name);
            Assert.AreEqual(1000, bank.Balance);
        }

        [Test]
        [TestCase("Go")]
        [TestCase("GoshoGoshoGoshoGoshoGosho5")]
        public void PropertyNameThrowException(string name)
        {
            Assert.Throws<ArgumentException>(() => new BankAccount(name, 1000));
        }

        [Test]
        public void PropertyBalanceThrowException()
        {
            Assert.Throws<ArgumentException>(() => new BankAccount("Gosho", -1));
        }

        [Test]
        public void DepositMethodWorksCorrectly()
        {
            var bank = new BankAccount("Gosho", 1000);

            bank.Deposit(111.11m);

            Assert.AreEqual(1111.11, bank.Balance);
        }

        [Test]
        public void DepositMethodThrowsException()
        {
            var bank = new BankAccount("Gosho", 1000);

            bank.Deposit(111.11m);

            Assert.Throws<InvalidOperationException>(()=>bank.Deposit(-111.11m));
        }

        [Test]
        [TestCase(1001)]
        [TestCase(-1)]
        public void WithDrawMethodThrowsException(decimal amount)
        {
            var bank = new BankAccount("Gosho", 1000);

            Assert.Throws<InvalidOperationException>(() => bank.Withdraw(amount));
        }

        [Test]
        public void WithDrawMethodWorksCorrectly()
        {
            var bank = new BankAccount("Gosho", 1000);

            var amount = bank.Withdraw(100);

            Assert.AreEqual(100, amount);
            Assert.AreEqual(900, bank.Balance);
        }
    }
}