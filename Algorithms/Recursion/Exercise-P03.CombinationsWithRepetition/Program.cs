using System;

namespace Exercise_P03.CombinationsWithRepetition
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int[] vector = new int[k];
            GenerateCombination(vector, n, 0, 1);


        }

        private static void GenerateCombination(int[] vector, int n, int index, int start)
        {
            if (index == vector.Length)
            {
                Console.WriteLine(string.Join(" ", vector));
                return;
            }

            for (int i = start; i <= n; i++)
            {
                vector[index] = i;
                GenerateCombination(vector, n, index + 1, i);
            }
        }
    }
}