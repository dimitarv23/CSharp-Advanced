using System;
using System.Linq;

namespace P09.Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeOfField = int.Parse(Console.ReadLine());
            char[,] field = new char[sizeOfField, sizeOfField];

            string[] commands = Console.ReadLine().Split();

            int[] positionOfMiner = new int[2];
            int numberOfCoals = 0;
            ReadMatrix(field, ref positionOfMiner, ref numberOfCoals);

            int coalsCollected = 0;
            int minerRow = positionOfMiner[0];
            int minerCol = positionOfMiner[1];

            foreach (var command in commands)
            {
                if (command == "left")
                {
                    minerCol--;

                    if (IsCommandInvalid(field, minerRow, minerCol))
                    {
                        minerCol++;
                        continue;
                    }
                }
                else if (command == "right")
                {
                    minerCol++;

                    if (IsCommandInvalid(field, minerRow, minerCol))
                    {
                        minerCol--;
                        continue;
                    }
                }
                else if (command == "up")
                {
                    minerRow--;

                    if (IsCommandInvalid(field, minerRow, minerCol))
                    {
                        minerRow++;
                        continue;
                    }
                }
                else if (command == "down")
                {
                    minerRow++;

                    if (IsCommandInvalid(field, minerRow, minerCol))
                    {
                        minerRow--;
                        continue;
                    }
                }

                if (field[minerRow, minerCol] == 'c')
                {
                    coalsCollected++;
                    field[minerRow, minerCol] = '*';

                    if (coalsCollected == numberOfCoals)
                    {
                        Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                        return;
                    }
                }
                else if (field[minerRow, minerCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                    return;
                }
            }

            int remainingCoals = numberOfCoals - coalsCollected;
            Console.WriteLine($"{remainingCoals} coals left. ({minerRow}, {minerCol})");
        }

        static void ReadMatrix(char[,] matrix, ref int[] positionOfMiner, ref int numberOfCoals)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] currRow = Console.ReadLine()
                    .Split()
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currRow[col];

                    if (matrix[row, col] == 's')
                    {
                        positionOfMiner[0] = row;
                        positionOfMiner[1] = col;
                    }
                    else if (matrix[row, col] == 'c')
                    {
                        numberOfCoals++;
                    }
                }
            }
        }

        static bool IsCommandInvalid(char[,] matrix, int row, int col)
        {
            if (row < 0 || row >= matrix.GetLength(0) ||
                col < 0 || col >= matrix.GetLength(1))
            {
                return true;
            }

            return false;
        }
    }
}
