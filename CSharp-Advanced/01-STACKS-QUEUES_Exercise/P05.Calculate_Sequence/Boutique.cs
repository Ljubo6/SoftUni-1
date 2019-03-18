using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.Fashion_Boutique
{
    class Boutique
    {
        static void Main()
        {
            int[] parcel = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rackCapacity = int.Parse(Console.ReadLine());
            int rackCount = 1;

            Stack<int> clothes = new Stack<int>(parcel);

            int currentRack = rackCapacity;

            while (clothes.Any())
            {
                if (currentRack - clothes.Peek() >= 0)
                {
                    currentRack -= clothes.Pop();
                    continue;
                }
                else
                {
                    rackCount++;
                    currentRack = rackCapacity;
                    currentRack -= clothes.Pop();
                }
            }
            Console.WriteLine(rackCount);
        }
    }
}