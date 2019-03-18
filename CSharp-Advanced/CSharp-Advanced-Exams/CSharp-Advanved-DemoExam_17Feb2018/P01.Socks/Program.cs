using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.Socks
{
    public class Program
    {
        public static void Main()
        {
            List<int> pairs = new List<int>();

            int[] leftSockInput = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] rightSockInput = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> leftSocks = new Stack<int>(leftSockInput);
            Queue<int> rightSocks = new Queue<int>(rightSockInput);

            while (leftSocks.Any() && rightSocks.Any())
            {
                int curentLeftSock = leftSocks.Pop();
                int currentRightSock = rightSocks.Peek();

                if (curentLeftSock > currentRightSock)
                {
                    pairs.Add(curentLeftSock + rightSocks.Dequeue());
                }
                else if (currentRightSock == curentLeftSock)
                {
                    int incrementedSock = curentLeftSock + 1;
                    leftSocks.Push(incrementedSock);
                    rightSocks.Dequeue();
                }
            }

            Console.WriteLine(pairs.Max());
            Console.WriteLine(string.Join(' ', pairs));
        }
    }
}
