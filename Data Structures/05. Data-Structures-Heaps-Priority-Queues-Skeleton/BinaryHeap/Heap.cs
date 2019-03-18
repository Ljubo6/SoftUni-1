using System;

public static class Heap<T> where T : IComparable<T>
{
    public static void Sort(T[] arr)
    {
        int count = arr.Length;

        for (int i = count / 2; i >= 0; i--)
        {
            HeapifyDown(arr, i, count);
        }

        for (int i = count - 1; i > 0; i--)
        {
            Swap(arr, 0, i);
            HeapifyDown(arr, 0, i);
        }
    }

    private static void HeapifyDown(T[] arr, int index, int count)
    {
        while (index < count / 2)
        {
            int child = index * 2 + 1;
            
            if (child + 1 < count && isSmaller(arr, child, child + 1))
            {
                child++;
            }

            if (isSmaller(arr, child, index))
            {
                break;
            }

            Swap(arr, child, index);

            index = child;
        }
    }

    private static bool isSmaller(T[] arr, int childA, int childB)
    {
        return arr[childA].CompareTo(arr[childB]) < 0;
    }

    private static bool HasSecondChild(T[]arr, int index)
    {
        return index * 2 + 2 < arr.Length;
    }
    
    private static void Swap(T[] arr, int a, int b)
    {
        T temporal = arr[a];
        arr[a] = arr[b];
        arr[b] = temporal;
    }
}
