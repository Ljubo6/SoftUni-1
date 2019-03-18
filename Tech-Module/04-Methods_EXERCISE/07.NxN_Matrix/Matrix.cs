using System;

namespace _07.NxN_Matrix
{
    class Matrix
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PrintingMatrix(n);
        }

        private static void PrintingMatrix(int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(n + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
