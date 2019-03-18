using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.Cups_Bottles
{
    class Program
    {
        static void Main()
        {
            var cupsInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var bottlesInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var cupsQueue = new Queue<int>(cupsInput);
            var bottleStack = new Stack<int>(bottlesInput);

            long wastedLitres = 0L;

            while (cupsQueue.Any() && bottleStack.Any())
            {
                int curerntCupVolume = cupsQueue.Peek();

                while (true)
                {
                    curerntCupVolume -= bottleStack.Pop();

                    if (curerntCupVolume <= 0)
                    {
                        cupsQueue.Dequeue();
                        wastedLitres += Math.Abs(curerntCupVolume);
                        break;
                    }
                }
            }

            if(cupsQueue.Any())
            {
                Console.WriteLine($"Cups: " + string.Join(' ', cupsQueue));
            }

            if (bottleStack.Any())
            {
                Console.WriteLine($"Bottles: " + string.Join(' ', bottleStack));
            }

            Console.WriteLine($"Wasted litters of water: {wastedLitres}");
        }
    }
}
