using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Sum_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int[] arr2 = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int length = Math.Max(arr1.Length, arr2.Length);

            for (int i = 0; i < length; i++)
            {
                Console.Write(arr1[i%arr1.Length] + arr2[i%arr2.Length] + " ");
            }
        }
    }
}
