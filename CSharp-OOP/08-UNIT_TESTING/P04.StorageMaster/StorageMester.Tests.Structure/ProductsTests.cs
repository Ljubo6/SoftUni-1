namespace StorageMester.Tests.Structure
{
    using NUnit.Framework;
    using StorageMaster.Entities.Products;
    using System;
    using System.Linq;
    using System.Reflection;

    public class ProductsTests
    {
        private Type type;

        [SetUp]
        public void SetUp()
        {
            type = typeof(Product);
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

            Assert.Throws<MemberAccessException>(() => { var instance = (Product)constructor.Invoke(new object[] { 5, 10 }); },
                "Constructor should not allow the class to be initialised as it is abstract!");
        }

        [Test]
        public void Field_ShouldHaveFieldsOfTypeDouble()
        {
            var fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var field in fields)
            {
                Assert.That(field.FieldType == typeof(double), "Field is not of expected type!");
            }
        }

        [Test]
        public void Field_ShouldReturnCorrectCountOfFields()
        {
            var fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.AreEqual(2, fields.Length, "Count of fields mismatch!");
        }

        [Test]
        public void Property_ShouldReturnCorrectCountOfProperties()
        {
            var props = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            Assert.AreEqual(2, props.Length, "Count of properties mismatch!");
        }

        [Test]
        public void Property_ShouldHaveCorrectNamesOfProperties()
        {
            var propsNames = type.GetProperties(BindingFlags.Instance | BindingFlags.Public).Select(p => p.Name);
            var expected = new string[] { "Price", "Weight" };
            CollectionAssert.AreEqual(expected, propsNames, "Names of class properties mismatch!");
        }

        [Test]
        public void Method_PrivateSetters_ShouldReturnCorrectCount()
        {
            var setters = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic).Where(m => m.Name.StartsWith("set"));
            Assert.AreEqual(1, setters.Count(), "Private Setters count mismatch!");
        }

        [Test]
        public void Method_PublicGetters_ShouldReturnCorrectCount()
        {
            var getters = type.GetMethods(BindingFlags.Instance | BindingFlags.Public).Where(m => m.Name.StartsWith("get"));
            Assert.AreEqual(2, getters.Count(), "Public Getters count mismatch!");
        }

        [Test]
        public void Consts_AllSpecificProducts_ShouldSetConstsAndPropertyValuesCorrectlyUponInitialisation()
        {
            var gpu = new Gpu(5);
            var hd = new HardDrive(10);
            var ram = new Ram(50);
            var ssd = new SolidStateDrive(100);

            Assert.AreEqual(0.7, gpu.Weight, "GPU weight mismatch!");
            Assert.AreEqual(1, hd.Weight, "Hard Drive weight mismatch!");
            Assert.AreEqual(0.1, ram.Weight, "RAM weight mismatch!");
            Assert.AreEqual(0.2, ssd.Weight, "Solid State Drive weight mismatch!");

            Assert.AreEqual(5, gpu.Price, "GPU price mismatch!");
            Assert.AreEqual(10, hd.Price, "Hard Drive price mismatch!");
            Assert.AreEqual(50, ram.Price, "RAM price mismatch!");
            Assert.AreEqual(100, ssd.Price, "Solid State Drive price mismatch!");
        }

        [Test]
        public void Consts_AllSpecificProducts_ShouldThrowExceptionWithNegativePrice()
        {
            Assert.Throws<InvalidOperationException>(() => { var gpu = new Gpu(-1); });
            Assert.Throws<InvalidOperationException>(() => { var ram = new Ram(-1); });
            Assert.Throws<InvalidOperationException>(() => { var hd = new SolidStateDrive(-1); });
            Assert.Throws<InvalidOperationException>(() => { var ssd = new HardDrive(-1); });
        }

    }
}
