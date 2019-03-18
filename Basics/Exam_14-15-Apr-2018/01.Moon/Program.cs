using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Moon
{
    class Program
    {
        static void Main(string[] args)
        {
            double speed = double.Parse(Console.ReadLine());
            double fuelPer100km = double.Parse(Console.ReadLine());

            Console.WriteLine(Math.Round(384400 * 2 / speed) + 3);
            Console.WriteLine(3844 * fuelPer100km * 2);
        }
    }
}
