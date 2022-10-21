using System;
using System.Net;

namespace P02.Re_Volt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int countOfCommands = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            int[] playerPosition = new int[2];

            for (int row = 0; row < size; row++)
            {
                string currRow = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currRow[col];

                    if (currRow[col] == 'f')
                    {
                        playerPosition[0] = row;
                        playerPosition[1] = col;
                    }
                }
            }

            bool hasWon = false;

            for (int commandNum = 0; commandNum < countOfCommands && !hasWon; commandNum++)
            {
                string direction = Console.ReadLine();
                int currRow = playerPosition[0];
                int currCol = playerPosition[1];

                matrix[currRow, currCol] = '-';
                StepInDirection(matrix, direction, ref currRow, ref currCol);

                if (!IsPlayerInside(size, currRow, currCol))
                {
                    PlayerStepsOutside(size, direction, ref currRow, ref currCol);
                }

                if (matrix[currRow, currCol] == 'F')
                {
                    hasWon = true;
                }
                else if (matrix[currRow, currCol] == 'B')
                {
                    StepInDirection(matrix, direction, ref currRow, ref currCol);

                    if (!IsPlayerInside(size, currRow, currCol))
                    {
                        PlayerStepsOutside(size, direction, ref currRow, ref currCol);
                    }

                    if (matrix[currRow, currCol] == 'F')
                    {
                        hasWon = true;
                    }
                }
                else if (matrix[currRow, currCol] == 'T')
                {
                    switch (direction)
                    {
                        case "up": direction = "down"; break;
                        case "down": direction = "up"; break;
                        case "left": direction = "right"; break;
                        case "right": direction = "left"; break;
                        default: break;
                    }

                    StepInDirection(matrix, direction, ref currRow, ref currCol);

                    if (!IsPlayerInside(size, currRow, currCol))
                    {
                        PlayerStepsOutside(size, direction, ref currRow, ref currCol);
                    }
                }

                matrix[currRow, currCol] = 'f';
                playerPosition[0] = currRow;
                playerPosition[1] = currCol;
            }

            if (hasWon)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        static bool IsPlayerInside(int size, int row, int col)
        {
            if (row < 0 || row >= size
                || col < 0 || col >= size)
            {
                return false;
            }

            return true;
        }

        static void StepInDirection(char[,] matrix, string direction, ref int row, ref int col)
        {
            switch (direction)
            {
                case "up": row--; break;
                case "down": row++; break;
                case "left": col--; break;
                case "right": col++; break;
                default: break;
            }
        }

        static void PlayerStepsOutside(int size, string direction, ref int row, ref int col)
        {
            switch (direction)
            {
                case "up": row = size - 1; break;
                case "down": row = 0; break;
                case "left": col = size - 1; break;
                case "right": col = 0; break;
                default: break;
            }
        }
    }
}
