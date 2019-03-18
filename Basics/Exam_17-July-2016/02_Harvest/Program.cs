using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Harvest
{
    class Program
    {
        static void Main(string[] args)
        {
            int wineField = int.Parse(Console.ReadLine());
            double grapePerSqM = double.Parse(Console.ReadLine());
            int wineForSale = int.Parse(Console.ReadLine());
            int workersCount = int.Parse(Console.ReadLine());

            double grapeForWine = (wineField * grapePerSqM) * 0.4;
            double wineProduced = grapeForWine / 2.5;
            double difference = Math.Abs(wineForSale - wineProduced);

            if (wineProduced < wineForSale)
            {
                Console.WriteLine($"It will be a tough winter! More {difference:f0} liters wine needed.");
            }

            if (wineProduced > wineForSale)
            {
                Console.WriteLine($"Good harvest this year! Total wine: {wineProduced:f0} liters.");
                Console.WriteLine(Math.Ceiling(difference) +" liters left -> " + Math.Ceiling(difference / workersCount) + " liters per person.");
            }


        }
    }
}
