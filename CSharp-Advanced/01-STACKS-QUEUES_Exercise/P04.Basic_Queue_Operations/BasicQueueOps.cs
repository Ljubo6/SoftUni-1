using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.Basic_Queue_Operations
{
    class BasicQueueOps
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int dequeue = input[1];
            int toSearch = input[2];

            int[] numbersToEnqueue = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < numbersToEnqueue.Length; i++)
            {
                queue.Enqueue(numbersToEnqueue[i]);
            }

            for (int i = 0; i < dequeue; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }

            if (IsPresent(queue, toSearch))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }

        private static bool IsPresent(Queue<int> queue, int toSearch)
        {
            return queue.Contains(toSearch);
        }
    }
}
