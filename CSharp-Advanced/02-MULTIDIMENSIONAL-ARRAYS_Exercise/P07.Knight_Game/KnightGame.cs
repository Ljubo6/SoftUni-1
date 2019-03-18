using System;
using System.Linq;

namespace P07.Knight_Game
{
    class KnightGame
    {
        static void Main()
        {
            int chessBoardSize = int.Parse(Console.ReadLine());

            char[,] chessBoard = new char[chessBoardSize, chessBoardSize];

            int knightsToRemove = 0;

            //filling in the board
            for (int i = 0; i < chessBoardSize; i++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int j = 0; j < chessBoardSize; j++)
                {
                    chessBoard[i, j] = input[j];
                }
            }

            //checks for a chessboard that is too small to allow knights to move
            if (chessBoardSize <= 2)
            {
                Console.WriteLine(0);
                return;
            }

            int knightsToFight = 0;
            int mostKnightsToFight = 0;
            int bestRow = -1;
            int bestCol = -1;

            //traversing the matrix
            while (true)
            {
                for (int row = 0; row < chessBoardSize; row++)
                {
                    for (int col = 0; col < chessBoardSize; col++)
                    {
                        char currentCell = chessBoard[row, col];
                        knightsToFight = 0;
                        

                        if (isKnightOnCurrentCell(currentCell))
                        {
                            //cheks for knights and returns their count
                            knightsToFight += CountKnightsAround(chessBoard, row, col, chessBoardSize);
                        }

                        if (knightsToFight > mostKnightsToFight )
                        {
                            mostKnightsToFight = knightsToFight;
                            bestRow = row;
                            bestCol = col;
                        }
                    }
                }

                if (mostKnightsToFight == 0)
                {
                    break;
                }
                else
                {
                    chessBoard[bestRow, bestCol] = '0';
                    knightsToRemove++;
                    knightsToFight = 0;
                    mostKnightsToFight = 0;
                    bestRow = -1;
                    bestCol = -1;
                }

            }
            Console.WriteLine(knightsToRemove);
        }

        
        private static bool isKnightOnCurrentCell(char currentCell)
        {
            return currentCell == 'K';
        }

        private static int CountKnightsAround(char[,] chessBoard, int row, int col, int chessBoardSize)
        {
            int knightFights = 0;

            //top-right move
            int topRightRow = row - 2;
            int topRightCol = col + 1;
            if (IsInside(topRightRow, topRightCol, chessBoardSize))
            {
                if (isKnightOnCurrentCell(chessBoard[topRightRow, topRightCol]))
                {
                    knightFights++;
                }
            }

            //right-top move
            int rightTopRow = row - 1;
            int rightTopCol = col + 2;
            if (IsInside(rightTopRow, rightTopCol, chessBoardSize))
            {
                if (isKnightOnCurrentCell(chessBoard[rightTopRow, rightTopCol]))
                {
                    knightFights++;
                }
            }
            //right-bottom move
            int rightBottomRow = row + 1;
            int rightBottomCol = col + 2;
            if (IsInside(rightBottomRow, rightBottomCol, chessBoardSize))
            {
                if (isKnightOnCurrentCell(chessBoard[rightBottomRow, rightBottomCol]))
                {
                    knightFights++;
                }
            }

            //bottom-right move
            int bottomRightRow = row + 2;
            int bottomRightCol = col + 1;
            if (IsInside(bottomRightRow, bottomRightCol, chessBoardSize))
            {
                if (isKnightOnCurrentCell(chessBoard[bottomRightRow, bottomRightCol]))
                {
                    knightFights++;
                }
            }

            //bottom-left move
            int bottomLeftRow = row + 2;
            int bottomLeftCol = col - 1;
            if (IsInside(bottomLeftRow, bottomLeftCol, chessBoardSize))
            {
                if (isKnightOnCurrentCell(chessBoard[bottomLeftRow, bottomLeftCol]))
                {
                    knightFights++;
                }
            }

            //left-bottom move
            int leftBottomRow = row + 1;
            int leftBottomCol = col - 2;
            if (IsInside(leftBottomRow, leftBottomCol, chessBoardSize))
            {
                if (isKnightOnCurrentCell(chessBoard[leftBottomRow, leftBottomCol]))
                {
                    knightFights++;
                }
            }

            //left-top move
            int leftTopRow = row - 1;
            int leftTopCol = col - 2;
            if (IsInside(leftTopRow, leftTopCol, chessBoardSize))
            {
                if (isKnightOnCurrentCell(chessBoard[leftTopRow, leftTopCol]))
                {
                    knightFights++;
                }
            }
            //top-left move
            int topLeftRow = row - 2;
            int topLeftCol = col - 1;
            if (IsInside(topLeftRow, topLeftCol, chessBoardSize))
            {
                if (isKnightOnCurrentCell(chessBoard[topLeftRow, topLeftCol]))
                {
                    knightFights++;
                }
            }
            return knightFights; 
        }

        private static bool IsInside(int row, int col, int chessBoardSize)
        {
            return row >= 0 && row < chessBoardSize && col >= 0 && col < chessBoardSize;
        }
    }
}
