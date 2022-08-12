using System;
using System.Linq;

namespace P03.PrimaryDiagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];
            int sumPrimaryDiagonal = 0;

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

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                sumPrimaryDiagonal += matrix[row, row];
            }

            Console.WriteLine(sumPrimaryDiagonal);
        }
    }
}
