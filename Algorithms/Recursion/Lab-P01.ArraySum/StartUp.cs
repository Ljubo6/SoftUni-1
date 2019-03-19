using System;
using System.Linq;

namespace Lab_P01.ArraySum
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var array = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Console.WriteLine(Sum(array, 0));
        }

        public static long Sum(int[] array, int index)
        {
            if(index == array.Length - 1)
            {
                return array.Last();
            }

            return array[index] + Sum(array, index + 1);
        }
    }
}
