using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.Sets_Of_Elements
{
    class SetsOfElements
    {
        static void Main(string[] args)
        {
            int[] setsLenghts = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var setOne = new HashSet<int>();
            var setTwo = new HashSet<int>();

            for (int i = 0; i < setsLenghts[0]; i++)
            {
                int number = int.Parse(Console.ReadLine());
                setOne.Add(number);
            }

            for (int i = 0; i < setsLenghts[1]; i++)
            {
                int number = int.Parse(Console.ReadLine());
                setTwo.Add(number);
            }

            setOne.IntersectWith(setTwo);

            Console.WriteLine(string.Join(" ", setOne));
        }
    }
}
