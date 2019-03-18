using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.Sum_Average
{
    class Sum_Average
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            Console.WriteLine($"Sum={numbers.Sum()}; Average={numbers.Average():f2}");
        }
    }
}
