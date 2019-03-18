using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        List<Engine> engines = new List<Engine>();
        List<Car> cars = new List<Car>();

        int enginesCount = int.Parse(Console.ReadLine());
        
        for (int i = 0; i < enginesCount; i++)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var currentEngine = new Engine(input[0], input[1]);


            if (input.Length == 3)
            {
                if (int.TryParse(input[2], out int displacement))
                {
                    currentEngine.Displacement = displacement;
                }
                else
                {
                    currentEngine.Efficiency = input[2];
                }
            }
            else if (input.Length == 4)
            {
                currentEngine.Displacement = int.Parse(input[2]);
                currentEngine.Efficiency = input[3];
            }

            engines.Add(currentEngine);
        }

        int carsCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < carsCount; i++)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Engine currentCarEngine = engines.FirstOrDefault(e => e.Model == input[1]);

            var currentCar = new Car(input[0], currentCarEngine);

            if (input.Length == 3)
            {
                if (decimal.TryParse(input[2], out decimal weight))
                {
                    currentCar.Weight = weight;
                }
                else
                {
                    currentCar.Color = input[2];
                }
            }

            else if (input.Length == 4)
            {
                currentCar.Weight = decimal.Parse(input[2]);
                currentCar.Color = input[3];
            }

            cars.Add(currentCar);
        }

        foreach (Car car in cars)
        {
            Console.WriteLine(car.ToString());
        }
    }
}
