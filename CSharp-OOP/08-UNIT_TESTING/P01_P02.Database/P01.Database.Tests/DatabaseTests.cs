using NUnit.Framework;
using System;
using System.Linq;

namespace P01.Database.Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        private Database db;

        [SetUp]
        public void Setup()
        {
            db = new Database(1, 2, 3);
        }

        [Test]
        public void Constructor_ShouldReturnCorrectCount()
        {
            Assert.AreEqual(3, db.Fetch().Length);
        }

        [Test]
        [TestCase()]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17)]
        public void ConstructorShouldThrowExcepion(params int[] integers)
        {
            Assert.Throws<InvalidOperationException>(() => db = new Database(integers));
        }

        [Test]
        public void AddMethod_ShouldReturnCorrectCount()
        {
            this.db.Add(4);
            Assert.AreEqual(4, db.Fetch().Length);
        }

        [Test]
        public void AddMethod_ShouldThrowExceptionWhenDatabaseFull()
        {
            for (int i = 0; i < 13; i++)
            {
                this.db.Add(1);
            }

            Assert.Throws<InvalidOperationException>(() => this.db.Add(1));
        }

        [Test]
        public void RemoveMethod_ShouldWorkCorrectly()
        {
            this.db.Remove();
            var actual = this.db.Fetch().Last();

            Assert.AreEqual(2, this.db.Fetch().Length);
            Assert.AreEqual(2, actual);
        }

        [Test]
        public void RemoveMethod_ShouldThrowExceptionWhenDatabaseEmpty()
        {
            for (int i = 0; i < 3; i++)
            {
                this.db.Remove();
            }

            Assert.Throws<InvalidOperationException>(() => this.db.Remove());
        }

        [Test]
        public void FetchMethod_ShouldReturnCorrectCollection()
        {
            var expected = new int[] { 1, 2, 3 };
            var actual = this.db.Fetch();
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
