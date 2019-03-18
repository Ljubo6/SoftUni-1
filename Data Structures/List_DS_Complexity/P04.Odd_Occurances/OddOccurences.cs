using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.Odd_Occurences
{
    class OddOccurences
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> result = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                int timesOccured = numbers.Where(x => x == numbers[i]).ToList().Count();

                if (timesOccured % 2 == 0)
                {
                    result.Add(numbers[i]);
                }
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
