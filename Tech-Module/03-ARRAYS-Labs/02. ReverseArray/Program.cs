using System;

namespace _02.ReverseArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] numbers = new int[n];

            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            for (int a = n - 1; a >= 0; a--)
            {
                Console.Write(numbers[a] + " ");
                
            }
            Console.WriteLine();
        }
    }
}
