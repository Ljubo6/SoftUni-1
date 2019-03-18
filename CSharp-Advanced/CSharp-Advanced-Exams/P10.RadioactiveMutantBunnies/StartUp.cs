using System;
using System.Linq;

namespace P10.RadioactiveMutantBunnies
{
    public class StartUp
    {
        public static void Main()
        {
            int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = sizes[0];
            int cols = sizes[1];
            char[,] field = new char[rows, cols];
            PopulateField(field);
           
            bool[] playerState = new bool[2];
            playerState[0] = false; // <- escaped safely
            playerState[1] = false; // <- killed by bunny

            int[] playerPosition = new int[2];
            FindPlayerOnField(field, playerPosition);

            char[] movingDirections = Console.ReadLine().ToCharArray();

            foreach (var command in movingDirections)
            {
                MovePlayer(field, command, playerPosition, playerState);
                
                SpreadBunnies(field, playerPosition, playerState);

                if (playerState[0] == true)
                {
                    PrintField(field);
                    Console.WriteLine($"won: {playerPosition[0]} {playerPosition[1]}");
                    return;
                }

                if (playerState[1] == true)
                {
                    PrintField(field);
                    Console.WriteLine($"dead: {playerPosition[0]} {playerPosition[1]}");
                    return;
                }
            }
        }

        private static void SpreadBunnies(char[,] field, int[] playerPosition, bool[] playerState)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col] == 'B')
                    {
                        if (row + 1 < field.GetLength(0))
                        {
                            if(field[row + 1, col] == 'P')
                            {
                                playerState[1] = true;
                            }

                            if (field[row + 1, col] == '.')
                            {
                                field[row + 1, col] = 'b';
                            }
                        }
                        if (row - 1 >= 0)
                        {
                            if (field[row - 1, col] == 'P')
                            {
                                playerState[1] = true;
                            }

                            if (field[row - 1, col] == '.')
                            {
                                field[row - 1, col] = 'b';
                            }
                        }
                        if (col + 1 < field.GetLength(1))
                        {
                            if (field[row, col + 1] == 'P')
                            {
                                playerState[1] = true;
                            }

                            if (field[row, col + 1] == '.')
                            {
                                field[row, col + 1] = 'b';
                            }
                        }
                        if (col - 1 >= 0)
                        {
                            if (field[row, col - 1] == 'P')
                            {
                                playerState[1] = true;
                            }

                            if (field[row, col - 1] == '.')
                            {
                                field[row, col - 1] = 'b';
                            }
                        }
                    }
                }
            }

            if (playerState[1] == true)
            {
                field[playerPosition[0], playerPosition[1]] = 'B';
            }

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col] == 'b')
                    {
                        field[row, col] = 'B';
                    }
                }
            }
        }
        
        private static void MovePlayer(char[,] field, char command, int[] playerPosition, bool[] playerState)
        {
            field[playerPosition[0], playerPosition[1]] = '.';

            switch (command)
            {
                case 'U':
                    if (playerPosition[0] - 1 < 0)
                    {
                        playerState[0] = true;
                    }
                    else
                    {
                        playerPosition[0]--;
                        IsPlayerKilledByBunny(field, playerPosition, playerState);
                    }
                    break;
                case 'D':
                    if (playerPosition[0] + 1 >= field.GetLength(0))
                    {
                        playerState[0] = true;
                    }
                    else
                    {
                        playerPosition[0]++;
                        IsPlayerKilledByBunny(field, playerPosition, playerState);
                    }
                    break;
                case 'L':
                    if (playerPosition[1] - 1 < 0)
                    {
                        playerState[0] = true;
                    }
                    else
                    {
                        playerPosition[1]--;
                        IsPlayerKilledByBunny(field, playerPosition, playerState);
                    }
                    break;
                case 'R':
                    if (playerPosition[1] + 1 >= field.GetLength(1))
                    {
                        playerState[0] = true;
                    }
                    else
                    {
                        playerPosition[1]++;
                        IsPlayerKilledByBunny(field, playerPosition, playerState);
                    }
                    break;
                default:
                    break;
            }
        }

        public static void IsPlayerKilledByBunny(char[,] field, int[] playerPosition, bool[] playerState)
        {
            if (field[playerPosition[0], playerPosition[1]] == 'B')
            {
                playerState[1] = true;
            }
            else
            {
                field[playerPosition[0], playerPosition[1]] = 'P';
            }
        }

        public static void FindPlayerOnField(char[,] field, int[] playerPosition)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col] == 'P')
                    {
                        playerPosition[0] = row;
                        playerPosition[1] = col;
                    }
                }
            }
        }

        public static void PopulateField(char[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                var currentRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = currentRow[col];
                }
            }
        }

        public static void PrintField(char[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
