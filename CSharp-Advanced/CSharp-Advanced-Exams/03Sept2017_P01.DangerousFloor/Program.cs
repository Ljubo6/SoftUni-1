using System;
using System.Linq;

namespace _03Sept2017_P01.DangerousFloor
{
    public class Program
    {
        public static void Main()
        {
            string[,] board = new string[8, 8];
            ReadBoard(board);

            string move = Console.ReadLine();

            while (move != "END")
            {
                string piece = move[0].ToString();
                int startRow = int.Parse(move[1].ToString());
                int startCol = int.Parse(move[2].ToString());
                int destinationRow = int.Parse(move[4].ToString());
                int destinationCol = int.Parse(move[5].ToString());

                if(CheckForPieceAtPosition(board, piece, startRow, startCol)) // the piece IS at the position
                {
                    if(IsMoveInsideBoard(destinationRow, destinationCol)) // the move IS inside the board
                    {
                        if(CanPieceMove(piece, startRow, startCol, destinationRow, destinationCol)) // the piece CAN make the move
                        {
                            MovePiece(board, piece, startRow, startCol, destinationRow, destinationCol); // UPDATE the board after move
                        }
                        else
                        {
                            Console.WriteLine("Invalid move!");
                            move = Console.ReadLine();
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Move go out of board!");
                        move = Console.ReadLine();
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("There is no such a piece!");
                    move = Console.ReadLine();
                    continue;
                }

                move = Console.ReadLine();
            }
        }

        public static void ReadBoard(string[,] board)
        {
            for (int row = 0; row < 8; row++)
            {
                string[] line = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < 8; col++)
                {
                    board[row, col] = line[col];
                }
            }
        }

        public static bool CheckForPieceAtPosition(string[,] board, string piece, int startRow, int startCol)
        {
            return board[startRow, startCol] == piece;
        }

        public static bool IsMoveInsideBoard(int destinationRow, int destinationCol)
        {
            return destinationRow < 8 && destinationCol < 8;
        }

        public static void MovePiece(string[,] board, string piece, int startRow, int startCol, int destinationRow, int destinationCol)
        {
            board[startRow, startCol] = "x";
            board[destinationRow, destinationCol] = piece;
        }

        public static bool CanPieceMove(string piece, int startRow, int startCol, int destinationRow, int destinationCol)
        {
            switch (piece)
            {
                case "K":
                    return (Math.Abs(startRow - destinationRow) == 1 && startCol == destinationCol) ||
                           (Math.Abs(startCol - destinationCol) == 1 && startRow == destinationRow) ||
                           (Math.Abs(startRow - destinationRow) == 1 && Math.Abs(startCol - destinationCol) == 1);

                case "R":
                    return startRow == destinationRow || startCol == destinationCol;
                case "B":
                    return Math.Abs(startRow - destinationRow) == Math.Abs(startCol - destinationCol);
                case "Q":
                    return startRow == destinationRow || 
                           startCol == destinationCol ||
                           Math.Abs(startRow - destinationRow) == Math.Abs(startCol - destinationCol);
                case "P":
                    return startRow - destinationRow == 1;
                default:
                    return false;
            }
        }
    }
}
