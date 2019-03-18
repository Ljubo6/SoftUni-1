using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.Basic_Stack_Operations
{
    class BasicStackOperations
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int pop = input[1];
            int toSearch = input[2];

            int[] numbersToPushInto = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < numbersToPushInto.Length; i++)
            {
                stack.Push(numbersToPushInto[i]);
            }

            for (int i = 0; i < pop; i++)
            {
                stack.Pop();
            }

            if (stack.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }

            if (IsPresent(stack, toSearch))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }

        private static bool IsPresent(Stack<int> stack, int toSearch)
        {
            return stack.Contains(toSearch);
        }
    }
}
