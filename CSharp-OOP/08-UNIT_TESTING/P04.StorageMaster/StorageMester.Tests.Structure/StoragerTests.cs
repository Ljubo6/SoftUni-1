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

        [SetUp]
        public void SetUp()
        {
            this.warehouse = new Warehouse("Warehouse");
            this.automatedWarehouse = new AutomatedWarehouse("Automated Warehouse");
            this.distributionCenter = new DistributionCenter("Distribution Center");
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
        public void GarageProp_ShouldReturnCorrectCollectionOfVehiclesAvailableUponInitialisation()
        {
            // also tests private method InitialiseGarage
        }

        [Test]
        public void GetVehicleMethod_ShouldReturnCorrectVehicleWhenIndexInRange()
        {

        }

        [Test]
        public void GetVehicleMethod_ShouldThrowExceptionWhenIndexOutOfRange()
        {

        }

        [Test]
        public void GetVehicleMethod_ShouldThrowExceptionWithNoVehicleAtIndex()
        {

        }

        //IsFullProp
        //ProductsProp
        //GetVehicleMethod
        //SendVehicleToMethod - should test private method AddVehicle
        //UnloadVehicleMethod - should test isFullProp & ProductsProp
    }
}
