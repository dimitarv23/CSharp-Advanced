using System;
using System.Linq;

namespace P04.MatrixShuffling
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

            string[,] matrix = new string[rows, cols];
            ReadMatrix(matrix);

            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] cmdArgs = command
                    .Split(' ');

                if (IsInputValid(cmdArgs, matrix))
                {
                    int row1 = int.Parse(cmdArgs[1]);
                    int col1 = int.Parse(cmdArgs[2]);
                    int row2 = int.Parse(cmdArgs[3]);
                    int col2 = int.Parse(cmdArgs[4]);

                    string swapElement = matrix[row1, col1];
                    matrix[row1, col1] = matrix[row2, col2];
                    matrix[row2, col2] = swapElement;

                    PrintMatrix(matrix);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
                
                command = Console.ReadLine();
            }
        }

        static void ReadMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] currRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }
        }

        static bool IsInputValid(string[] cmdArgs, string[,] matrix)
        {
            if (cmdArgs[0] != "swap" || cmdArgs.Length != 5)
            {
                return false;
            }

            int row1 = int.Parse(cmdArgs[1]);
            int col1 = int.Parse(cmdArgs[2]);
            int row2 = int.Parse(cmdArgs[3]);
            int col2 = int.Parse(cmdArgs[4]);

            if (row1 < 0 || row1 >= matrix.GetLength(0) || col1 < 0 || col1 >= matrix.GetLength(1) || 
                row2 < 0 || row2 >= matrix.GetLength(0) || col2 < 0 || col2 >= matrix.GetLength(1))
            {
                return false;
            }

            return true;
        }

        static void PrintMatrix(string[,] matrix)
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
    }
}
