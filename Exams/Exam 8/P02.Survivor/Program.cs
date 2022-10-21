using System;
using System.Linq;

namespace P02.Survivor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowsNum = int.Parse(Console.ReadLine());
            char[][] beach = new char[rowsNum][];

            for (int row = 0; row < rowsNum; row++)
            {
                char[] currRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                beach[row] = currRow;
            }

            int collectedTokens = 0;
            int opponentTokens = 0;

            string command = Console.ReadLine();
            while (command != "Gong")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = cmdArgs[0];
                int row = int.Parse(cmdArgs[1]);
                int col = int.Parse(cmdArgs[2]);

                if (!IsPositionValid(beach, row, col))
                {
                    command = Console.ReadLine();
                    continue;
                }

                if (action == "Find")
                {
                    if (beach[row][col] == 'T')
                    {
                        collectedTokens++;
                        beach[row][col] = '-';
                    }
                }
                else if (action == "Opponent")
                {
                    string direction = cmdArgs[3];

                    opponentTokens += OpponentMoves(beach, row, col, direction);
                }

                command = Console.ReadLine();
            }

            for (int row = 0; row < beach.Length; row++)
            {
                Console.WriteLine(string.Join(" ", beach[row]));
            }

            Console.WriteLine($"Collected tokens: {collectedTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }

        static int OpponentMoves(char[][] jagged, int row, int col, string direction)
        {
            int opponentTokens = 0;

            if (direction == "up")
            {
                for (int currRow = row; currRow >= row - 3; currRow--)
                {
                    if (CanCollectToken(jagged, currRow, col))
                    {
                        opponentTokens++;
                        jagged[currRow][col] = '-';
                    }
                }
            }
            else if (direction == "down")
            {
                for (int currRow = row; currRow <= row + 3; currRow++)
                {
                    if (CanCollectToken(jagged, currRow, col))
                    {
                        opponentTokens++;
                        jagged[currRow][col] = '-';
                    }
                }
            }
            else if (direction == "left")
            {
                for (int currCol = col; currCol >= col - 3; currCol--)
                {
                    if (CanCollectToken(jagged, row, currCol))
                    {
                        opponentTokens++;
                        jagged[row][currCol] = '-';
                    }
                }
            }
            else if (direction == "right")
            {
                for (int currCol = col; currCol <= col + 3; currCol++)
                {
                    if (CanCollectToken(jagged, row, currCol))
                    {
                        opponentTokens++;
                        jagged[row][currCol] = '-';
                    }
                }
            }

            return opponentTokens;
        }

        static bool CanCollectToken(char[][] jagged, int row, int col)
        {
            if (IsPositionValid(jagged, row, col))
            {
                if (jagged[row][col] == 'T')
                {
                    return true;
                }
            }

            return false;
        }

        static bool IsPositionValid(char[][] jagged, int row, int col)
        {
            if (row < 0 || row >= jagged.Length)
            {
                return false;
            }

            if (col < 0 || col >= jagged[row].Length)
            {
                return false;
            }

            return true;
        }
    }
}
