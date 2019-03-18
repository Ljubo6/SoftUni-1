using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Odd_Occurances
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine().ToLower().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var dict = new Dictionary<string, int>();

            for (int i = 0; i < words.Count; i++)
            {
                if (dict.ContainsKey(words[i]) == true)
                {
                    dict[words[i]]++;
                }
                else
                {
                    dict[words[i]] = 1;
                }
            }

            List<string> result = new List<string>();

            foreach (var kvp in dict)
            {
                if (kvp.Value % 2 == 1)
                {
                    result.Add(kvp.Key);
                }
            }
            Console.Write(string.Join(", ", result));
            Console.WriteLine();
        }
    }
}
