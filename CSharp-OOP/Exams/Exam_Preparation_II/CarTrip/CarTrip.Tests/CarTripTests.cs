namespace CarTrip.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarTripTests
    {
        private Car car;

        [SetUp]
        public void SetUp()
        {
            this.car = new Car("myCar", 100, 50, 2);
        }

        [Test]
        public void Constructor_ShouldSetValuesCorrectly()
        {
            Assert.AreEqual("myCar", this.car.Model);
            Assert.AreEqual(100, this.car.TankCapacity);
            Assert.AreEqual(50, this.car.FuelAmount);
            Assert.AreEqual(2, this.car.FuelConsumptionPerKm);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Constructor_ShouldThrowExceptionWithInvalidModelUponInitialisation(string model)
        {
            Assert.Throws<ArgumentException>(() => this.car = new Car(model, 100, 50, 2));
        }

        [Test]
        public void Constructor_ShouldThrowExcpetionWithFuelExceedingTankCapacityUponInitiliasation()
        {
            Assert.Throws<ArgumentException>(() => this.car = new Car("myCar", 100, 150, 2));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void Constructor_ShouldThrowExceptionWithInvalidConsumptionUponInitialisation(double fuelConsumptionPerKm)
        {
            Assert.Throws<ArgumentException>(() => this.car = new Car("myCar", 100, 50, fuelConsumptionPerKm));
        }

        [Test]
        public void DriveMethod_ShouldReturnCorrectOutput()
        {
            var actualOutput = this.car.Drive(10);
            var expectedOutput = "Have a nice trip";
            Assert.That(actualOutput == expectedOutput);
        }

        [Test]
        public void DriveMethod_ShouldChangeFuelAmountAfterDrivingValidDistance()
        {
            this.car.Drive(10); //20 consumption
            var expectedFuelLeft = 30;
            Assert.AreEqual(expectedFuelLeft, this.car.FuelAmount);
        }

        [Test]
        public void DriveMethod_ShouldThrowExceptionWithDistanceRequiringFuelThatExceedsCurrentLevel()
        {
            Assert.Throws<InvalidOperationException>(() => this.car.Drive(100));
        }

        [Test]
        public void RefuelMethod_ShouldRefuelToCorrectLevel()
        {
            this.car.Refuel(30);
            var expectedFuelLevel = 80;
            Assert.AreEqual(expectedFuelLevel, this.car.FuelAmount);
        }

        [Test]
        public void RefuelMethod_ShouldThrowExceptionWhenRefuelingAmountOverfillsTank()
        {
            Assert.Throws<InvalidOperationException>(() => this.car.Refuel(100));
        }
    }
}
