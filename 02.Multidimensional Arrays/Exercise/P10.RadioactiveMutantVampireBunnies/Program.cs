using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace P10.RadioactiveMutantVampireBunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizeOfMatrix = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int rows = sizeOfMatrix[0];
            int cols = sizeOfMatrix[1];

            char[,] matrix = new char[rows, cols];
            int[] playerPosition = new int[2];
            ReadMatrix(matrix, ref playerPosition);

            int playerRow = playerPosition[0];
            int playerCol = playerPosition[1];

            string stateOfGame = string.Empty;
            char[] commands = Console.ReadLine().ToCharArray();

            foreach (var command in commands)
            {
                MultiplyBunnies(matrix);

                if (command == 'L')
                {
                    playerCol--;

                    if (!IsIndexValid(matrix.GetLength(1), playerCol))
                    {
                        playerCol++;
                        stateOfGame = "won";
                        break;
                    }
                }
                else if (command == 'R')
                {
                    playerCol++;

                    if (!IsIndexValid(matrix.GetLength(1), playerCol))
                    {
                        playerCol--;
                        stateOfGame = "won";
                        break;
                    }
                }
                else if (command == 'U')
                {
                    playerRow--;

                    if (!IsIndexValid(matrix.GetLength(0), playerRow))
                    {
                        playerRow++;
                        stateOfGame = "won";
                        break;
                    }
                }
                else if (command == 'D')
                {
                    playerRow++;

                    if (!IsIndexValid(matrix.GetLength(0), playerRow))
                    {
                        playerRow--;
                        stateOfGame = "won";
                        break;
                    }
                }
                
                if (matrix[playerRow, playerCol] == 'B')
                {
                    stateOfGame = "lost";
                    break;
                }
            }
            
            PrintMatrix(matrix);

            if (stateOfGame == "won")
            {
                Console.WriteLine($"won: {playerRow} {playerCol}");
            }
            else if (stateOfGame == "lost")
            {
                Console.WriteLine($"dead: {playerRow} {playerCol}");
            }
        }

        static void ReadMatrix(char[,] matrix, ref int[] playerPosition)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string currRow = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currRow[col];

                    if (matrix[row, col] == 'P')
                    {
                        playerPosition[0] = row;
                        playerPosition[1] = col;
                        matrix[row, col] = '.';
                    }
                }
            }
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }

                Console.WriteLine();
            }
        }

        static bool IsIndexValid(int size, int index)
        {
            if (index >= 0 && index < size)
            {
                return true;
            }

            return false;
        }

        static void MultiplyBunnies(char[,] matrix)
        {
            List<string> bunniesToMultiply = new List<string>();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        bunniesToMultiply.Add($"{row} {col}");
                    }
                }
            }

            foreach (var bunny in bunniesToMultiply)
            {
                int bunnyRow = int.Parse(bunny.Split()[0]);
                int bunnyCol = int.Parse(bunny.Split()[1]);

                if (IsIndexValid(matrix.GetLength(0), bunnyRow - 1))
                {
                    matrix[bunnyRow - 1, bunnyCol] = 'B';
                }

                if (IsIndexValid(matrix.GetLength(0), bunnyRow + 1))
                {
                    matrix[bunnyRow + 1, bunnyCol] = 'B';
                }

                if (IsIndexValid(matrix.GetLength(1), bunnyCol - 1))
                {
                    matrix[bunnyRow, bunnyCol - 1] = 'B';
                }

                if (IsIndexValid(matrix.GetLength(1), bunnyCol + 1))
                {
                    matrix[bunnyRow, bunnyCol + 1] = 'B';
                }
            }
        }
    }
}
