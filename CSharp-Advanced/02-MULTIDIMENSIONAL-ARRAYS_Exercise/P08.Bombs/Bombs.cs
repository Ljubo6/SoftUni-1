using System;
using System.Linq;

namespace P08.Bombs
{
    class Bombs
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[,] matrix = new int[matrixSize, matrixSize];

            for (int i = 0; i < matrixSize; i++)
            {
                int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int j = 0; j < matrixSize; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            string[] bombs = Console.ReadLine().Split();

            for (int i = 0; i < bombs.Length; i++)
            {
                int[] currentBombLocation = bombs[i].Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int row = currentBombLocation[0];
                int col = currentBombLocation[1];

                if(IsInside(matrixSize, row, col) && matrix[row, col] > 0)
                {
                    int bombValue = matrix[row, col];
                    matrix[row, col] = 0;

                    //top cell
                    if(IsAliveAndInside(matrix, matrixSize, row-1, col))
                    {
                        matrix[row - 1, col] -= bombValue;
                    }
                    //right top diagonal
                    if (IsAliveAndInside(matrix, matrixSize, row - 1, col+1))
                    {
                        matrix[row - 1, col+1] -= bombValue;
                    }
                    //right cell
                    if (IsAliveAndInside(matrix, matrixSize, row, col+1))
                    {
                        matrix[row, col+1] -= bombValue;
                    }
                    //right bottom diagonal
                    if (IsAliveAndInside(matrix, matrixSize, row + 1, col+1))
                    {
                        matrix[row + 1, col + 1] -= bombValue;
                    }
                    //bottom cell
                    if (IsAliveAndInside(matrix, matrixSize, row + 1, col))
                    {
                        matrix[row + 1, col] -= bombValue;
                    }
                    //left bottom diagonal
                    if (IsAliveAndInside(matrix, matrixSize, row + 1, col - 1))
                    {
                        matrix[row + 1, col - 1] -= bombValue;
                    }
                    //left cell
                    if (IsAliveAndInside(matrix, matrixSize, row, col - 1))
                    {
                        matrix[row, col - 1] -= bombValue;
                    }
                    //top left diagonal
                    if (IsAliveAndInside(matrix, matrixSize, row - 1, col-1))
                    {
                        matrix[row - 1, col-1] -= bombValue;
                    }
                }
            }

            int sumOfAliveCells = 0;
            int countOfAliveCells = 0;

            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    int currentCell = matrix[row, col];

                    if (currentCell > 0)
                    {
                        sumOfAliveCells += currentCell;
                        countOfAliveCells++;
                    }
                }
            }

            Console.WriteLine($"Alive cells: {countOfAliveCells}");
            Console.WriteLine($"Sum: {sumOfAliveCells}");

            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static bool IsAliveAndInside(int[,] matrix, int matrixSize, int row, int col)
        {
            if (IsInside(matrixSize, row, col))
            {
                return matrix[row, col] > 0;
            }

            return false;
        }

        private static bool IsInside(int matrixSize, int row, int col)
        {
            return row >= 0 && row < matrixSize && col >= 0 && col < matrixSize;
        }
    }
}
