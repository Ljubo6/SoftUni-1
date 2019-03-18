using System;
using System.Linq;

namespace _02.Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstArray = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string[] secondArray = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for (int i = 0; i < secondArray.Length; i++)
            {
                if (firstArray.Contains(secondArray[i]))
                {
                    Console.Write(secondArray[i] + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
