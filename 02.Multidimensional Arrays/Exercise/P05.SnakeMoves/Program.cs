using System;
using System.Linq;

namespace P05.SnakeMoves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];

            char[,] matrix = new char[rows, cols];
            string snake = Console.ReadLine();
            int currSnakeIndex = 0;

            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        matrix[row, col] = snake[currSnakeIndex];
                        currSnakeIndex++;

                        RestartSnakeIndex(snake, ref currSnakeIndex);
                    }
                }
                else
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        matrix[row, col] = snake[currSnakeIndex];
                        currSnakeIndex++;

                        RestartSnakeIndex(snake, ref currSnakeIndex);
                    }
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }

        static void RestartSnakeIndex(string snake, ref int snakeIndex)
        {
            if (snakeIndex == snake.Length)
            {
                snakeIndex = 0;
            }
        }
    }
}
