using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        int carsCount = int.Parse(Console.ReadLine());
        List<Car> allCars = new List<Car>();

        for (int i = 0; i < carsCount; i++)
        {
            string[] input = Console.ReadLine().Split();
            string model = input[0];

            int engineSpeed = int.Parse(input[1]);
            int enginePower = int.Parse(input[2]);
            var currentEngine = new Engine(engineSpeed, enginePower);

            int cargoWeight = int.Parse(input[3]);
            string cargoType = input[4];
            var currentCargo = new Cargo(cargoType, cargoWeight);

            double tireOnePressure = double.Parse(input[5]);
            int tireOneAge = int.Parse(input[6]);
            var tireOne = new Tire(tireOneAge, tireOnePressure);

            double tireTwoPressure = double.Parse(input[7]);
            int tireTwoAge = int.Parse(input[8]);
            var tireTwo = new Tire(tireTwoAge, tireTwoPressure);

            double tireThreePressure = double.Parse(input[9]);
            int tireThreeAge = int.Parse(input[10]);
            var tireThree = new Tire(tireThreeAge, tireThreePressure);

            double tireFourPressure = double.Parse(input[11]);
            int tireFourAge = int.Parse(input[12]);
            var tireFour = new Tire(tireFourAge, tireFourPressure);

            var currentCar = new Car(model, currentEngine, currentCargo, new Tire[] { tireOne, tireTwo, tireThree, tireFour });
            allCars.Add(currentCar);
        }

        string command = Console.ReadLine();

        if (command == "fragile")
        {
            allCars
                .FindAll(c => c.Cargo.Type == "fragile")
                .Where(c => c.hasTireWithValidPressure())
                .ToList()
                .ForEach(c => Console.WriteLine(c.Model));
        }
        else if (command == "flamable")
        {
            allCars
                .FindAll(c => c.Cargo.Type == "flamable")
                .Where(c => c.hasEngineWithValidPower())
                .ToList()
                .ForEach(c => Console.WriteLine(c.Model));
        }
    }
}
