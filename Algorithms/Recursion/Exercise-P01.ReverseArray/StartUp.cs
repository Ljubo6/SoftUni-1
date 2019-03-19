using System;
using System.Linq;

namespace Exercise_P01.ReverseArray
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Print(array, 0);
            Console.WriteLine();
        }

        private static void Print(int[] array, int index)
        {
            if(index == array.Length)
            {
                return;
            }

            Print(array, index + 1);
            Console.Write(array[index] + " ");
        }
    }
}
