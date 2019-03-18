using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.Sort_Words
{
    class SortingWords
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().Split().ToList();
            words = words.OrderBy(x => x).ToList();
            Console.WriteLine(string.Join(" ", words));
        }
    }
}
