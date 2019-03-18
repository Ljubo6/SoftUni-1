using System;
using System.Collections.Generic;

namespace Additional_03.Speed_Racing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int carsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carsCount; i++)
            {
                string[] input = Console.ReadLine().Split();
                Car currentCar = new Car(input[0], double.Parse(input[1]), double.Parse(input[2]));
                cars.Add(currentCar);
            }
            string[] command = Console.ReadLine().Split();

            while (command[0] != "End")
            {
                if (command[0] == "Drive")
                {
                    string model = command[1];
                    double distance = double.Parse(command[2]);
                    int currentModelIndex = cars.FindIndex(x => x.Model == model);
                    cars[currentModelIndex].Drive(distance);
                }
                command = Console.ReadLine().Split();
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.Fuel:f2} {car.DistanceTravelled}");
            }
        }
    }

    class Car
    {
        public Car(string model, double fuel, double consumption)
        {
            Model = model;
            Fuel = fuel;
            Consumpion = consumption;
        }

        public string Model { get; set; }
        public double Fuel { get; set; }
        public double Consumpion { get; set; }
        public double DistanceTravelled { get; set; } = 0.0;

        public void Drive(double distanceToTravel)
        {
            if (distanceToTravel * Consumpion <= Fuel)
            {
                DistanceTravelled += distanceToTravel;
                Fuel -= distanceToTravel * Consumpion;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
