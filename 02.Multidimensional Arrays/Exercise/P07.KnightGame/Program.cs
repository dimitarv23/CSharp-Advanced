using System;
using System.Collections.Generic;
using System.Data;
using System.Numerics;

namespace P07.KnightGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int boardSide = int.Parse(Console.ReadLine());
            string[,] board = new string[boardSide, boardSide];

            //Filling the board
            for (int row = 0; row < board.GetLength(0); row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = currentRow[col].ToString();
                }
            }

            int knightsInDangerCounter = 0; //Counting how many knights can be attacked from current knight.
            int removedKnightsCounter = 0; //Counting removed knights from the board.

            for (int maxAttackPotential = 8; maxAttackPotential > 0; maxAttackPotential--) //Every knight can attack and kill maximum 8 other knights.
            {
                for (int row = 0; row < board.GetLength(0); row++)
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        if (board[row, col].ToLower() == "k") //Check if we have knight on current position.
                        {
                            //Check if new position isn't outside of the board (so we don't get IndexOutOfRangeException).
                            if (row - 1 >= 0)
                            {
                                if (col - 2 >= 0)
                                {
                                    //Check if there is knight to be attacked on the new position.
                                    if (board[row - 1, col - 2].ToLower() == "k")
                                    {
                                        knightsInDangerCounter++;
                                    }
                                }

                                if (col + 2 < board.GetLength(1))
                                {
                                    //Check if there is knight to be attacked on the new position.
                                    if (board[row - 1, col + 2].ToLower() == "k")
                                    {
                                        knightsInDangerCounter++;
                                    }
                                }
                            }

                            if (row + 1 < board.GetLength(0))
                            {
                                if (col - 2 >= 0)
                                {
                                    //Check if there is knight to be attacked on the new position
                                    if (board[row + 1, col - 2].ToLower() == "k")
                                    {
                                        knightsInDangerCounter++;
                                    }
                                }

                                if (col + 2 < board.GetLength(1))
                                {
                                    //Check if there is knight to be attacked on the new position
                                    if (board[row + 1, col + 2].ToLower() == "k")
                                    {
                                        knightsInDangerCounter++;
                                    }
                                }
                            }

                            if (row - 2 >= 0)
                            {
                                if (col - 1 >= 0)
                                {
                                    //Check if there is knight to be attacked on the new position
                                    if (board[row - 2, col - 1].ToLower() == "k")
                                    {
                                        knightsInDangerCounter++;
                                    }
                                }

                                if (col + 1 < board.GetLength(1))
                                {
                                    //Check if there is knight to be attacked on the new position
                                    if (board[row - 2, col + 1].ToLower() == "k")
                                    {
                                        knightsInDangerCounter++;
                                    }
                                }
                            }

                            if (row + 2 < board.GetLength(0))
                            {
                                if (col - 1 >= 0)
                                {
                                    //Check if there is knight to be attacked on the new position
                                    if (board[row + 2, col - 1].ToLower() == "k")
                                    {
                                        knightsInDangerCounter++;
                                    }
                                }

                                if (col + 1 < board.GetLength(1))
                                {
                                    //Check if there is knight to be attacked on the new position
                                    if (board[row + 2, col + 1].ToLower() == "k")
                                    {
                                        knightsInDangerCounter++;
                                    }
                                }
                            }
                        }

                        //Check if every possible attack is against another knight (attack potential of current knight is biggest possible)
                        if (knightsInDangerCounter == maxAttackPotential)
                        {
                            board[row, col] = "0"; //Remove knight from board.
                            removedKnightsCounter++;
                        }

                        knightsInDangerCounter = 0; //Restart counter.
                    }
                }
            }

            //Print result
            Console.WriteLine(removedKnightsCounter);
        }
    }
}
