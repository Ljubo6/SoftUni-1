using System;
using System.Collections.Generic;

namespace P02.Calculate_Sequence
{
    class Sequence
    {
        static void Main(string[] args)
        {
            Queue<long> queue = new Queue<long>();
            List<long> result = new List<long>();

            long startingNumber = long.Parse(Console.ReadLine());
            queue.Enqueue(startingNumber);
            result.Add(startingNumber);

            for (int i = 0; i < 17; i++)
            {
                startingNumber = queue.Dequeue();

                queue.Enqueue(startingNumber + 1);
                result.Add(startingNumber + 1);
                queue.Enqueue(startingNumber * 2 + 1);
                result.Add(startingNumber * 2 + 1);

                queue.Enqueue(startingNumber + 2);
                result.Add(startingNumber + 2);
            }

            for (int i = 0; i < 49; i++)
            {
                Console.Write($"{result[i]}, ");
            }
            Console.WriteLine(result[49]);
        }
    }
}
