using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Minning
{
    class Program
    {
        static void Main(string[] args)
        {
            int videoCardPrice = int.Parse(Console.ReadLine());
            int adapterPrice = int.Parse(Console.ReadLine());
            double electricityDailyPerCard = double.Parse(Console.ReadLine());
            double incomeDailyPerCard = double.Parse(Console.ReadLine());

            double totalCost = 13 * (videoCardPrice + adapterPrice) + 1000;
            double profitPerCard = incomeDailyPerCard - electricityDailyPerCard;

            Console.WriteLine($"{totalCost}");
            Console.WriteLine(Math.Round(totalCost / (profitPerCard * 13)));
        }
    }
}
