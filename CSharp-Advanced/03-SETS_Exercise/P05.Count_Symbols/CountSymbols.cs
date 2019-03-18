using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.Count_Symbols
{
    class CountSymbols
    {
        static void Main()
        {
            string input = Console.ReadLine();

            var symbolsCount = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];

                if (!symbolsCount.ContainsKey(currentChar))
                {
                    symbolsCount.Add(currentChar, 0);
                }

                symbolsCount[currentChar]++;
            }

            foreach (var kvp in symbolsCount.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
