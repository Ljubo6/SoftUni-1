using System;
using System.Numerics;

namespace ConsoleApp1
{
    class Program
    {
        static void Generate(int number, int[] arr)
        {
            if (number == arr.Length)
            {
                Console.WriteLine(string.Join(' ', arr));
            }
            else
            {
                for (int i = 0; i <= 1; i++)
                {
                    arr[number] = i;
                    Generate(number + 1, arr);
                }

            }
        }

        static void Main(string[] args)
        {
            int[] arr = new int[8];
            Generate(0, arr);
        }
    }
}
