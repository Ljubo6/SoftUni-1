using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Baking_Factory
{
    class Factory
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<int> bestBatch = new List<int>();
            int highestTotalQt = int.MinValue;
            double bestAvgQt = double.MinValue;
            int shortestBatch = int.MaxValue;


            while (input != "Bake It!")
            {
                List<int> batch = input.Split('#', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

                if (batch.Sum() > highestTotalQt)
                {
                    bestBatch = new List<int>(batch);
                    highestTotalQt = batch.Sum();
                    bestAvgQt = batch.Average();
                    shortestBatch = batch.Count;
                }
                else if (batch.Sum() == highestTotalQt)
                {
                    if (batch.Average() > bestAvgQt)
                    {
                        bestBatch = new List<int>(batch);
                        highestTotalQt = batch.Sum();
                        bestAvgQt = batch.Average();
                        shortestBatch = batch.Count;
                    }
                    else if (batch.Average() == bestAvgQt)
                    {
                        if (batch.Count < shortestBatch)
                        {
                            bestBatch = new List<int>(batch);
                            highestTotalQt = batch.Sum();
                            bestAvgQt = batch.Average();
                            shortestBatch = batch.Count;
                        }
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Best Batch quality: {highestTotalQt}");
            Console.WriteLine(string.Join(' ', bestBatch));
        }
    }
}