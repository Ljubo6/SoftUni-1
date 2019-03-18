using System;
using System.Collections.Generic;
using System.Linq;

namespace P08.Balanced_Parentheses
{
    class BalancedParentheses
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] parentheses = new char[] { '(', '{', '[' };

            if (input.Length % 2 == 1)
            {
                Console.WriteLine("NO");
                return;
            }

            Stack<char> opening = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                char current = input[i];

                if (parentheses.Contains(current))
                {
                    opening.Push(input[i]);
                    continue;
                }

                if (opening.Peek() == '(' && current == ')')
                {
                    opening.Pop();
                }
                else if (opening.Peek() == '[' && current == ']')
                {
                    opening.Pop();
                }
                else if (opening.Peek() == '{' && current == '}')
                {
                    opening.Pop();
                }
            }

            if (opening.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
