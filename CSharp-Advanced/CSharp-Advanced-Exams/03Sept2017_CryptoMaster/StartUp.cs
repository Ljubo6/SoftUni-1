using System;
using System.Collections.Generic;
using System.Linq;

namespace _03Sept2017_P02.CryptoMaster
{
    public class Program
    {
        public static void Main()
        {
            int longestSequenceCount = 1;

            int[] numbers = Console
                .ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int index = 0; index < numbers.Length; index++)
            {
                for (int step = 1; step < numbers.Length; step++)
                {
                    int currentIndex = index;
                    int nextIndex = (index + step) % numbers.Length;
                    int curentSequenceCount = 1;

                    while (numbers[nextIndex] > numbers[index])
                    {
                        curentSequenceCount++;
                        if (curentSequenceCount > longestSequenceCount)
                        {
                            longestSequenceCount = curentSequenceCount;
                        }

                        currentIndex = nextIndex;
                        nextIndex = (currentIndex + step) % numbers.Length;
                    }
                }
            }
            Console.WriteLine(longestSequenceCount);
        }
    }
}

