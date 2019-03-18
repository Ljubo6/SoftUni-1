using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Water_Supply
{
    class Program
    {
        static void Main(string[] args)
        {
            double totalWater = double.Parse(Console.ReadLine());
            double totalWaterInitial = totalWater;
            double[] bottles = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            int bottleCapacity = int.Parse(Console.ReadLine());
            List<int> emptyBottlesIndicies = new List<int>();
            for (int i = 0; i < bottles.Length; i++)
            {
                emptyBottlesIndicies.Add(i);
            }

            double requiredWaterTotal = 0.0;
            int filledBottles = 0;
            bool hasEnoughWater = false;

            for (int i = 0; i < bottles.Length; i++)
            {
                requiredWaterTotal += (bottleCapacity - bottles[i]);
            }

            if (totalWater % 2 == 0)
            {
                for (int i = 0; i < bottles.Length; i++)
                {
                    if (totalWater - (bottleCapacity - bottles[i]) >= 0)
                    {
                        totalWater -= (bottleCapacity - bottles[i]);
                        bottles[i] = bottleCapacity;
                        filledBottles++;
                        emptyBottlesIndicies.RemoveAt(0);
                        hasEnoughWater = true;
                    }
                    else
                    {
                        hasEnoughWater = false;
                        break;
                    }
                }
            }
            else
            {
                emptyBottlesIndicies.Reverse();
                for (int i = bottles.Length - 1; i >= 0; i--)
                {
                    if (totalWater - (bottleCapacity - bottles[i]) >= 0)
                    {
                        totalWater -= (bottleCapacity - bottles[i]);
                        bottles[i] = bottleCapacity;
                        filledBottles++;
                        emptyBottlesIndicies.RemoveAt(0);
                        hasEnoughWater = true;
                    }
                    else
                    {
                        hasEnoughWater = false;
                        break;
                    }
                }
            }

            if (hasEnoughWater)
            {
                Console.WriteLine("Enough water!");
                Console.WriteLine($"Water left: {totalWater}l.");
            }
            else
            {
                Console.WriteLine("We need more water!");
                Console.WriteLine($"Botles left: {bottles.Length - filledBottles}");
                Console.WriteLine("With indexes: " + string.Join(", ", emptyBottlesIndicies));
                Console.WriteLine($"We need {requiredWaterTotal - totalWaterInitial} more litres.");
            }
        }
    }
}
