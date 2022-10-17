using System;
using System.Numerics;

namespace P02.WallDestroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] wall = new char[n, n];
            int[] positionOfVanko = new int[2];

            for (int row = 0; row < n; row++)
            {
                string currRow = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    wall[row, col] = currRow[col];

                    if (currRow[col] == 'V')
                    {
                        positionOfVanko[0] = row;
                        positionOfVanko[1] = col;

                        wall[row, col] = '*';
                    }
                }
            }

            int holesDrilled = 1; //The starting position is always considered a drilled hole
            int rodsDrilled = 0;
            bool hasManaged = true;

            string command = Console.ReadLine();
            while (command != "End")
            {
                int newRow = positionOfVanko[0];
                int newCol = positionOfVanko[1];

                if (command == "up")
                {
                    newRow--;

                    if (newRow >= 0)
                    {
                        hasManaged = Drill(wall, positionOfVanko, newRow, newCol, ref holesDrilled, ref rodsDrilled);
                    }
                }
                else if (command == "down")
                {
                    newRow++;

                    if (newRow < wall.GetLength(0))
                    {
                        hasManaged = Drill(wall, positionOfVanko, newRow, newCol, ref holesDrilled, ref rodsDrilled);
                    }
                }
                else if (command == "left")
                {
                    newCol--;

                    if (newCol >= 0)
                    {
                        hasManaged = Drill(wall, positionOfVanko, newRow, newCol, ref holesDrilled, ref rodsDrilled);
                    }
                }
                else if (command == "right")
                {
                    newCol++;

                    if (newCol < wall.GetLength(1))
                    {
                        hasManaged = Drill(wall, positionOfVanko, newRow, newCol, ref holesDrilled, ref rodsDrilled);
                    }
                }

                if (!hasManaged)
                {
                    break;
                }

                command = Console.ReadLine();
            }

            if (hasManaged)
            {
                Console.WriteLine($"Vanko managed to make {holesDrilled} hole(s) and he hit only {rodsDrilled} rod(s).");
            }
            else
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesDrilled} hole(s).");
            }

            if (wall[positionOfVanko[0], positionOfVanko[1]] == '*')
            {
                wall[positionOfVanko[0], positionOfVanko[1]] = 'V';
            }

            for (int row = 0; row < wall.GetLength(0); row++)
            {
                for (int col = 0; col < wall.GetLength(1); col++)
                {
                    Console.Write(wall[row, col]);
                }

                Console.WriteLine();
            }
        }

        static bool Drill(char[,] wall, int[] positionOfVanko, int newRow, int newCol, ref int holes, ref int rods)
        {
            //returns true if commands can continue, otherwise - false

            if (wall[newRow, newCol] == 'R')
            {
                rods++;
                Console.WriteLine("Vanko hit a rod!");
            }
            else if (wall[newRow, newCol] == 'C')
            {
                positionOfVanko[0] = newRow;
                positionOfVanko[1] = newCol;
                holes++;
                wall[newRow, newCol] = 'E';
                return false;
            }
            else if (wall[newRow, newCol] == '*')
            {
                positionOfVanko[0] = newRow;
                positionOfVanko[1] = newCol;
                Console.WriteLine($"The wall is already destroyed at position [{newRow}, {newCol}]!");
            }
            else
            {
                positionOfVanko[0] = newRow;
                positionOfVanko[1] = newCol;

                wall[newRow, newCol] = '*';
                holes++;
            }

            return true;
        }
    }
}
