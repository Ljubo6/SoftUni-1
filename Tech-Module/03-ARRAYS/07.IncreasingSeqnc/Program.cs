using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.MaxSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sequence = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int startIndex = 0;
            int currentLen = 1;
            int bestLen = 1;
            int bestStart = 0;

            for (int index = 1; index < sequence.Length; index++)
            {
                if (sequence[index] > sequence[index - 1])
                {
                    currentLen++;
                    if (currentLen > bestLen)
                    {
                        bestLen = currentLen;
                        bestStart = startIndex;
                    }
                }
                else
                {
                    startIndex = index;
                    currentLen = 1;
                }
            }
            for (int i = bestStart; i < bestStart + bestLen; i++)
            {
                Console.Write(sequence[i] + " ");
            }
        }
    }
}
