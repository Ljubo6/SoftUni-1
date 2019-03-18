using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            double bedPrice = double.Parse(Console.ReadLine());
            
            // MONTHLY
            double wcPrice = double.Parse(Console.ReadLine());
            double foodPrice = wcPrice * 1.25;
            double toysPrice = foodPrice * 0.5;
            double veterinar = toysPrice * 1.1;
            double unexpectedCost = (wcPrice + foodPrice + toysPrice + veterinar) * 0.05;

            double totalCost = bedPrice + 12 * (wcPrice + foodPrice + toysPrice + veterinar + unexpectedCost);

            Console.WriteLine($"{totalCost:f2} lv.");

        }
    }
}
