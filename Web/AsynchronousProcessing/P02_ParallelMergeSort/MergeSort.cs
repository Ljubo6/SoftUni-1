using System;

namespace P02_ParallelMergeSort
{
    public class MergeSort<T> where T : IComparable
    {
        public static void Sort(T[] arr, int startIndex, int endIndex)
        {
            if(startIndex >= endIndex)
            {
                return;
            }

            var middleIndex = (startIndex + endIndex) / 2;

            Sort(arr, startIndex, middleIndex);
            Sort(arr, middleIndex + 1, endIndex);

            Merge(arr, startIndex, middleIndex, endIndex);
        }

        private static void Merge(T[] arr, int startIndex, int middleIndex, int endIndex)
        {
            if(middleIndex < 0 || middleIndex + 1 >= arr.Length || IsLess(arr[middleIndex], arr[middleIndex + 1]))
            {
                return;
            }

            T[] aux = new T[arr.Length];

            for (int i = startIndex; i <= endIndex; i++)
            {
                aux[i] = arr[i];
            }

            int leftIndex = startIndex;
            int rightIndex = middleIndex + 1;

            for (int i = startIndex; i <= endIndex; i++)
            {
                if (leftIndex > middleIndex)
                {
                    arr[i] = aux[rightIndex++];
                }
                else if (rightIndex > endIndex)
                {
                    arr[i] = aux[leftIndex++];
                }
                else if (IsLess(aux[leftIndex], aux[rightIndex]))
                {
                    arr[i] = aux[leftIndex++];
                }
                else
                {
                    arr[i] = aux[rightIndex++];
                }
            }
        }

        private static bool IsLess(T first, T second)
        {
            return first.CompareTo(second) <= 0;
        }
    }
}
