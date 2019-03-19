using System;

namespace Exercise_P02.NestedLoopsToRecursion
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] vector = new int[n];
            GenerateVector(vector, 0, n);
        }

        private static void GenerateVector(int[] vector, int index, int n)
        {
            if(index == vector.Length)
            {
                Console.WriteLine(string.Join(' ', vector));
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                vector[index] = i;
                GenerateVector(vector, index + 1, n);
            }
        }
    }
}
