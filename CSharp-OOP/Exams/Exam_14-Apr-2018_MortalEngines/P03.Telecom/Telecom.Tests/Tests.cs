namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class Tests
    {
        private Phone phone;

        public object First { get; private set; }

        [SetUp]
        public void SetUp()
        {
            phone = new Phone("myPhone", "myModel");
        }

        [Test]
        public void Constructor_ShouldSetPropertiesCorrectly()
        {
            Assert.AreEqual("myPhone", phone.Make);
            Assert.AreEqual("myModel", phone.Model);
            Assert.AreEqual(0, phone.Count);
        }

        [Test]
        public void Make_ShouldThrowExceptionWithInvalidInput()
        {
            Assert.Throws<ArgumentException>(() => phone = new Phone(null, "myModel"));
            Assert.Throws<ArgumentException>(() => phone = new Phone(string.Empty, "myModel"));
        }

        [Test]
        public void Model_ShouldThrowExceptionWithInvalidInput()
        {
            Assert.Throws<ArgumentException>(() => phone = new Phone("myPhone", null));
            Assert.Throws<ArgumentException>(() => phone = new Phone("myPhone", string.Empty));
        }

        [Test]
        public void AddContact_ShouldWorkCorrectly()
        {

            phone.AddContact("Pesho", "0888-123-456");
            Assert.AreEqual(1, phone.Count);

            var phonebook = phone.GetType()
                .GetFields((BindingFlags)60)
                .FirstOrDefault(f => f.FieldType == typeof(Dictionary<string, string>));

            var actualName = ((Dictionary<string, string>)phonebook.GetValue(phone)).First().Key;
            var actualPhone = ((Dictionary<string, string>)phonebook.GetValue(phone)).First().Value;

            Assert.AreEqual("Pesho", actualName);
            Assert.AreEqual("0888-123-456", actualPhone);
        }

        [Test]
        public void AddContact_ShouldThrowExceptionWithPresentName()
        {
            phone.AddContact("Pesho", "0888-123-456");
            Assert.Throws<InvalidOperationException>(() => phone.AddContact("Pesho", "nomer"));
        }

        [Test]
        public void CallMethod_ShouldWorkCorrectly()
        {
            Assert.Throws<InvalidOperationException>(() => phone.Call("Pesho"));

            phone.AddContact("Pesho", "0888-123-456");
            var expected = "Calling Pesho - 0888-123-456...";
            Assert.That(expected == phone.Call("Pesho"));
        }
    }
}