using System;
using System.Linq;

namespace P04.Evens_Odds
{
    class EvensOdds
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int lowerBound = input[0];
            int upperBound = input[1];
            string filter = Console.ReadLine();

            foreach (var item in Enumerable
                .Range(lowerBound, upperBound - lowerBound + 1)
                .Where(GetValidNums(filter))
                .ToList())
            {
                Console.Write(item + " ");
            }
        }

        private static Func<int, bool> GetValidNums(string filter)
        {
            if (filter == "odd")
            {
                return number => number % 2 != 0;

            }
            else if (filter == "even")
            {
                return number => number % 2 == 0;
            }
            return null;
        }
    }
}
