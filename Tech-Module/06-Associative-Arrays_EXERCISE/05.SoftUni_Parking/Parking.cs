using System;
using System.Collections.Generic;

namespace _05.SoftUni_Parking
{
    class Parking
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            var carsRegistration = new Dictionary<string, string>();

            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[0];
                string username = input[1];

                if (command == "register")
                {
                    string regPlate = input[2];

                    if (!carsRegistration.ContainsKey(username))
                    {
                        carsRegistration.Add(username, regPlate);
                        Console.WriteLine($"{username} registered {regPlate} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {regPlate}");
                    }
                }
                else
                {
                    if (!carsRegistration.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                    else
                    {
                        carsRegistration.Remove(username);
                        Console.WriteLine($"{username} unregistered successfully");
                    }
                }
            }

            foreach (var car in carsRegistration)
            {
                Console.WriteLine($"{car.Key} => {car.Value}");
            }
        }
    }
}
