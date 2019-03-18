using System;
using System.Linq;

namespace P07.Labyrinth
{
    class LongestPathLabyrinth
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            string[,] labyrinth = new string[matrixSize, matrixSize];

            for (int i = 0; i < matrixSize; i++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();

                for (int j = 0; j < matrixSize; j++)
                {
                    labyrinth[i, j] = currentRow[j].ToString();
                }
            }

            int curentNumber = 0;

            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    string currentElement = labyrinth[row, col];
                    int currentRow = row;
                    int currentColumn = col;

                    if (currentElement == "*")
                    {
                        MoveAround(currentRow, currentColumn, labyrinth, curentNumber);
                        break;
                    }
                }
            }

            curentNumber++;

            while (curentNumber <= matrixSize * matrixSize / 2 + 1)
            {
                for (int row = 0; row < labyrinth.GetLength(0); row++)
                {
                    for (int col = 0; col < labyrinth.GetLength(1); col++)
                    {
                        string currentElement = labyrinth[row, col];
                        int currentRow = row;
                        int currentColumn = col;

                        if (currentElement == curentNumber.ToString())
                        {
                            MoveAround(currentRow, currentColumn, labyrinth, curentNumber);
                        }
                    }
                }
                curentNumber++;
            }


            for (int i = 0; i < labyrinth.GetLength(0); i++)
            {
                for (int a = 0; a < labyrinth.GetLength(1); a++)
                {
                    if (labyrinth[i, a] == "0")
                    {
                        Console.Write("u");
                    }
                    else
                    {
                        Console.Write(labyrinth[i, a]);
                    }
                }
                Console.WriteLine();
            }
        }

        public static void MoveAround(int currentRow, int currentColumn, string[,] labyrinth, int currentNumber)
        {
            GoUp(currentRow, currentColumn, labyrinth, currentNumber);
            GoRight(currentRow, currentColumn, labyrinth, currentNumber);
            GoDown(currentRow, currentColumn, labyrinth, currentNumber);
            GoLeft(currentRow, currentColumn, labyrinth, currentNumber);
        }

        private static void GoLeft(int currentRow, int currentColumn, string[,] labyrinth, int currentNumber)
        {
            if (currentColumn - 1 >= 0 && labyrinth[currentRow, currentColumn - 1] == "0")
            {
                labyrinth[currentRow, currentColumn - 1] = (currentNumber + 1).ToString();
            }
        }

        private static void GoDown(int currentRow, int currentColumn, string[,] labyrinth, int currentNumber)
        {
            if (currentRow + 1 < labyrinth.GetLength(0) && labyrinth[currentRow + 1, currentColumn] == "0")
            {
                labyrinth[currentRow + 1, currentColumn] = (currentNumber + 1).ToString();
            }
        }

        private static void GoRight(int currentRow, int currentColumn, string[,] labyrinth, int currentNumber)
        {
            if (currentColumn + 1 < labyrinth.GetLength(1) && labyrinth[currentRow, currentColumn + 1] == "0")
            {
                labyrinth[currentRow, currentColumn + 1] = (currentNumber + 1).ToString();
            }
        }

        public static void GoUp(int currentRow, int currentColumn, string[,] labyrinth, int currentNumber)
        {
            if (currentRow - 1 >= 0 && labyrinth[currentRow - 1, currentColumn] == "0")
            {
                labyrinth[currentRow - 1, currentColumn] = (currentNumber + 1).ToString();
            }
        }
    }
}
