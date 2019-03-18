using System;
using System.Collections.Generic;
using System.Linq;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, int>();
            dict.Add("a", 5);
            dict.Add("ab", 5);
            dict.Add("b", 3);
            dict.Add("c", 10);
            dict.Add("d", 1);
            dict.Add("de", 2);

            dict = dict
                .OrderByDescending(x => x.Value)
                .OrderByDescending(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key} --- {kvp.Value}");
            }
        }
    }
}
