using System;

namespace P04.SymbolinMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string currRow = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }

            char symbol = char.Parse(Console.ReadLine());
            bool doesOccur = false;
            int charRow = -1;
            int charCol = -1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        doesOccur = true;
                        charRow = row;
                        charCol = col;
                        break;
                    }
                }

                if (doesOccur)
                {
                    break;
                }
            }

            if (doesOccur)
            {
                Console.WriteLine($"({charRow}, {charCol})");
            }
            else
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
        }
    }
}
