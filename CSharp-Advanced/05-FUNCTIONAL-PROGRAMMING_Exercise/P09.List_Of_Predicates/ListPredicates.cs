using System;
using System.Collections.Generic;
using System.Linq;

namespace P09.List_Of_Predicates
{
    class ListPredicates
    {
        static void Main(string[] args)
        {
            int upperBound = int.Parse(Console.ReadLine());
            HashSet<int> dividersInput = Console.ReadLine().Split().Select(int.Parse).ToHashSet();
            int[] dividers = dividersInput.ToArray();
            List<int> result = new List<int>();

            Action<List<int>> print = p => Console.WriteLine(string.Join(' ', p));

            for (int i = 1; i <= upperBound; i++)
            {
                result.Add(i);
            }

            for (int j = 0; j < dividers.Length; j++)
            {
                result = result.Where(x => x % dividers[j] == 0).ToList();
            }    

            print(result);
        }
    }
}
