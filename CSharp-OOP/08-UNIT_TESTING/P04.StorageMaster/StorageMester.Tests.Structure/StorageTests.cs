namespace StorageMester.Tests.Structure
{
    using NUnit.Framework;
    using StorageMaster.Entities.Products;
    using StorageMaster.Entities.Storage;
    using StorageMaster.Entities.Vehicles;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class StorageTests
    {
        private Type type;

        [SetUp]
        public void SetUp()
        {
            type = typeof(Storage);
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

            Assert.Throws<MemberAccessException>(() => 
            {
                var instance = (Vehicle)constructor.Invoke(new object[] { "storage", 10, 5, new Vehicle[] { new Semi() } });
            }, "Constructor should not allow the class to be initialised as it is abstract!");
        }

        [Test]
        public void Field_ShouldReturnCorrectCountOfFields()
        {
            var fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.AreEqual(5, fields.Length, "Count of fields mismatch!");
        }

        [Test]
        public void Field_ShouldHaveFieldsOfCorrectType()
        {
            var fieldsTypes = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Select(f => f.FieldType);
            var expectedTypes = new Type[] { typeof(Vehicle[]), typeof(List<Product>), typeof(string), typeof(int), typeof(int) };

            CollectionAssert.AreEquivalent(expectedTypes, fieldsTypes, "At least one field type does not match!");
        }

        [Test]
        public void Property_ShouldReturnCorrectCountOfProperties()
        {
            var props = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            Assert.AreEqual(6, props.Length, "Count of properties mismatch!");
        }

        [Test]
        public void Property_ShouldHaveCorrectNamesOfProperties()
        {
            var propsNames = type.GetProperties(BindingFlags.Instance | BindingFlags.Public).Select(p => p.Name);
            var expected = new string[] { "Name", "Capacity", "GarageSlots", "IsFull", "Garage", "Products" };
            CollectionAssert.AreEquivalent(expected, propsNames, "Names of class properties mismatch!");
        }

        [Test]
        public void Method_PublicMethods_ShouldReturnCorrectCountOfMethodsNamedAsExpected()
        {
            var publicMethods = type
                .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .Where(m => m.Name == "GetVehicle" || m.Name == "SendVehicleTo" || m.Name == "UnloadVehicle");
            Assert.AreEqual(3, publicMethods.Count(), "Public methods for loading and unloading count mismatch!");
        }

        [Test]
        public void Consts_AllSpecificStorages_ShouldSetPropertyValuesCorrectlyUponInitialisation()
        {
            var warehouse = new Warehouse("Warehouse");
            var automatedWarehouse = new AutomatedWarehouse("Automated Warehouse");
            var distributionCenter = new DistributionCenter("Distribution Center");

            //checks if capacity is set correctly
            Assert.That(warehouse.Capacity == 10, "Warehouse capacity is not set correctly!");
            Assert.That(automatedWarehouse.Capacity == 1, "Automated Warehouse capacity is not set correctly!");
            Assert.That(distributionCenter.Capacity == 2, "Distribution Center capacity is not set correctly!");

            //checks if garage slots are set correctly
            Assert.That(warehouse.GarageSlots == 10, "Warehouse garage slots count is not set correctly!");
            Assert.That(automatedWarehouse.GarageSlots == 2, "Automated Warehouse garage slots count is not set correctly!");
            Assert.That(distributionCenter.GarageSlots == 5, "Distribution Center garage slots count is not set correctly!");

            //checks if names are set correctly
            Assert.That(warehouse.Name == "Warehouse", "Warehouse name is not set correctly!");
            Assert.That(automatedWarehouse.Name == "Automated Warehouse", "Automated Warehouse name is not set correctly!");
            Assert.That(distributionCenter.Name == "Distribution Center", "Distribution Center name is not set correctly!");
        }

        [Test]
        public void Consts_ShouldReturnCorrectCountOfVehiclesAvailableUponInitialisation()
        {
            var warehouse = new Warehouse("Warehouse");
            var automatedWarehouse = new AutomatedWarehouse("Automated Warehouse");
            var distributionCenter = new DistributionCenter("Distribution Center");

            var warehouseVehiclesCount = warehouse.Garage.Where(x => x != null && x is Semi).ToArray().Count();
            var automatedWarehouseVehiclesCount = automatedWarehouse.Garage.Where(x => x != null && x is Truck).ToArray().Count();
            var distributionCenterVehiclesCount = distributionCenter.Garage.Where(x => x != null && x is Van).ToArray().Count();

            Assert.AreEqual(3, warehouseVehiclesCount, 
                "Warehouse is initialised with incorrect count and/or type of vehicles!");
            Assert.AreEqual(1, automatedWarehouseVehiclesCount,
                "Automated Warehouse is initialised with incorrect count and/or type of vehicles!");
            Assert.AreEqual(3, distributionCenterVehiclesCount,
                "Distribution Center is initialised with incorrect count and/or type of vehicles!");
        }
    }
}
