using NUnit.Framework;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace StorageMester.Tests.Structure
{
    [TestFixture]
    class VehicleTests
    {
        private Type type;

        [SetUp]
        public void SetUp()
        {
            type = typeof(Vehicle);
        }

        [Test]
        public void Constructor_ShouldReturnCorrectCountOfConstructors()
        {
            var constructors = type.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            Assert.IsTrue(constructors.Length == 1, "The type has no constructor!");
        }

        [Test]
        public void Constructor_ShouldNotAllowInitialisation()
        {
            var constructor = type.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public).First();

            Assert.Throws<MemberAccessException>(() => { var instance = (Vehicle)constructor.Invoke(new object[] { 10 }); },
                "Constructor should not allow the class to be initialised as it is abstract!");
        }

        [Test]
        public void Field_ShouldReturnCorrectCountOfFields()
        {
            var fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.AreEqual(2, fields.Length, "Count of fields mismatch!");
        }

        [Test]
        public void Field_ShouldHaveFieldsOfCorrectType()
        {
            var fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            var firstField = fields.First();
            var secondField = fields.Last();

            Assert.That(firstField.FieldType == typeof(List<Product>), "First field is not of expected type!");
            Assert.That(secondField.FieldType == typeof(int), "Second field is not of expected type!");
        }

        [Test]
        public void Property_ShouldReturnCorrectCountOfProperties()
        {
            var props = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            Assert.AreEqual(4, props.Length, "Count of properties mismatch!");
        }

        [Test]
        public void Property_ShouldHaveCorrectNamesOfProperties()
        {
            var propsNames = type.GetProperties(BindingFlags.Instance | BindingFlags.Public).Select(p => p.Name);
            var expected = new string[] { "Capacity", "Trunk", "IsFull", "IsEmpty" };
            CollectionAssert.AreEqual(expected, propsNames, "Names of class properties mismatch!");
        }

        [Test]
        public void Method_PrivateSetters_ShouldReturnCorrectCount()
        {
            var setters = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic).Where(m => m.Name.StartsWith("set"));
            Assert.AreEqual(0, setters.Count(), "Private Setters count mismatch!");
        }

        [Test]
        public void Method_PublicGetters_ShouldReturnCorrectCount()
        {
            var getters = type.GetMethods(BindingFlags.Instance | BindingFlags.Public).Where(m => m.Name.StartsWith("get"));
            Assert.AreEqual(4, getters.Count(), "Public Getters count mismatch!");
        }

        [Test]
        public void Method_LoadAndUnload_ShouldReturnCorrectCount()
        {
            var methods = type
                .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .Where(m => m.Name == "LoadProduct" || m.Name == "Unload");
            Assert.AreEqual(2, methods.Count(), "Public methods for loading and unloading count mismatch!");
        }

        [Test]
        public void Consts_AllSpecificVehicles_ShouldSetConstsAndPropertyValuesCorrectlyUponInitialisation()
        {
            //TODO
            throw new NotImplementedException();
        }
    }
}
