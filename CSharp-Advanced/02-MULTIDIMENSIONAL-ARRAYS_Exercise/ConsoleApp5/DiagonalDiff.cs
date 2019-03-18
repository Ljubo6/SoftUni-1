using System;
using System.Linq;

namespace P01
{
    class DiagonalDiff
    {
        static void Main()
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[,] matrix = new int[matrixSize,matrixSize];

            for (int i = 0; i < matrixSize; i++)
            {
                int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int j = 0; j < matrixSize; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            long diagonal = 0L;
            int lastIndex = matrixSize - 1;

            for (int i = 0; i < matrixSize; i++)
            {
                diagonal += matrix[i, i];
            }

            for (int i = lastIndex; i >= 0; i--)
            {
                diagonal -= matrix[i, lastIndex - i];
            }

            Console.WriteLine(Math.Abs(diagonal));
        }
    }
}
