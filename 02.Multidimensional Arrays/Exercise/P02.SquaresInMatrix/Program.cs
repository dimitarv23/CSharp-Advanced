using System;
using System.Linq;

namespace P02.SquaresInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];

            char[,] matrix = new char[rows, cols];
            ReadMatrix(matrix);
            int countEqualBoxes = 0;

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    char currSymbol = matrix[row, col];

                    if (currSymbol == matrix[row, col + 1] 
                        && currSymbol == matrix[row + 1, col] 
                        && currSymbol == matrix[row + 1, col + 1])
                    {
                        countEqualBoxes++;
                    }
                }
            }

            Console.WriteLine(countEqualBoxes);
        }

        static void ReadMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] currRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }
        }
    }
}
