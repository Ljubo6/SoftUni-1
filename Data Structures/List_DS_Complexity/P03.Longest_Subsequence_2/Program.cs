using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.Longest_Subsequence_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int bestLength = 1;
            int bestNumber = numbers[0];
            int currentLength = 1;
            int currentNumber = int.MinValue;

            
            for (int i = 0; i < numbers.Length-1; i++)
            {
               currentNumber = numbers[i];

                if (currentNumber == numbers[i+1])
                {
                    currentLength++;

                    if (currentLength > bestLength)
                    {
                        bestLength = currentLength;
                        bestNumber = currentNumber;
                    }
                }
                else
                {
                    currentLength = 1;
                }
            }

            for (int i = 0; i < bestLength; i++)
            {
                Console.Write(bestNumber + " ");
            }
            Console.WriteLine();
        }
    }
}
