using System;
using System.Linq;

namespace _04.Array_rotations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] resultSet = new int[numbers.Length];
            int rotationsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbers.Length; i++)
            {
                resultSet[i] = numbers[(numbers.Length + rotationsCount + i) % numbers.Length];
            }
            Console.WriteLine(String.Join(' ', resultSet));
        }
    }
}
