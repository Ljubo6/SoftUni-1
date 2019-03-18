using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.Max_Element
{
    class MaxMinElement
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < lines; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int command = input[0];

                switch (command)
                {
                    case 1:
                        int number = input[1];
                        stack.Push(number);
                        break;
                    case 2:
                        if (stack.Any())
                        {
                            stack.Pop();
                        }
                        break;
                    case 3:
                        if (stack.Any())
                        {
                            Console.WriteLine(stack.Max());
                        }
                        break;
                    case 4:
                        if (stack.Any())
                        {
                            Console.WriteLine(stack.Min());
                        }
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
