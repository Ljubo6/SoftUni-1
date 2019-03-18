using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Stiropor
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double houseArea = double.Parse(Console.ReadLine());
            int windowsCount = int.Parse(Console.ReadLine());
            double stiroporPerPack = double.Parse(Console.ReadLine());
            double pricePerPack = double.Parse(Console.ReadLine());

            double totalAreaToCover = (houseArea - windowsCount * 2.4) * 1.1;
            double totalPacksNeeded = Math.Ceiling(totalAreaToCover / stiroporPerPack);
            double totalStiroporPrice = totalPacksNeeded * pricePerPack;
            double difference = Math.Abs(budget - totalStiroporPrice);

            if (budget >= totalStiroporPrice)
            {
                Console.WriteLine($"Spent: {totalStiroporPrice:f2}");
                Console.WriteLine($"Left: {difference:f2}");
            }
            else
            {
                Console.WriteLine($"Need more: {difference:f2}");
            }

        }
    }
}
