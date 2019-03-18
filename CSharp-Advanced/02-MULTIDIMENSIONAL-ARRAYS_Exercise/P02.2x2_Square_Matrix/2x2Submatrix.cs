using System;
using System.Linq;

namespace P02._2x2_Square_Matrix
{
    class Submatrix_2x2
    {
        public static void Main()
        {
            int[] matrixSize = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = matrixSize[0];
            int cols = matrixSize[1];

            char[,] letters = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                char[] currentRow = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();

                for (int j = 0; j < cols; j++)
                {
                    letters[i, j] = currentRow[j];
                }
            }

            int count = 0;

            for (int row = 0; row < letters.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < letters.GetLength(1) - 1; col++)
                {
                    char currentChar = letters[row, col];
                    char rightChar = letters[row, col + 1];
                    char bottomChar = letters[row + 1, col];
                    char diagonalChar = letters[row + 1, col + 1];

                    if (currentChar == rightChar && rightChar == bottomChar && bottomChar == diagonalChar)
                    {
                        count++;
                    }
                }
            }
            
                Console.WriteLine(count);
        }
    }
}
