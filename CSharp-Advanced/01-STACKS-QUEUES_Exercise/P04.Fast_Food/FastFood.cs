using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.Fast_Food
{
    class FastFood
    {
        static void Main()
        {
            int initialQuantity = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> customers = new Queue<int>(orders);
            int biggestCustomer = customers.Max();

            while (customers.Any())
            {
                if (initialQuantity - customers.Peek() >= 0)
                {
                    initialQuantity -= customers.Dequeue();
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(biggestCustomer);
            if (customers.Count == 0)
            {
                Console.WriteLine("Orders complete");
                return;
            }

            Console.WriteLine("Orders left: " + string.Join(' ', customers));
        }
    }
}
