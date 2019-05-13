namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    public class Tests
    {
        [Test]
        public void ConstructorWorksCorrectly()
        {
            var phone = new Phone("MAKE", "MODEL");
            Assert.AreEqual("MAKE", phone.Make);
            Assert.AreEqual("MODEL", phone.Model);
        }

        [Test]
        public void MakeMethodThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Phone("", "MODEL"));
        }

        [Test]
        public void ModelMethodThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Phone("MAKE", ""));
        }

        [Test]
        public void CallMethodWorksCorrectly()
        {
            var phone = new Phone("MAKE", "MODEL");
            phone.AddContact("Ivan", "111");

            string a = phone.Call("Ivan");
            string b = $"Calling Ivan - 111...";
            Assert.AreEqual(b, a);
        }

        [Test]
        public void CallMethodThrowsException()
        {
            var phone = new Phone("MAKE", "MODEL");
            phone.AddContact("Ivan", "111");
            Assert.Throws<InvalidOperationException>(() => phone.Call("Gosho"));
        }

        [Test]
        public void AddMethodWorksCorrectly()
        {
            var phone = new Phone("MAKE", "MODEL");
            phone.AddContact("Ivan", "111");
            phone.AddContact("Gosho", "111");
            
            Assert.AreEqual(2, phone.Count);
        }

        [Test]
        public void AddMethodThrowsException()
        {
            var phone = new Phone("MAKE", "MODEL");
            phone.AddContact("Ivan", "111");
            Assert.Throws<InvalidOperationException>(() => phone.AddContact("Ivan", "111"));
        }

        [Test]
        public void CountMethodWorksCorrectly()
        {
            var phone = new Phone("MAKE", "MODEL");
            phone.AddContact("Ivan", "111");
            phone.AddContact("Gosho2", "111");
            phone.AddContact("Gosho", "111");
            phone.AddContact("Pesho", "111");

            Assert.AreEqual(4, phone.Count);
        }
    }
}