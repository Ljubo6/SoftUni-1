using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Train
{
    class Train
    {
        static void Main(string[] args)
        {
            List<int> passangersPerWagon = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int maxCapacity = int.Parse(Console.ReadLine());

            string[] command = Console.ReadLine().ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            while (command[0] != "end")
            {
                if (command[0] == "add")
                {
                    passangersPerWagon.Add(int.Parse(command[1]));
                }
                else
                {
                    int passangersToAdd = int.Parse(command[0]);

                    for (int i = 0; i < passangersPerWagon.Count; i++)
                    {
                        if (passangersPerWagon[i] + passangersToAdd <= maxCapacity)
                        {
                            passangersPerWagon[i] += passangersToAdd;
                            break;
                        }
                    }
                }

                command = Console.ReadLine().ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            Console.WriteLine(string.Join(' ', passangersPerWagon));
        }
    }
}
