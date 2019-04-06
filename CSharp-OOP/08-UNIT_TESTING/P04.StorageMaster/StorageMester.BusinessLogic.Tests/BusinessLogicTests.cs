namespace StorageMester.BusinessLogic.Tests
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
    public class BusinessLogicTests
    {
        private StorageMaster.Core.StorageMaster storageMaster;

        [SetUp]
        public void Setup()
        {
            storageMaster = new StorageMaster.Core.StorageMaster();
        }

        [Test]
        public void AddProduct_ShouldAddCorrectly()
        {
            storageMaster.AddProduct("Ram", 49.99);
            storageMaster.AddProduct("Gpu", 199.99);
            storageMaster.AddProduct("HardDrive", 99.99);
            storageMaster.AddProduct("SolidStateDrive", 149.99);

            var storage = storageMaster
                .GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(s => s.FieldType == typeof(Dictionary<string, Stack<Product>>));

            var storageValue = (Dictionary<string, Stack<Product>>)storage.GetValue(storageMaster);
            var addedProductsCount = storageValue.SelectMany(x => x.Value).Count();
            var addedProductsNames = storageValue.Select(x => x.Key.ToString());
            var expected = new string[] { "Ram", "Gpu", "HardDrive", "SolidStateDrive" };

            Assert.AreEqual(4, addedProductsCount);
            CollectionAssert.AreEquivalent(expected, addedProductsNames);
        }

        [Test]
        public void AddProduct_ShouldReturnCorrectOutputString()
        {
            var stringOutput = storageMaster.AddProduct("Ram", 49.99);
            Assert.That(stringOutput == "Added Ram to pool");
        }

        [Test]
        public void AddProduct_ShouldThrowExceptionWithInvalidProductType()
        {
            Assert.Throws<InvalidOperationException>(() => storageMaster.AddProduct("Keyboard", 10));
        }

        [Test]
        public void RegisterStorage_ShouldRegisterCorrectly()
        {
            storageMaster.RegisterStorage("Warehouse", "Warehouse");
            storageMaster.RegisterStorage("AutomatedWarehouse", "Automated Warehouse");
            storageMaster.RegisterStorage("DistributionCenter", "Distribution Center");


            var storage = storageMaster
                .GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(s => s.FieldType == typeof(Dictionary<string, Storage>));

            var storageValue = (Dictionary<string, Storage>)storage.GetValue(storageMaster);
            var addedStoragesCount = storageValue.Count;
            var addedStoragesNames = storageValue.Select(x => x.Key.ToString());
            var expected = new string[] { "Warehouse", "Automated Warehouse", "Distribution Center" };

            Assert.AreEqual(3, addedStoragesCount);
            CollectionAssert.AreEquivalent(expected, addedStoragesNames, "Registered storages types mismatch!");
        }

        [Test]
        public void RegisterStorage_ShouldreturnCorrectOutputString()
        {
            var stringOutput = storageMaster.RegisterStorage("Warehouse", "Warehouse");
            Assert.That(stringOutput == "Registered Warehouse", "Output message is incorrect!");
        }

        [Test]
        public void RegisterStorage_ShouldThrowExceptionWithInvalidProductType()
        {
            Assert.Throws<InvalidOperationException>(() => storageMaster.RegisterStorage("Shop", "Shop"),
                "Registering storage of invalid type was allowed!");
        }

        [Test]
        [TestCase(0)]
        public void SelectVehicleMethod_ShouldReturnCorrectVehicleWhenIndexInRange(int garageSlot)
        {
            storageMaster.RegisterStorage("Warehouse", "Warehouse");
            storageMaster.SelectVehicle("Warehouse", 0);

            var vehicleValue = storageMaster
                .GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(s => s.FieldType == typeof(Vehicle));

            var vehicle = vehicleValue.GetValue(storageMaster);

            Assert.IsInstanceOf<Semi>(vehicle, "Selected vehicle is not of correct type!");

        }

        [Test]
        public void SelectVehicleMethod_ShouldReturnCorrectOutputString()
        {
            storageMaster.RegisterStorage("Warehouse", "Warehouse");
            var outputString = storageMaster.SelectVehicle("Warehouse", 0);
            Assert.That(outputString == "Selected Semi", "Output message is incorrect!");
        }

        [Test]
        public void SelectVehicleMethod_ShouldThrowExceptionWhenIndexOutOfRange()
        {
            storageMaster.RegisterStorage("Warehouse", "Warehouse");
            storageMaster.RegisterStorage("AutomatedWarehouse", "Automated Warehouse");
            storageMaster.RegisterStorage("DistributionCenter", "Distribution Center");

            Assert.Throws<InvalidOperationException>(() => storageMaster.SelectVehicle("Warehouse", 100),
                "The method returns a vehicle which is on an index out of range!");
            Assert.Throws<InvalidOperationException>(() => storageMaster.SelectVehicle("Automated Warehouse", 100),
                "The method returns a vehicle which is on an index out of range!");
            Assert.Throws<InvalidOperationException>(() => storageMaster.SelectVehicle("Distribution Center", 100),
                "The method returns a vehicle which is on an index out of range!");
        }

        [Test]
        public void SelectVehicleMethod_ShouldThrowExceptionWithNoVehicleAtIndex()
        {
            storageMaster.RegisterStorage("Warehouse", "Warehouse");
            storageMaster.RegisterStorage("AutomatedWarehouse", "Automated Warehouse");
            storageMaster.RegisterStorage("DistributionCenter", "Distribution Center");

            Assert.Throws<InvalidOperationException>(() => storageMaster.SelectVehicle("Warehouse", 3),
                "The method returns a vehicle which is on an index out of range!");
            Assert.Throws<InvalidOperationException>(() => storageMaster.SelectVehicle("Automated Warehouse", 1),
                "The method returns a vehicle which is on an index out of range!");
            Assert.Throws<InvalidOperationException>(() => storageMaster.SelectVehicle("Distribution Center", 3),
                "The method returns a vehicle which is on an index out of range!");
        }

        [Test]
        public void LoadVehicle_ShouldReturnCorrectOutput()
        {
            storageMaster.AddProduct("Ram", 100);
            storageMaster.AddProduct("Ram", 10);
            storageMaster.AddProduct("Ram", 1);

            storageMaster.RegisterStorage("Warehouse", "Warehouse");
            storageMaster.SelectVehicle("Warehouse", 0);
            var actualOutput = storageMaster.LoadVehicle(new string[] { "Ram", "Ram", "Ram" });

            string expectedOutput = $"Loaded 3/3 products into Semi";
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void LoadVehicle_ShouldNotLoadProductsWhenVehicleFull()
        {
            storageMaster.RegisterStorage("Warehouse", "Warehouse");
            storageMaster.SelectVehicle("Warehouse", 0);

            for (int i = 0; i < 11; i++)
            {
                storageMaster.AddProduct("HardDrive", 100);
                storageMaster.LoadVehicle(new string[] { "HardDrive" });
            }

            var vehicleValue = storageMaster
                .GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(s => s.FieldType == typeof(Vehicle));

            var vehicle = (Vehicle)vehicleValue.GetValue(storageMaster);

            //Semi Capacity: 10, HDD Weight: 1 => Assert that only 10 HDDs were loaded 
            Assert.AreEqual(10, vehicle.Trunk.Count, "Loaded products count mismatch!");
        }

        [Test]
        public void LoadVehicle_ShouldThrowExceptionWhenLoadingUnvailableProduct()
        {
            storageMaster.RegisterStorage("Warehouse", "Warehouse");
            storageMaster.SelectVehicle("Warehouse", 0);

            Assert.Throws<InvalidOperationException>(() => storageMaster.LoadVehicle(new string[] { "HardDrive" }),
                "The method loads an unavailable product!");
        }

        [Test]
        public void SendVehicleToMethod_ShouldReturnCorrectOutput()
        {
            storageMaster.RegisterStorage("Warehouse", "Warehouse");
            storageMaster.RegisterStorage("AutomatedWarehouse", "Automated Warehouse");

            var actualOutput = storageMaster.SendVehicleTo("Warehouse", 0, "Automated Warehouse");
            var expectedOutput = "Sent Semi to Automated Warehouse (slot 1)";

            Assert.AreEqual(expectedOutput, actualOutput, "Returned output mismatch!");
        }

        [Test]
        public void SendVehicleToMethod_StoragesShouldHaveCorrectCountOfVehiclesInGarage()
        {
            storageMaster.RegisterStorage("Warehouse", "Warehouse");
            storageMaster.RegisterStorage("AutomatedWarehouse", "Automated Warehouse");
            storageMaster.SendVehicleTo("Warehouse", 0, "Automated Warehouse");

            var storage = storageMaster
                .GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(s => s.FieldType == typeof(Dictionary<string, Storage>));

            var storageValue = (Dictionary<string, Storage>)storage.GetValue(storageMaster);

            var warehouseVehiclesCount = storageValue["Warehouse"].Garage.Where(x => x != null).Count();
            var automatedWarehouseVehiclesCount = storageValue["Automated Warehouse"].Garage.Where(x => x!=null).Count();

            Assert.AreEqual(2, warehouseVehiclesCount, "Count of vehicles in garage after sending one away mismatch!");
            Assert.AreEqual(2, automatedWarehouseVehiclesCount, "Count of vehicles in garage after accommodating one mismatch!");
        }

        [Test]
        public void SendVehicleToMethod_ShouldThrowExceptionWithInvalidSource()
        {
            storageMaster.RegisterStorage("Warehouse", "Warehouse");
            Assert.Throws<InvalidOperationException>(() => storageMaster.SendVehicleTo("Automated Warehouse", 0, "Warehouse"));
        }

        [Test]
        public void SendVehicleToMethod_ShouldThrowExceptionWithInvalidDestination()
        {
            storageMaster.RegisterStorage("Warehouse", "Warehouse");
            Assert.Throws<InvalidOperationException>(() => storageMaster.SendVehicleTo("Warehouse", 0, "Automated Warehouse"));
        }

        [Test]
        public void SendVehicleToMethod_ShouldThrowExceptionWhenNoFreeSlotsInDestinationGarage()
        {
            storageMaster.RegisterStorage("Warehouse", "Warehouse");
            storageMaster.RegisterStorage("AutomatedWarehouse", "Automated Warehouse");
            storageMaster.SendVehicleTo("Warehouse", 0, "Automated Warehouse");

            Assert.Throws<InvalidOperationException>(() => storageMaster.SendVehicleTo("Warehouse", 1, "Automated Warehouse"));
        }

        [Test]
        public void UnloadVehicle_ShouldReturnCorrectOutputWhenProductsWeightExceedsStorageCapacity()
        {
            storageMaster.RegisterStorage("Warehouse", "Warehouse");
            storageMaster.RegisterStorage("DistributionCenter", "Distribution Center");

            storageMaster.SelectVehicle("Warehouse", 0);
            for (int i = 0; i < 10; i++)
            {
                storageMaster.AddProduct("HardDrive", 100);
                storageMaster.LoadVehicle(new string[] { "HardDrive" });
            }

            storageMaster.SendVehicleTo("Warehouse", 0, "Distribution Center");

            var actualOutput = storageMaster.UnloadVehicle("Distribution Center", 3);
            var expectedOutput = "Unloaded 2/10 products at Distribution Center";

            Assert.AreEqual(expectedOutput, actualOutput, "Returned output mismatch!");

        }

        [Test]
        public void GetStorageStatus_ShouldReturnCorrectOutput()
        {
            for (int i = 0; i < 10; i++)
            {
                storageMaster.AddProduct("Ram", 100);
                storageMaster.AddProduct("Gpu", 200);
                storageMaster.AddProduct("HardDrive", 50);
                storageMaster.AddProduct("SolidStateDrive", 150);
            }

            storageMaster.RegisterStorage("AutomatedWarehouse", "Automated Warehouse");
            storageMaster.RegisterStorage("Warehouse", "Warehouse");

            storageMaster.SelectVehicle("Automated Warehouse", 0);
            storageMaster.LoadVehicle(new string[] { "Ram", "Ram", "Gpu", "HardDrive", "SolidStateDrive", "Gpu", "Ram", "Ram" });
            storageMaster.SendVehicleTo("Automated Warehouse", 0, "Warehouse");
            storageMaster.UnloadVehicle("Warehouse", 3);

            var actualOutput = storageMaster.GetStorageStatus("Warehouse");
            var expectedOutput = "Stock (3/10): [Ram (4), Gpu (2), HardDrive (1), SolidStateDrive (1)]\r\n" +
                "Garage: [Semi|Semi|Semi|Truck|empty|empty|empty|empty|empty|empty]";

            Assert.AreEqual(expectedOutput, actualOutput, "Status output mismatch!");
        }

        [Test]
        public void GetSummary_ShouldReturnCorrectOutput()
        {
            for (int i = 0; i < 10; i++)
            {
                storageMaster.AddProduct("Ram", 100);
                storageMaster.AddProduct("Gpu", 200);
                storageMaster.AddProduct("HardDrive", 50);
                storageMaster.AddProduct("SolidStateDrive", 150);
            }

            storageMaster.RegisterStorage("AutomatedWarehouse", "Automated Warehouse");
            storageMaster.RegisterStorage("Warehouse", "Warehouse");

            storageMaster.SelectVehicle("Automated Warehouse", 0);
            storageMaster.LoadVehicle(new string[] { "Ram", "Ram", "Gpu", "HardDrive", "SolidStateDrive", "Gpu", "Ram", "Ram" });
            storageMaster.SendVehicleTo("Automated Warehouse", 0, "Warehouse");
            storageMaster.UnloadVehicle("Warehouse", 3);

            storageMaster.SelectVehicle("Warehouse", 0);
            storageMaster.LoadVehicle(new string[] { "Gpu", "Ram", "Ram" });
            storageMaster.SendVehicleTo("Warehouse", 0, "Automated Warehouse");
            storageMaster.UnloadVehicle("Automated Warehouse", 0);

            var actualOutput = storageMaster.GetSummary();
            var expectedOutput = "Warehouse:\r\nStorage worth: $1000.00\r\nAutomated Warehouse:\r\nStorage worth: $400.00";

            Assert.AreEqual(expectedOutput, actualOutput, "Storages Summary mismatch!");
        }
    }
}

