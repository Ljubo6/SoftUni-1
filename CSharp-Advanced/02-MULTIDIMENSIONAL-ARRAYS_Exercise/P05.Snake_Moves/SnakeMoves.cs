using System;
using System.Linq;
using System.Text;

namespace P05.Snake_Moves
{
    class SnakeMoves
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = matrixSize[0];
            int cols = matrixSize[1];

            char[,] matrix = new char[rows, cols];
            
            string word = Console.ReadLine();

            double timesRepeated = Math.Ceiling((double)(rows * cols) / (double)word.Length);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < timesRepeated; i++)
            {
                sb.Append(word);
            }

            string snake = sb.ToString();
            int index = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = snake[index++];
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
