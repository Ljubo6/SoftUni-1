using System;
using System.Linq;

namespace P09.Miner
{
    class Miner
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int indexRow = -1;
            int indexCol = -1;
            int coalCount = 0;

            char[,] field = new char[fieldSize, fieldSize];

            string[] commandsToMove = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            for (int row = 0; row < fieldSize; row++)
            {
                char[] currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < fieldSize; col++)
                {
                    field[row, col] = currentRow[col];
                    if (currentRow[col] == 'c')
                    {
                        coalCount++;
                    }
                }
            }

            for (int row = 0; row < fieldSize; row++)
            {
                for (int col = 0; col < fieldSize; col++)
                {
                    if (field[row, col] == 's')
                    {
                        indexRow = row;
                        indexCol = col;
                    }
                }
            }

            int coalCollected = 0;

            for (int i = 0; i < commandsToMove.Length; i++)
            {
                string currentCommand = commandsToMove[i];

                switch (currentCommand)
                {
                    case "up":
                        if (IsInside(field, indexRow-1, indexCol))
                        {
                            indexRow--;
                            coalCollected += HasCoal(field, indexRow, indexCol);
                            if(IsGameOver(field, indexRow, indexCol))
                            {
                                Console.WriteLine($"Game over! ({indexRow}, {indexCol})");
                                return;
                            }
                        }
                        break;
                    case "right":
                        if (IsInside(field, indexRow, indexCol+1))
                        {
                            indexCol++;
                            coalCollected += HasCoal(field, indexRow, indexCol);
                            if (IsGameOver(field, indexRow, indexCol))
                            {
                                Console.WriteLine($"Game over! ({indexRow}, {indexCol})");
                                return;
                            }
                        }
                        break;
                    case "down":
                        if (IsInside(field, indexRow+1, indexCol))
                        {
                            indexRow++;
                            coalCollected += HasCoal(field, indexRow, indexCol);
                            if (IsGameOver(field, indexRow, indexCol))
                            {
                                Console.WriteLine($"Game over! ({indexRow}, {indexCol})");
                                return;
                            }
                        }
                        break;
                    case "left":
                        if (IsInside(field, indexRow, indexCol - 1))
                        {
                            indexCol--;
                            coalCollected += HasCoal(field, indexRow, indexCol);
                            if (IsGameOver(field, indexRow, indexCol))
                            {
                                Console.WriteLine($"Game over! ({indexRow}, {indexCol})");
                                return;
                            }
                        }
                        break;
                    default:
                        break;
                }

                if (coalCollected == coalCount)
                {
                    Console.WriteLine($"You collected all coals! ({indexRow}, {indexCol})");
                    return;
                }
            }

            Console.WriteLine($"{coalCount-coalCollected} coals left. ({indexRow}, {indexCol})");
        }

        private static bool IsInside(char[,] field, int indexRow, int indexCol)
        {
            return indexRow >= 0 && indexRow < field.GetLength(0) && indexCol >= 0 && indexCol < field.GetLength(1);
        }

        private static int HasCoal(char[,] field, int indexRow, int indexCol)
        {
            if (field[indexRow, indexCol] == 'c')
            {
                field[indexRow, indexCol] ='*';
                return 1;
            }
            return 0;
        }

        private static bool IsGameOver(char[,] field, int indexRow, int indexCol)
        {
            return field[indexRow, indexCol] == 'e';
        }
    }
}
