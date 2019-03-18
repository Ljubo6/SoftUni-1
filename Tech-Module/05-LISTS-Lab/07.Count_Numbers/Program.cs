using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Count_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(new char[] { ' ' })
                .Select(int.Parse)
                .ToList();

            int[] counter = new int[1001];

            for (int i = 0; i < numbers.Count; i++)
            {
                int currentNumber = numbers[i];
                counter[currentNumber]++;
            }

            for (int i = 0; i < counter.Length; i++)
            {
                if (counter[i] > 0)
                {
                    Console.WriteLine($"{i} -> {counter[i]}");
                }
                
            }
        }
    }
}
