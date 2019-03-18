using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            double average = numbers.Average();

            numbers.Sort();
            numbers.Reverse();

            if (numbers[0] > average)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (numbers[i] > average)
                    {
                        Console.Write(numbers[i] + " ");
                    }
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
