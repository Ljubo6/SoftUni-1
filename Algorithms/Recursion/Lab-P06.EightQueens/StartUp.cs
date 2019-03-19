using System;
using System.Collections.Generic;

namespace Lab_P06.EightQueens
{
    public class StartUp
    {
        const int Size = 8;
        static bool[,] chessBoard = new bool[Size, Size];
        static HashSet<int> attackedRows = new HashSet<int>();
        static List<int> attackedCols = new List<int>();
        static HashSet<int> attackedLeftDiagonal = new HashSet<int>();
        static HashSet<int> attackedRightDiagonal = new HashSet<int>();
        static int queensPlaced = 0;

        public static void Main(string[] args)
        {
            for (int row = 0; row < Size; row++)
            {
                Solve(row);
            }
        }

        private static void Solve(int row)
        {
            if (row == Size)
            {
                if (queensPlaced == 8)
                {
                    Print();
                }
                return;
            }

            for (int col = 0; col < Size; col++)
            {
                if (CanPlaceQueen(row, col))
                {
                    PlaceQueen(row, col);
                    queensPlaced++;
                    MarkFieldUnderAttack(row, col);
                    Solve(row + 1);
                    RemoveQueen(row, col);
                    queensPlaced--;
                    UnmarkField(row, col);
                }
            }
        }

        private static void RemoveQueen(int row, int col)
        {
            chessBoard[row, col] = false;
        }

        private static void Print()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                   if(chessBoard[row, col])
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static void UnmarkField(int row, int col)
        {
            attackedRows.Remove(row);
            attackedCols.Remove(col);
            attackedRightDiagonal.Remove(row + col);
            attackedLeftDiagonal.Remove(row - col);
        }

        private static bool CanPlaceQueen(int row, int col)
        {
            if (attackedRows.Contains(row))
            {
                return false;
            }

            if (attackedCols.Contains(col))
            {
                return false;
            }

            if(attackedRightDiagonal.Contains(row + col))
            {
                return false;
            }

            if(attackedLeftDiagonal.Contains(row - col))
            {
                return false;
            }

            return true;
        }

        private static void MarkFieldUnderAttack(int row, int col)
        {
            attackedRows.Add(row);
            attackedCols.Add(col);
            attackedRightDiagonal.Add(row + col);
            attackedLeftDiagonal.Add(row - col);
        }
        
        private static void PlaceQueen(int row, int col)
        {
            chessBoard[row, col] = true;
        }
    }
}
