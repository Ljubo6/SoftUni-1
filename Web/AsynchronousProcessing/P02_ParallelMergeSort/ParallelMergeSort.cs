using System;
using System.Threading.Tasks;

namespace P02_ParallelMergeSort
{
    public class ParallelMergeSort<T> where T : IComparable
    {
        public static async Task<T[]> Sort(T[] array)
        {
            if (array.Length == 1)
            {
                return array;
            }

            var middleIndex = array.Length / 2;

            var firstPart = new T[middleIndex];
            var secondPart = new T[array.Length - middleIndex];

            for (int i = 0; i < middleIndex; i++)
            {
                firstPart[i] = array[i];
            }

            for (int i = middleIndex; i < array.Length; i++)
            {
                secondPart[i - middleIndex] = array[i];
            }

            firstPart = await Task.Run(() => Sort(firstPart));
            secondPart = await Task.Run(() => Sort(secondPart));

            array = Merge(firstPart, secondPart);

            return array;
        }

        private static T[] Merge(T[] leftPart, T[] rightPart)
        {
            var helperArray = new T[leftPart.Length + rightPart.Length];
            int leftIndex = 0;
            int rightIndex = 0;

            for (int i = 0; i < helperArray.Length; i++)
            {
                if(leftIndex >= leftPart.Length)
                {
                    helperArray[i] = rightPart[rightIndex++];
                }
                else if(rightIndex >= rightPart.Length)
                {
                    helperArray[i] = leftPart[leftIndex++];
                }
                else if (IsLess(leftPart[leftIndex], rightPart[rightIndex]))
                {
                    helperArray[i] = leftPart[leftIndex++];
                }
                else
                {
                    helperArray[i] = rightPart[rightIndex++];
                }
            }

            return helperArray;
        }

        private static bool IsLess(T first, T second)
        {
            return first.CompareTo(second) <= 0;
        }
    }
}
