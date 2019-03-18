using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.Auto_Repair
{
    class AutoRepair
    {
        static void Main()
        {
            string[] cars = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] command = Console.ReadLine().Split('-', StringSplitOptions.RemoveEmptyEntries).ToArray();

            Queue<string> carsQueue = new Queue<string>(cars);
            Stack<string> servedCars = new Stack<string>();

            while (command[0] != "End")
            {
                if (command[0] == "Service")
                {
                    if (carsQueue.Any())
                    {
                        string currentVehicle = carsQueue.Peek();
                        Console.WriteLine($"Vehicle {currentVehicle} got served.");
                        servedCars.Push(carsQueue.Dequeue());
                    }
                }
                else if (command[0] == "CarInfo")
                {
                    if (servedCars.Contains(command[1]))
                    {
                        Console.WriteLine("Served.");
                    }
                    else if (carsQueue.Contains(command[1]))
                    {
                        Console.WriteLine("Still waiting for service.");
                    }
                }
                else if (command[0] == "History")
                {
                    Console.WriteLine(string.Join(", ", servedCars));
                }

                command = Console.ReadLine().Split('-', StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            if (carsQueue.Any())
            {
                Console.WriteLine("Vehicles for service: " + string.Join(", ", carsQueue));
            }
            Console.WriteLine("Served vehicles: " + string.Join(", ", servedCars));
        }
    }
}
