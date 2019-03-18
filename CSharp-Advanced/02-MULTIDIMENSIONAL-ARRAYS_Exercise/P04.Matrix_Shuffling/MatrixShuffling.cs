using System;
using System.Linq;

namespace P04.Matrix_Shuffling
{
    class MatrixShuffling
    {
        public static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = matrixSize[0];
            int cols = matrixSize[1];

            string[,] matrix = new string[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string[] currentRow = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] currentCommand = input.Split().ToArray();

                if (currentCommand.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    input = Console.ReadLine();
                    continue;
                }

                string command = currentCommand[0];
                int swappedRow = int.Parse(currentCommand[1]);
                int swappedCol = int.Parse(currentCommand[2]);
                int swappingRow = int.Parse(currentCommand[3]);
                int swappingCol = int.Parse(currentCommand[4]);

                if (command == "swap" && 
                    swappedRow >= 0 && swappedRow < matrix.GetLength(0) &&
                    swappingRow >= 0 && swappingRow < matrix.GetLength(0) &&
                    swappedCol >= 0 && swappedCol < matrix.GetLength(1) &&
                    swappingCol >= 0 && swappingCol < matrix.GetLength(1))
                {
                    string swappedCell = matrix[swappedRow, swappedCol];
                    string swappingCell = matrix[swappingRow, swappingCol];
                    matrix[swappedRow, swappedCol] = swappingCell;
                    matrix[swappingRow, swappingCol] = swappedCell;

                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            Console.Write(matrix[row, col] + " ");
                        }
                        Console.WriteLine();
                    }
                }

                else
                {
                    Console.WriteLine("Invalid input!");
                }

                input = Console.ReadLine();
            }
        }
    }
}
