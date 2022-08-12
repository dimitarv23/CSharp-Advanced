using System;

namespace P07.PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long[][] jagged = new long[n][];
            jagged[0] = new long[1];
            jagged[0][0] = 1;

            for (int row = 1; row < jagged.Length; row++)
            {
                jagged[row] = new long[row + 1];
                jagged[row][0] = 1;

                for (int col = 1; col < jagged[row].Length; col++)
                {
                    jagged[row][col] = jagged[row - 1][col - 1];

                    if (col < jagged[row - 1].Length)
                    {
                        jagged[row][col] += jagged[row - 1][col];
                    }
                }
            }

            PrintJagged(jagged);
        }

        static void PrintJagged(long[][] jagged)
        {
            for (int row = 0; row < jagged.Length; row++)
            {
                Console.WriteLine(string.Join(" ", jagged[row]));
            }
        }
    }
}
