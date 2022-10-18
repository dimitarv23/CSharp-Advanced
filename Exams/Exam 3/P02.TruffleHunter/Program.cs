using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace P02.TruffleHunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] forest = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                char[] currRow = Console.ReadLine()
                    .Split()
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < size; col++)
                {
                    forest[row, col] = currRow[col];
                }
            }

            var truffels = new Dictionary<char, int>();
            int wildBoarTruffels = 0;

            string command = Console.ReadLine();
            while (command != "Stop the hunt")
            {
                string[] cmdArgs = command.Split();
                string action = cmdArgs[0];
                int row = int.Parse(cmdArgs[1]);
                int col = int.Parse(cmdArgs[2]);

                if (IsIndexexValid(size, row, col))
                {
                    if (action == "Collect")
                    {
                        char currItem = forest[row, col];

                        if (currItem != '-')
                        {
                            if (!truffels.ContainsKey(currItem))
                            {
                                truffels.Add(currItem, 0);
                            }

                            truffels[currItem]++;
                            forest[row, col] = '-';
                        }
                    }
                    else if (action == "Wild_Boar")
                    {
                        string direction = cmdArgs[3];
                        WildBoar(forest, ref wildBoarTruffels, direction, row, col);
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Peter manages to harvest {(truffels.ContainsKey('B') ? truffels['B'] : 0)} black, {(truffels.ContainsKey('S') ? truffels['S'] : 0)} summer, and {(truffels.ContainsKey('W') ? truffels['W'] : 0)} white truffles.");
            Console.WriteLine($"The wild boar has eaten {wildBoarTruffels} truffles.");

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(forest[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        static bool IsIndexexValid(int size, int row, int col)
        {
            if (row >= 0 && row < size
                    && col >= 0 && col < size)
            {
                return true;
            }

            return false;
        }

        static void WildBoar(char[,] forest, ref int wildBoarTruffels, string direction, int row, int col)
        {
            if (direction == "up")
            {
                for (int currRow = row; currRow >= 0; currRow -= 2)
                {
                    char currItem = forest[currRow, col];

                    if (currItem != '-')
                    {
                        wildBoarTruffels++;
                        forest[currRow, col] = '-';
                    }
                }
            }
            else if (direction == "down")
            {
                for (int currRow = row; currRow < forest.GetLength(0); currRow += 2)
                {
                    char currItem = forest[currRow, col];

                    if (currItem != '-')
                    {
                        wildBoarTruffels++;
                        forest[currRow, col] = '-';
                    }
                }
            }
            else if (direction == "right")
            {
                for (int currCol = col; currCol < forest.GetLength(1); currCol += 2)
                {
                    char currItem = forest[row, currCol];

                    if (currItem != '-')
                    {
                        wildBoarTruffels++;
                        forest[row, currCol] = '-';
                    }
                }
            }
            else if (direction == "left")
            {
                for (int currCol = col; currCol >= 0; currCol -= 2)
                {
                    char currItem = forest[row, currCol];

                    if (currItem != '-')
                    {
                        wildBoarTruffels++;
                        forest[row, currCol] = '-';
                    }
                }
            }
        }
    }
}