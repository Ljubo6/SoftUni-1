using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Chars
{
    class CountingChars
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> chars = new Dictionary<char, int>();

            string text = Console.ReadLine();
            text = text.Replace(" ", "");
            //char[] input = text.ToCharArray();
                

            for (int i = 0; i < text.Length; i++)
            {
                if (chars.ContainsKey(text[i]) == false)
                {
                    chars.Add(text[i], 1);
                }
                else
                {
                    chars[text[i]]++;
                }
            }

            foreach (var kvp in chars)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }

        }
    }
}
