using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.Periodic_Table
{
    class PeriodicTable
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            HashSet<string> table = new HashSet<string>();

            for (int i = 0; i < lines; i++)
            {
                string[] elements = Console.ReadLine().Split();
                for (int j = 0; j < elements.Length; j++)
                {
                    table.Add(elements[j]);
                }
            }

            table = table.OrderBy(x => x).ToHashSet();

            Console.WriteLine(string.Join(" ", table));
        }
    }
}
