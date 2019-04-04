using NUnit.Framework;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Storage;
using StorageMaster.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorageMester.Tests.Structure
{
    [TestFixture]
    public class StorageTests
    {
        private Warehouse warehouse; // C = 10, GS = 10;
        private AutomatedWarehouse automatedWarehouse; // C = 1, GS = 2;
        private DistributionCenter distributionCenter; // C = 2, GS = 5;

        private Product hd;
        private Product ram;
        private Product ssd;

        [SetUp]
        public void SetUp()
        {
            this.warehouse = new Warehouse("Warehouse");
            this.automatedWarehouse = new AutomatedWarehouse("Automated Warehouse");
            this.distributionCenter = new DistributionCenter("Distribution Center");

            ram = new Ram(49.99); //W = 0.1
            ssd = new SolidStateDrive(149.99); //W = 0.2
            hd = new HardDrive(99.99); //W = 1
        }

        [Test]
        public void NameProp_ShouldBeSetCorrectlyUponInitialisation()
        {
            Assert.That(warehouse.Name == "Warehouse", "Warehouse name is not set correctly!");
            Assert.That(automatedWarehouse.Name == "Automated Warehouse", "Automated Warehouse name is not set correctly!");
            Assert.That(distributionCenter.Name == "Distribution Center", "Distribution Center name is not set correctly!");
        }

        [Test]
        public void CapacityProp_ShouldBeSetCorrectlyUponInitialisation()
        {
            Assert.That(warehouse.Capacity == 10, "Warehouse capacity is not set correctly!");
            Assert.That(automatedWarehouse.Capacity == 1, "Automated Warehouse capacity is not set correctly!");
            Assert.That(distributionCenter.Capacity == 2, "Distribution Center capacity is not set correctly!");
        }

        [Test]
        public void GarageSlotsProp_ShouldBeSetCorrectlyUponInitialisation()
        {
            Assert.That(warehouse.GarageSlots == 10, "Warehouse garage slots count is not set correctly!");
            Assert.That(automatedWarehouse.GarageSlots == 2, "Automated Warehouse garage slots count is not set correctly!");
            Assert.That(distributionCenter.GarageSlots == 5, "Distribution Center garage slots count is not set correctly!");
        }

        [Test]
        public void InitialiseGarageMethod_ShouldReturnCorrectCountOfVehiclesAvailableUponInitialisation()
        {
            var warehouseVehiclesCount = warehouse.Garage.Where(x => x != null && x is Semi).ToArray().Count();
            var automatedWarehouseVehiclesCount = automatedWarehouse.Garage.Where(x => x != null && x is Truck).ToArray().Count();
            var distributionCenterVehiclesCount = distributionCenter.Garage.Where(x => x != null && x is Van).ToArray().Count();

            Assert.AreEqual(3, warehouseVehiclesCount);
            Assert.AreEqual(1, automatedWarehouseVehiclesCount);
            Assert.AreEqual(3, distributionCenterVehiclesCount);
        }

        [Test]
        [TestCase(0)]
        public void GetVehicleMethod_ShouldReturnCorrectVehicleWhenIndexInRange(int garageSlot)
        {
            var warehouseVehicle = warehouse.GetVehicle(garageSlot);
            var automatedWarehouseVehicle = automatedWarehouse.GetVehicle(garageSlot);
            var distributionCenterVehicle = distributionCenter.GetVehicle(garageSlot);

            Assert.IsInstanceOf<Semi>(warehouseVehicle);
            Assert.IsInstanceOf<Truck>(automatedWarehouseVehicle);
            Assert.IsInstanceOf<Van>(distributionCenterVehicle);

        }

        [Test]
        [TestCase(100)]
        public void GetVehicleMethod_ShouldThrowExceptionWhenIndexOutOfRange(int garageSlot)
        {
            Assert.Throws<InvalidOperationException>(() => warehouse.GetVehicle(garageSlot), 
                "The method returns a vehicle which is on an index out of range!");
            Assert.Throws<InvalidOperationException>(() => automatedWarehouse.GetVehicle(garageSlot),
                "The method returns a vehicle which is on an index out of range!");
            Assert.Throws<InvalidOperationException>(() => distributionCenter.GetVehicle(garageSlot),
                "The method returns a vehicle which is on an index out of range!");
        }

        [Test]
        public void GetVehicleMethod_ShouldThrowExceptionWithNoVehicleAtIndex()
        {
            Assert.Throws<InvalidOperationException>(() => warehouse.GetVehicle(3),
                "The method returns a vehicle found on an empty garage slot!");
            Assert.Throws<InvalidOperationException>(() => automatedWarehouse.GetVehicle(1),
                "The method returns a vehicle found on an empty garage slot!");
            Assert.Throws<InvalidOperationException>(() => distributionCenter.GetVehicle(3),
                "The method returns a vehicle found on an empty garage slot!");
        }

        [Test]
        public void SendVehicleToMethod_WarehouseToAutomatedWarehouse_ShouldWorkCorrectly()
        {
            //also tests private method AddVehicle

            var truck = automatedWarehouse.GetVehicle(0);
            var semi = warehouse.GetVehicle(0);

            warehouse.SendVehicleTo(0, automatedWarehouse);

            var automatedWarehouseVehiclesCount = warehouse.Garage.Where(x => x != null).ToArray().Count();
            var expectedVehicles = new Vehicle[] { truck, semi };

            Assert.AreEqual(2, automatedWarehouseVehiclesCount, 
                "Vehicles count is incorrect!");
            CollectionAssert.AreEqual(expectedVehicles, automatedWarehouse.Garage, 
                "Vehicles in garage are not as expected!");
        }

        [Test]
        public void SendVehicleToMethod_WarehouseToAutomatedWarehouse_ShouldReturnCorrectSlotNumber()
        {
            int slotOfArrival = warehouse.SendVehicleTo(0, automatedWarehouse);
            Assert.AreEqual(1, slotOfArrival, "Vehicle arrived at wrong slot!");
        }

        [Test]
        public void SendVehicleToMethod_ShouldThrowExceptionWhenGarageFull()
        {
            warehouse.SendVehicleTo(0, automatedWarehouse);

            Assert.Throws<InvalidOperationException>(() => warehouse.SendVehicleTo(1, automatedWarehouse),
                "Sending a vehicle to a full garage should throw Exception!");
        }


        [Test]
        public void UnloadVehicleMethod_ShouldWorkCorrectlyByTestingProductsProp()
        {
            var vehicle = warehouse.GetVehicle(0);
            vehicle.LoadProduct(hd);
            vehicle.LoadProduct(ssd);

            warehouse.SendVehicleTo(0, automatedWarehouse);

            var unloadedProductsCount = automatedWarehouse.UnloadVehicle(1);

            var expected = new Product[] { ssd, hd };

            Assert.AreEqual(2, unloadedProductsCount, "Count of unloaded products is incorrect!");
            CollectionAssert.AreEqual(expected, automatedWarehouse.Products, 
                "Count of unloaded products is correct but the order of unloading is wrong!");
        }

        [Test]
        public void UnloadVehicleMethod_ShouldThrowExceptionWhenCapacityIsFull()
        {
            // also tests if IsFull works correctly
            var vehicle = warehouse.GetVehicle(0);
            vehicle.LoadProduct(hd);

            warehouse.SendVehicleTo(0, automatedWarehouse);
            automatedWarehouse.UnloadVehicle(1);

            Assert.IsTrue(automatedWarehouse.IsFull, "Method should confirm that storage is full!");

            automatedWarehouse.SendVehicleTo(1, distributionCenter);
            vehicle.LoadProduct(ssd);
            distributionCenter.SendVehicleTo(3, automatedWarehouse);

            Assert.Throws<InvalidOperationException>(() => automatedWarehouse.UnloadVehicle(1), 
                "Storage is full and should throw Exception! It should not allow unloading!");
        }
    }
}
