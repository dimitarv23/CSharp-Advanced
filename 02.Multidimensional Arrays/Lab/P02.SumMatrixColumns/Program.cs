using System;
using System.Linq;

namespace P02.SumMatrixColumns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] currRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int currColSum = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    currColSum += matrix[row, col];
                }

                Console.WriteLine(currColSum);
            }
        }
    }
}
