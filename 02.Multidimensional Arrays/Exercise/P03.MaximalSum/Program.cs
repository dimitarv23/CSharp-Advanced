using System;
using System.Linq;

namespace P03.MaximalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];

            int[,] matrix = new int[rows, cols];
            ReadMatrix(matrix);

            int maxSquareSum = int.MinValue;
            int maxSquareRow = 0;
            int maxSquareCol = 0;

            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    int currSquareSum = 0;

                    for (int squareRow = row; squareRow <= row + 2; squareRow++)
                    {
                        for (int squareCol = col; squareCol <= col + 2; squareCol++)
                        {
                            currSquareSum += matrix[squareRow, squareCol];
                        }
                    }

                    if (currSquareSum > maxSquareSum)
                    {
                        maxSquareSum = currSquareSum;
                        maxSquareRow = row;
                        maxSquareCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSquareSum}");
            for (int row = maxSquareRow; row <= maxSquareRow + 2; row++)
            {
                for (int col = maxSquareCol; col <= maxSquareCol + 2; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }

        static void ReadMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }
        }
    }
}
