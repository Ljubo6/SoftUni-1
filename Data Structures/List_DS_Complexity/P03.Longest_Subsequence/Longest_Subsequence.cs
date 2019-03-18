using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.Longest_Subsequence
{
    class Longest_Subsequence
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> result = GetLongestSubsequence(numbers).ToList();

            Console.WriteLine(string.Join(" ", result));
            
        }

        public static int[] GetLongestSubsequence(List<int> workingSet)
        {
            int bestLengthCount = 1;
            int bestLengthIndex = 0;

            int currentLengthCount = 1;
            int currentLengthIndex = 0;

            for (int i = 0; i < workingSet.Count-1; i++)
            {
                if (workingSet[i] == workingSet[i+1])
                {
                    currentLengthCount += 1;
                    currentLengthIndex = i;

                    if (currentLengthCount > bestLengthCount)
                    {
                        bestLengthCount = currentLengthCount;
                        bestLengthIndex = i - bestLengthCount + 2;
                    }
                }
                else
                {
                    currentLengthCount = 1;
                    currentLengthIndex = 0;
                }
            }

            int[] resultSet = new int[bestLengthCount];
            workingSet.CopyTo(bestLengthIndex, resultSet, 0, bestLengthCount);
            return resultSet;
        }

    }
}
