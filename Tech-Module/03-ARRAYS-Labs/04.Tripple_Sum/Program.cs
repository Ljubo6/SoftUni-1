using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Tripple_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int matchCounter = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int a = i + 1; a < numbers.Length; a++)
                {
                    for (int c = 0; c < numbers.Length; c++)
                    {
                        if (numbers[i] + numbers[a] == numbers[c])
                        {
                            Console.WriteLine($"{numbers[i]} + {numbers[a]} == {numbers[c]}");
                            matchCounter++;
                        }
                        
                    }
                }
            }

           if (matchCounter == 0)
            {
                Console.WriteLine("No");
            }
        }
    }
}
