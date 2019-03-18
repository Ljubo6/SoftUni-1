using System;
using System.Collections.Generic;
using System.Linq;

namespace Additional_04.Raw_Data
{
    class RawData
    {
        static void Main(string[] args)
        {
            int carsCount = int.Parse(Console.ReadLine());
            Car[] allCars = new Car[carsCount];
            for (int i = 0; i < carsCount; i++)
            {
                string[] input = Console.ReadLine().Split();
                Engine currentEngine = new Engine(int.Parse(input[1]), int.Parse(input[2]));
                Cargo currentCargo = new Cargo(int.Parse(input[3]), input[4]);
                allCars[i] = new Car(input[0], currentEngine, currentCargo);
            }

            string cargoType = Console.ReadLine();
            List<Car> result = new List<Car>();

            if (cargoType == "fragile")
            {
                result = allCars
                    .Where(x => x.Cargo.Type == "fragile")
                    .Where(x => x.Cargo.Weight < 1000)
                    .ToList();
            }
            else if (cargoType == "flamable")
            {
                result = allCars
                    .Where(x => x.Cargo.Type == "flamable")
                    .Where(x => x.Engine.Power > 250)
                    .ToList();
            }

            foreach (var car in result)
            {
                Console.WriteLine(car.Model);
            }
        }
    }

    class Cargo
    {
        public Cargo(int weight, string type)
        {
            Weight = weight;
            Type = type;
        }

        public int Weight { get; set; }
        public string Type { get; set; }
    }

    class Engine
    {
        public Engine(int speed, int power)
        {
            Speed = speed;
            Power = power;
        }

        public int Speed { get; set; }
        public int Power { get; set; }
    }

    class Car
    {
        public Car(string model, Engine engine, Cargo cargo)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
        }
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
    }
}
