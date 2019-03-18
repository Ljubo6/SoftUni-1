using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.CherryJars
{
    class Program
    {
        static void Main(string[] args)
        {
            int kompot = int.Parse(Console.ReadLine()) + 1;
            int jam = int.Parse(Console.ReadLine()) + 1;
            double cherriesKompot = 0.300 * 1.05;
            double cherriesJam = 0.650 * 1.10;

            double totalCost = (kompot * cherriesKompot + jam * cherriesJam) * 3.2;
            Console.WriteLine($"{totalCost:f2}");

        }
    }
}
