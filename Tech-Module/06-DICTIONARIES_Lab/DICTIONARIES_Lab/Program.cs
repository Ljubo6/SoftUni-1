using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Count_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(double.Parse).ToList();

            var numbers = new SortedDictionary<double, int>();

            foreach (var number in input)
            {
                if (numbers.ContainsKey(number) == true)
                {
                    numbers[number]++;
                }
                else
                {
                    numbers[number] = 1;
                }
            }

            foreach (var kvp in numbers)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }

        }
    }
}
