using NUnit.Framework;
using StorageMaster.Entities.Products;
using System;

namespace StorageMester.BusinessLogic.Tests
{
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
        public void AddProduct_ShouldWorkCorrectly()
        {
            //TODO
        }

    }
}
