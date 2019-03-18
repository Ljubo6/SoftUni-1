using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_07_Jan_2018
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingWeight = int.Parse(Console.ReadLine());
            int breadWeight = int.Parse(Console.ReadLine());
            double breadPrice = double.Parse(Console.ReadLine());
            int soldBreadCount = int.Parse(Console.ReadLine());
            int soldSweetsCount = int.Parse(Console.ReadLine());


            double sweetsWeight = breadWeight * 0.8;
            double sweetsPrice = breadPrice * 1.25;
            double doughBread = breadWeight * soldBreadCount;
            double doughTotalPrice = ((doughBread + startingWeight) / 1000) * 4;

            double totalProfit = breadPrice * soldBreadCount + soldSweetsCount * sweetsPrice - doughTotalPrice;
            double doughUsed = Math.Round(breadWeight * soldBreadCount + sweetsWeight * soldSweetsCount);

            Console.WriteLine($"Pure income: {totalProfit:f2} lv.");
            Console.WriteLine($"Dough used: {doughUsed} g.");


        }
    }
}
