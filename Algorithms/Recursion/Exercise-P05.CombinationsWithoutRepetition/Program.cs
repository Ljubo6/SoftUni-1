using System;

namespace Exercise_P05.CombinationsWithoutRepetition
{
    class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int[] set = new int[n];
            for (int i = 0; i < set.Length; i++)
            {
                set[i] = i + 1;
            }
            int[] vector = new int[k];
            GenerateVector(set, vector, 0, 0);
        }

        private static void GenerateVector(int[] set, int[] vector, int index, int border)
        {
            if (index == vector.Length)
            {
                Console.WriteLine(string.Join(' ', vector));
                return;
            }
            else
            {
                for (int i = border; i < set.Length; i++)
                {
                    vector[index] = i + 1;
                    GenerateVector(set, vector, index + 1, i + 1);
                }
            }
        }
    }
}
