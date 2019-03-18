using System;
using System.Collections.Generic;
using System.Linq;

namespace Additional_03.TakeSkip_Rope
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            List<int> numbers = new List<int>();
            List<char> nonNumbers = new List<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (int.TryParse(input[i].ToString(), out int digit))
                {
                    numbers.Add(digit);
                }
                else
                {
                    nonNumbers.Add(input[i]);
                }
            }

            List<int> take = new List<int>();
            List<int> skip = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (i % 2 == 0)
                {
                    take.Add(numbers[i]);
                }
                else
                {
                    skip.Add(numbers[i]);
                }
            }

            string result = string.Empty;

            result += new string(nonNumbers.Take(take[0]).ToArray());
            for (int i = 0; i < take[0]; i++)
            {
                nonNumbers.RemoveAt(0);
            }

            for (int i = 1; i < take.Count; i++)
            {
                result += new string(nonNumbers.Skip(skip[i - 1]).Take(take[i]).ToArray());
                for (int a = 0; a < skip[i-1]; a++)
                {
                    nonNumbers.RemoveAt(0);
                }
                for (int b = 0; b < take[i]; b++)
                {
                    if (i < take.Count - 1)
                    {
                        nonNumbers.RemoveAt(0);

                    }
                }
            }
            Console.WriteLine(result);
        }
    }
}
