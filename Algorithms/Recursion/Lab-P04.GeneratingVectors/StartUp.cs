using System;

namespace Lab_P04.GeneratingVectors
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int[] vector = new int[number];
            GenerateVector(vector, 0);
        }

        private static void GenerateVector(int[] vector, int index)
        {
            if(index > vector.Length - 1)
            {
                Console.WriteLine(string.Join("", vector));
                return;
            }

            for (int i = 0; i <= 1; i++)
            {
                vector[index] = i;
                GenerateVector(vector, index + 1);
            }
        }
    }
}
