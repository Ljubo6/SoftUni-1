using System;
using System.Linq;

namespace _08.Magic_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int testNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int a = i + 1; a < numbers.Length; a++)
                {
                    if (numbers[i] + numbers[a] == testNumber)
                    {
                        Console.WriteLine(numbers[i] + " " + numbers[a]);
                    }
                }
            }
        }
    }
}
