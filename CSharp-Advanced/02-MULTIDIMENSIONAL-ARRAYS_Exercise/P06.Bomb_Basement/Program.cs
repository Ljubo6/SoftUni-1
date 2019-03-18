using System;
using System.Linq;
using System.Collections.Generic;

namespace BalancedParentheses
{
    public class Program
    {
        public static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();

            int repeats = input.Length;

            Queue<char> queue = new Queue<char>(input);
            Stack<char> stack = new Stack<char>(input);

            for (int i = 0; i < input.Length; i++)
            {

                if (stack.Peek() == '{' && queue.Peek() == '}')
                {
                    stack.Pop();
                    queue.Dequeue();
                }
                else if (stack.Peek() == '}' && queue.Peek() == '{')
                {
                    stack.Pop();
                    queue.Dequeue();
                }
                else if (stack.Peek() == '(' && queue.Peek() == ')')
                {
                    stack.Pop();
                    queue.Dequeue();
                }
                else if (stack.Peek() == ')' && queue.Peek() == '(')
                {
                    stack.Pop();
                    queue.Dequeue();
                }
                else if (stack.Peek() == '[' && queue.Peek() == ']')
                {
                    stack.Pop();
                    queue.Dequeue();
                }
                else if (stack.Peek() == ']' && queue.Peek() == '[')
                {
                    stack.Pop();
                    queue.Dequeue();
                }
                else if (stack.Peek() == ' ' && queue.Peek() == ' ')
                {
                    stack.Pop();
                    queue.Dequeue();
                }
            }

            if (stack.Any())
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }

        }
    }
}