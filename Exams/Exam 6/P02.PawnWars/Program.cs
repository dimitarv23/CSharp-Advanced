using System;

namespace P02.PawnWars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] chessBoard = new char[8, 8];
            int[] positionOfWhite = new int[2];
            int[] positionOfBlack = new int[2];

            for (int row = 0; row < 8; row++)
            {
                string currRow = Console.ReadLine();

                for (int col = 0; col < 8; col++)
                {
                    chessBoard[row, col] = currRow[col];

                    if (currRow[col] == 'w')
                    {
                        positionOfWhite[0] = row;
                        positionOfWhite[1] = col;
                    }
                    else if (currRow[col] == 'b')
                    {
                        positionOfBlack[0] = row;
                        positionOfBlack[1] = col;
                    }
                }
            }

            int[] positionOfWinner = new int[2];
            bool hasQueen = false;
            string winner = string.Empty;

            while (true)
            {
                if (CanWhiteWin(chessBoard, ref positionOfWhite[0], ref positionOfWhite[1], ref hasQueen))
                {
                    winner = "White";
                    positionOfWinner[0] = positionOfWhite[0];
                    positionOfWinner[1] = positionOfWhite[1];
                    break;
                }

                if (CanBlackWin(chessBoard, ref positionOfBlack[0], ref positionOfBlack[1], ref hasQueen))
                {
                    positionOfWinner[0] = positionOfBlack[0];
                    positionOfWinner[1] = positionOfBlack[1];
                    winner = "Black";
                    break;
                }
            }

            char letterOfWinner = (char)(97 + positionOfWinner[1]);
            int digitOfWinner = 8 - positionOfWinner[0];

            if (hasQueen)
            {
                Console.WriteLine($"Game over! {winner} pawn is promoted to a queen at {letterOfWinner}{digitOfWinner}.");
            }
            else
            {
                Console.WriteLine($"Game over! {winner} capture on {letterOfWinner}{digitOfWinner}.");
            }

            //for (int row = 0; row < 8; row++)
            //{
            //    for (int col = 0; col < 8; col++)
            //    {
            //        Console.Write(chessBoard[row, col]);
            //    }

            //    Console.WriteLine();
            //}
        }
        static bool CanWhiteWin(char[,] chessBoard, ref int row, ref int col, ref bool hasQueen)
        {
            if (col - 1 >= 0 && chessBoard[row - 1, col - 1] == 'b')
            {
                ChangePositionOfPawn(chessBoard, row, col, 'w', row - 1, col - 1);
                row--;
                col--;
                return true;
            }
            else if (col + 1 < 8 && chessBoard[row - 1, col + 1] == 'b')
            {
                ChangePositionOfPawn(chessBoard, row, col, 'w', row - 1, col + 1);
                row--;
                col++;
                return true;
            }
            else if (row == 1)
            {
                ChangePositionOfPawn(chessBoard, row, col, 'w', row - 1, col);
                hasQueen = true;
                row--;
                return true;
            }

            ChangePositionOfPawn(chessBoard, row, col, 'w', row - 1, col);
            row--;
            return false;
        }

        static bool CanBlackWin(char[,] chessBoard, ref int row, ref int col, ref bool hasQueen)
        {
            if (col - 1 >= 0 && chessBoard[row + 1, col - 1] == 'w')
            {
                ChangePositionOfPawn(chessBoard, row, col, 'b', row + 1, col - 1);
                row++;
                col--;
                return true;
            }
            else if (col + 1 < 8 && chessBoard[row + 1, col + 1] == 'w')
            {
                ChangePositionOfPawn(chessBoard, row, col, 'b', row + 1, col + 1);
                row++;
                col++;
                return true;
            }
            else if (row == 6)
            {
                ChangePositionOfPawn(chessBoard, row, col, 'b', row + 1, col);
                hasQueen = true;
                row++;
                return true;
            }

            ChangePositionOfPawn(chessBoard, row, col, 'b', row + 1, col);
            row++;
            return false;
        }

        static void ChangePositionOfPawn(char[,] chessBoard, int row, int col, char pawn, int nextRow, int nextCol)
        {
            chessBoard[row, col] = '-';
            chessBoard[nextRow, nextCol] = pawn;
        }
    }
}
