using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.Reverse_Numbers
{
    class ReverseNumbers
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i]);
            }

            Console.WriteLine(string.Join(' ', stack));
        }
    }
}
