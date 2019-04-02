using NUnit.Framework;
using P02.ExtendedDatabase.Contracts;
using P02.ExtendedDatabase.Data;
using P02.ExtendedDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace P02.ExtendedDatabase.Tests
{
    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database db;
        private Person user;

        [SetUp]
        public void SetUp()
        {
            user = new Person(1, "Pesho");
            db = new Database(user);
        }

        [Test]
        public void Constructor_ShouldInitialiseNewDatabaseCorrectly()
        {
            int expectedCount = 1;
            int actualCount = db.Fetch().Length;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Constructor_ShouldThrowExceptionWithNoParameters()
        {
            Assert.Throws<InvalidOperationException>(() => db = new Database());
        }

        [Test]
        public void AddMethod_ShouldIncreaseCount()
        {
            var newUser = new Person(2, "Gosho");
            db.Add(newUser);
            int expectedCount = 2;
            int actualCount = db.Fetch().Length;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddMethod_ShouldThrowExceptionWithPresentId()
        {
            var newUser = new Person(1, "Gosho");
            Assert.Throws<InvalidOperationException>(() => db.Add(newUser));
        }

        [Test]
        public void AddMethod_ShouldThrowExceptionWithPresentUsername()
        {
            var newUser = new Person(2, "Pesho");
            Assert.Throws<InvalidOperationException>(() => db.Add(newUser));
        }

        [Test]
        public void AddMethod_ShouldThrowExceptionWhenDatabaseFull()
        {
            for (int i = 1; i <= 15; i++)
            {
                int id = 100 + i;
                string username = "user" + i.ToString();
                IPerson newlyGeneratedUser = new Person(id, username);
                db.Add(newlyGeneratedUser);
            }

            var rejectedUser = new Person(2, "Gosho");
            Assert.Throws<InvalidOperationException>(() => db.Add(rejectedUser));
        }

        [Test]
        public void RemoveMethod_ShouldDecreaseCount()
        {
            db.Remove();
            int expectedCount = 0;
            int actualCount = db.Fetch().Length;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RemoveMethod_ShouldThrowExceptionWhenDatabaseEmpty()
        {
            db.Remove();
            Assert.Throws<InvalidOperationException>(() => db.Remove());
        }

        [Test]
        public void FindById_ShouldReturnCorrectResult()
        {
            Assert.AreEqual(user, db.FindById(1));
        }

        [Test]
        public void FindById_ShouldThrowExpectionWithNonpresentId()
        {
            Assert.Throws<InvalidOperationException>(() => db.FindById(2));
        }

        [Test]
        public void FindById_ShouldThrowExpectionWithNegativeId()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => db.FindById(-1));
        }

        [Test]
        public void FindByUsername_ShouldReturnCorrectResult()
        {
            Assert.AreEqual(user, db.FindByUsername("Pesho"));
        }

        [Test]
        public void FindByUsername_ShouldThrowExceptionWithNonpresentUsername()
        {
            Assert.Throws<InvalidOperationException>(() => db.FindByUsername("Gosho"));
        }

        [Test]
        public void FindByUsername_ShouldThrowExceptionWithUsernameCasedDifferently()
        {
            Assert.Throws<InvalidOperationException>(() => db.FindByUsername("pesho"));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void FindByUsername_ShouldThrowExceptionWithInvalidUsername(string username)
        {
            Assert.Throws<ArgumentNullException>(() => db.FindByUsername(username));
        }

        [Test]
        public void FetchMethod_ShouldReturnCorrectCollection()
        {
            var newUser = new Person(2, "Gosho");
            db.Add(newUser);

            var expected = new IPerson[] { user, newUser };
            var actual = db.Fetch();
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
