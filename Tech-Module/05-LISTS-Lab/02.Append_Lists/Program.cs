using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Append_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> tokens = Console.ReadLine().Split('|').ToList();

            for (int i = tokens.Count - 1; i >= 0; i--)
            {
                string[] resultSet = tokens[i]
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int a = 0; a < resultSet.Length; a++)
                {
                    Console.Write(resultSet[a] + " ");
                }
                
            }
        }
    }
}
