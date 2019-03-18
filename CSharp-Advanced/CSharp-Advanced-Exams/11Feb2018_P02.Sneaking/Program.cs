using System;
using System.Linq;

namespace _11Feb2018_P02.Sneaking
{
    public class Program
    {
        public static void Main()
        {
            int lines = int.Parse(Console.ReadLine());
            var positionSam = new int[2];

            bool isSamDead = false;
            bool isNikoladzeDead = false;

            char[][] matrix = new char[lines][];

            for (int i = 0; i < lines; i++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                matrix[i] = input;

                for (int j = 0; j < input.Length; j++)
                {
                    if (input[j] == 'S')
                    {
                        positionSam[0] = i;
                        positionSam[1] = j;
                    }
                }
            }

            char[] commands = Console.ReadLine().ToUpper().ToCharArray();

            foreach (var command in commands)
            {
                //move enemies
                isSamDead = MoveEnemies(matrix, positionSam);

                if (isSamDead)
                {
                    Console.WriteLine($"Sam died at {positionSam[0]}, {positionSam[1]}");
                    Print(matrix);
                    return;
                }

                //move Sam
                MoveSam(matrix, positionSam, command);
                isNikoladzeDead = KillNikoladze(matrix, positionSam);

                if (isNikoladzeDead)
                {
                    Console.WriteLine("Nikoladze killed!");
                    Print(matrix);
                    return;
                }
            }
        }

        public static void Print(char[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                Console.WriteLine(new string(matrix[row]));
            }
        }

        public static bool MoveEnemies(char[][] matrix, int[] positionSam)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int i = 0; i < matrix[row].Length; i++)
                {
                    if (matrix[row][i] == 'b')
                    {
                        if (i == matrix[row].Length - 1)
                        {
                            matrix[row][i] = 'd';
                            if (matrix[row].Contains('S'))
                            {
                                matrix[row][positionSam[1]] = 'X';
                                return true;
                            }
                            break;
                        }
                        else
                        {
                            if (matrix[row].Contains('S') && positionSam[1] > i)
                            {
                                matrix[row][positionSam[1]] = 'X';
                                return true;
                            }
                            else
                            {
                                matrix[row][i] = '.';
                                matrix[row][i + 1] = 'b';
                                break;
                            }
                        }
                    }

                    else if (matrix[row][i] == 'd')
                    {
                        if (i == 0)
                        {
                            matrix[row][i] = 'b';
                            if (matrix[row].Contains('S'))
                            {
                                matrix[row][positionSam[1]] = 'X';
                                return true;
                            }
                            break;
                        }
                        else
                        {
                            if (matrix[row].Contains('S') && positionSam[1] < i)
                            {
                                matrix[row][positionSam[1]] = 'X';
                                return true;
                            }
                            else
                            {
                                matrix[row][i] = '.';
                                matrix[row][i - 1] = 'd';
                                break;
                            }
                        }
                    }
                }

            }
            return false;
        }

        public static void MoveSam(char[][] matrix, int[] positionSam, char command)
        {
            switch (command)
            {
                case 'U':
                    matrix[positionSam[0]][positionSam[1]] = '.';
                    positionSam[0]--;
                    matrix[positionSam[0]][positionSam[1]] = 'S';
                    return;
                case 'D':
                    matrix[positionSam[0]][positionSam[1]] = '.';
                    positionSam[0]++;
                    matrix[positionSam[0]][positionSam[1]] = 'S';
                    return;
                case 'L':
                    matrix[positionSam[0]][positionSam[1]] = '.';
                    positionSam[1]--;
                    matrix[positionSam[0]][positionSam[1]] = 'S';
                    return;
                case 'R':
                    matrix[positionSam[0]][positionSam[1]] = '.';
                    positionSam[1]++;
                    matrix[positionSam[0]][positionSam[1]] = 'S';
                    return;
            }
        }

        public static bool KillNikoladze(char[][] matix, int[] positionSam)
        {
            char[] currentSamRow = matix[positionSam[0]];

            if (currentSamRow.Contains('N'))
            {
                for (int i = 0; i < currentSamRow.Length; i++)
                {
                    if (currentSamRow[i] == 'N')
                    {
                        currentSamRow[i] = 'X';
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
