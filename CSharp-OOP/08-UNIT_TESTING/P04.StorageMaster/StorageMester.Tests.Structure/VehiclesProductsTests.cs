using NUnit.Framework;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Vehicles;
using System;
using System.Collections.Generic;

namespace StorageMester.Tests.Structure
{
    [TestFixture]
    public class VehiclesProductsTests
    {
        private Product hd;
        private Product ram;
        private Product ssd;

        private Vehicle semi;
        private Vehicle truck;
        private Vehicle van;


        [SetUp]
        public void SetUp()
        {
            ram = new Ram(49.99); //W = 0.1
            ssd = new SolidStateDrive(149.99); //W = 0.2
            hd = new HardDrive(99.99); //W = 1

            semi = new Semi(); //C = 10
            truck = new Truck(); //C = 5
            van = new Van(); //C = 2
        }


        [Test]
        public void ProductsWeight_ShouldReturnCorrectResultUponInitialisation()
        {
            Assert.AreEqual(0.1, ram.Weight, "Ram weight is wrong upon initialisation!");
            Assert.AreEqual(0.2, ssd.Weight, "SSD weight is wrong upon initialisation!");
            Assert.AreEqual(1, hd.Weight, "HD weight is wrong upon initialisation!");
        }

        [Test]
        public void ProductsPrice_ShouldThrowExceptionWithNegativePrice()
        {
            Assert.Throws<InvalidOperationException>(() => { ram = new Ram(-1); });
            Assert.Throws<InvalidOperationException>(() => { hd = new SolidStateDrive(-1); });
            Assert.Throws<InvalidOperationException>(() => { ssd = new HardDrive(-1); });
        }

        [Test]
        public void Vehicle_CapacityProp_ShouldReturnCorrectValueUponInitialisation()
        {
            Assert.AreEqual(10, semi.Capacity, "Semi capacity is wrong upon initialisation!");
            Assert.AreEqual(5, truck.Capacity, "Truck capacity is wrong upon initialisation!");
            Assert.AreEqual(2, van.Capacity, "Van capacity is wrong upon initialisation!");
        }

        [Test]
        public void Vehicle_TrunkProperty_ShouldReturnCorrectCollection()
        {
            semi.LoadProduct(hd);
            truck.LoadProduct(hd);
            van.LoadProduct(hd);

            semi.LoadProduct(ram);
            truck.LoadProduct(ram);
            van.LoadProduct(ram);

            semi.LoadProduct(ssd);
            truck.LoadProduct(ssd);
            van.LoadProduct(ssd);

            var expected = new List<Product> { hd, ram, ssd };
            CollectionAssert.AreEqual(expected, semi.Trunk, "Semi trunk does not contain expected products!");
            CollectionAssert.AreEqual(expected, truck.Trunk, "Truck trunk does not contain expected products!");
            CollectionAssert.AreEqual(expected, van.Trunk, "Van trunk does not contain expected products!");

        }

        [Test]
        public void Vehicle_IsEmptyProp_ShouldReturnTrueWhenTrunkEmpty()
        {
            Assert.IsTrue(semi.IsEmpty, "Semi trunk should be empty!");
            Assert.IsTrue(truck.IsEmpty, "Truck trunk should be empty!");
            Assert.IsTrue(van.IsEmpty, "Van trunk should be empty!");
        }

        [Test]
        public void Vehicle_LoadProductMethod_ShouldReturnCorrectResult()
        {
            semi.LoadProduct(hd);
            truck.LoadProduct(hd);
            van.LoadProduct(hd);

            var expected = new List<Product> { hd };
            CollectionAssert.AreEqual(expected, semi.Trunk, "Semi trunk does not contain expected products!");
            CollectionAssert.AreEqual(expected, truck.Trunk, "Truck trunk does not contain expected products!");
            CollectionAssert.AreEqual(expected, van.Trunk, "Van trunk does not contain expected products!");
        }

        [Test]
        public void Vehicle_LoadProductMethod_ShouldThrowExceptionWhenVehicleFull()
        {
            for (int i = 0; i < 10; i++)
            {
                semi.LoadProduct(hd);

                if (i % 2 == 0)
                {
                    truck.LoadProduct(hd);
                }

                if (i % 5 == 0)
                {
                    van.LoadProduct(hd);
                }
            }

            Assert.Throws<InvalidOperationException>(() => semi.LoadProduct(hd));
            Assert.Throws<InvalidOperationException>(() => truck.LoadProduct(hd));
            Assert.Throws<InvalidOperationException>(() => van.LoadProduct(hd));
        }

        [Test]
        public void Vehicle_UnloadProductMethod_ShouldWorkCorrectly()
        {
            semi.LoadProduct(hd);
            truck.LoadProduct(hd);
            van.LoadProduct(hd);

            //test if loaded successfully
            Assert.AreEqual(1, semi.Trunk.Count, "Semi trunk does not contain correct count of loaded products!");
            Assert.AreEqual(1, truck.Trunk.Count, "Truck trunk does not contain correct count of loaded products!");
            Assert.AreEqual(1, van.Trunk.Count, "Van trunk does not contain correct count of loaded products!");

            var expectedUnloadedProduct = hd;

            //unload
            var semiProduct = semi.Unload();
            var truckProduct = truck.Unload();
            var vanProduct = van.Unload();

            //test if trunk is empty
            Assert.AreEqual(0, semi.Trunk.Count, "Semi trunk should be empty!");
            Assert.AreEqual(0, truck.Trunk.Count, "Truck trunk should be empty!");
            Assert.AreEqual(0, van.Trunk.Count, "Van trunk should be empty!");

            //test if returns correct product which is unloaded
            Assert.AreEqual(expectedUnloadedProduct, semiProduct, "The method does not unload the correct product!");
            Assert.AreEqual(expectedUnloadedProduct, truckProduct, "The method does not unload the correct product!");
            Assert.AreEqual(expectedUnloadedProduct, vanProduct, "The method does not unload the correct product!");
        }

        [Test]
        public void Vehicle_UnloadProductMethod_ShouldThrowExceptionWhenTrunkEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => semi.Unload());
            Assert.Throws<InvalidOperationException>(() => truck.Unload());
            Assert.Throws<InvalidOperationException>(() => van.Unload());
        }
    }
}
