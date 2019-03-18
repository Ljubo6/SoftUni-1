using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.Reverse_Numbers
{
    class ReverseNumbers
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(new char[] { ' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                numbers.Push(input[i]);
            }

            while (numbers.Count != 0)
            {
                Console.Write(numbers.Pop() + " ");
            }
            Console.WriteLine();
        }
    }
}
