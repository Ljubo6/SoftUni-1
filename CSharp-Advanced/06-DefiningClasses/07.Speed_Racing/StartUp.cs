using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        int carsCount = int.Parse(Console.ReadLine());
        List<Car> allCars = new List<Car>();

        for (int i = 0; i < carsCount; i++)
        {
            string[] input = Console.ReadLine().Split();
            var currentCar = new Car(input[0], double.Parse(input[1]), double.Parse(input[2]));
            allCars.Add(currentCar);
        }

        while (true)
        {
            string[] command = Console.ReadLine().Split();
            if (command[0] == "End")
            {
                break;
            }

            Car carToDrive = allCars.FirstOrDefault(car => car.Model == command[1]);

            if (carToDrive != null)
            {
                double distanceToTravel = double.Parse(command[2]);

                if (carToDrive.IsFuelEnough(distanceToTravel))
                {
                    carToDrive.IncreaseTravelledDistance(distanceToTravel);
                    carToDrive.ReduceFuel(distanceToTravel);
                }
                else
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                    continue;
                }
            }
        }

        foreach (var car in allCars)
        {
            Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
        }
    }
}
