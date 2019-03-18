using System;
using System.Collections.Generic;
using System.Linq;

namespace EXPERIMENTS
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> alabala = Console.ReadLine()
               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();

            numbers.Capacity = 3;

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
