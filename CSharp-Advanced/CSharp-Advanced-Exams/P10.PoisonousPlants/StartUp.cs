using System;
using System.Collections.Generic;
using System.Linq;

namespace P10.PoisonousPlants
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int plantsCount = int.Parse(Console.ReadLine());
            List<int> plants = Console.ReadLine().Split().Select(int.Parse).ToList();

            int daysPassed = 0;

            while (true)
            {
                List<int> plantIndeciesToRemove = new List<int>();

                for (int i = 1; i < plants.Count; i++)
                {
                    if(plants[i] > plants[i-1])
                    {
                        plantIndeciesToRemove.Add(i);
                    }
                }

                if(plantIndeciesToRemove.Count == 0)
                {
                    break;
                }
                else
                {
                    daysPassed++;

                    for (int i = plantIndeciesToRemove.Count - 1; i >= 0; i--)
                    {
                        plants.RemoveAt(plantIndeciesToRemove[i]);
                    }
                }
            }

            Console.WriteLine(daysPassed);
        }
    }
}
