using System;
using System.Linq;

namespace P01.SumMatrixElements
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
            int totalSum = 0;

            for (int row = 0; row < rows; row++)
            {
                int[] currRow = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currRow[col];
                    totalSum += currRow[col];
                }
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(totalSum);
        }
    }
}
