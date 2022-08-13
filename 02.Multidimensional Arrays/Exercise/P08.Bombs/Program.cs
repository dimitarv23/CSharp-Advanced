using System;
using System.Linq;

namespace P08.Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());

            int[,] matrix = new int[sizeOfMatrix, sizeOfMatrix];
            ReadMatrix(matrix);

            string[] coordinates = Console.ReadLine().Split();

            foreach (var coordinate in coordinates)
            {
                int[] bombCoordinates = coordinate
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int bombRow = bombCoordinates[0];
                int bombCol = bombCoordinates[1];

                int bombValue = matrix[bombRow, bombCol];

                if (bombValue <= 0)
                {
                    continue;
                }

                for (int row = bombRow - 1; row <= bombRow + 1; row++)
                {
                    for (int col = bombCol - 1; col <= bombCol + 1; col++)
                    {
                        if (ValidateIndices(matrix, row, col))
                        {
                            if (matrix[row, col] > 0)
                            {
                                matrix[row, col] -= bombValue;
                            }
                        }
                    }
                }

                matrix[bombRow, bombCol] = 0;
            }

            int countAliveCells = 0;
            int sumAliveCells = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        countAliveCells++;
                        sumAliveCells += matrix[row, col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {countAliveCells}");
            Console.WriteLine($"Sum: {sumAliveCells}");
            PrintMatrix(matrix);
        }

        static void ReadMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currRow = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }

        static bool ValidateIndices(int[,] matrix, int row, int col)
        {
            if (row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }

            return false;
        }
    }
}
