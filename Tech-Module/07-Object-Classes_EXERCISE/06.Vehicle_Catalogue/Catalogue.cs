using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Vehicle_Catalogue
{
    public class Vehicle
    {
        public Vehicle(string type, string model, string color, int horsePower)
        {
            Type = char.ToUpper(type[0]) + type.Substring(1);
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }

        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }
    }

    class Catalogue
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            string[] input = Console.ReadLine().Split();

            while (input[0] != "End")
            {
                Vehicle currentVehicle = new Vehicle(input[0], input[1], input[2], int.Parse(input[3]));

                vehicles.Add(currentVehicle);
                input = Console.ReadLine().Split();
            }

            string modelToSearch = Console.ReadLine();

            while (modelToSearch != "Close the Catalogue")
            {
                int indexOfVehicle = vehicles.FindIndex(x => x.Model == modelToSearch);
                if (indexOfVehicle >= 0)
                {
                    Console.WriteLine($"Type: {vehicles[indexOfVehicle].Type}");
                    Console.WriteLine($"Model: {vehicles[indexOfVehicle].Model}");
                    Console.WriteLine($"Color: {vehicles[indexOfVehicle].Color}");
                    Console.WriteLine($"Horsepower: {vehicles[indexOfVehicle].HorsePower}");
                }
                modelToSearch = Console.ReadLine();
            }

            List<Vehicle> cars = vehicles.Where(x => x.Type == "Car").ToList();
            List<Vehicle> trucks = vehicles.Where(x => x.Type == "Truck").ToList();


            if (cars.Count > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {cars.Select(x => x.HorsePower).Average():f2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {0:f2}.");
            }

            if (trucks.Count > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {trucks.Select(x => x.HorsePower).Average():f2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");
            }
        }
    }
}
