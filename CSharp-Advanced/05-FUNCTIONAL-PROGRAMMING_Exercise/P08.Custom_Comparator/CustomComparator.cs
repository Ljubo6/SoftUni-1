using System;
using System.Linq;

namespace P08.Custom_Comparator
{
    class CustomComparator
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int, int, int> sort = (x, y) =>
                                    (x % 2 == 0 && y % 2 != 0) ? -1 :
                                    (x % 2 != 0 && y % 2 == 0) ? 1 :
                                    x.CompareTo(y);

            Action<int[]> print = num => Console.WriteLine(string.Join(' ', array));

            Array.Sort(array, new Comparison<int>(sort));

            print(array);
        }
    }
}
