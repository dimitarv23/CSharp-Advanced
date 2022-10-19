using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.BeaverAtWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] pond = new char[size, size];
            int[] locationOfBeaver = new int[2];

            int totalBranchesInPond = 0;

            for (int row = 0; row < size; row++)
            {
                char[] currRow = Console.ReadLine()
                    .Split()
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < size; col++)
                {
                    pond[row, col] = currRow[col];

                    if (currRow[col] == 'B')
                    {
                        locationOfBeaver[0] = row;
                        locationOfBeaver[1] = col;
                    }
                    else if (char.IsLower(currRow[col]))
                    {
                        totalBranchesInPond++;
                    }
                }
            }

            Dictionary<char, int> branches = new Dictionary<char, int>();
            char lastCollectedBranch = ' ';
            int branchesLeft = totalBranchesInPond;

            string command = Console.ReadLine();
            while (command != "end")
            {
                int currRow = locationOfBeaver[0];
                int currCol = locationOfBeaver[1];

                if (command == "up")
                {
                    currRow--;

                    if (currRow < 0)
                    {
                        if (branches.Count > 0)
                        {
                            branches[lastCollectedBranch]--;

                            if (branches[lastCollectedBranch] == 0)
                            {
                                branches.Remove(lastCollectedBranch);
                            }

                        }
                    }
                    else
                    {
                        if (char.IsLower(pond[currRow, currCol]))
                        {
                            lastCollectedBranch = pond[currRow, currCol];
                            AddBranch(branches, lastCollectedBranch, ref branchesLeft);

                            pond[currRow + 1, currCol] = '-';
                            pond[currRow, currCol] = 'B';

                            locationOfBeaver[0] = currRow;
                        }
                        else if (pond[currRow, currCol] == 'F')
                        {
                            pond[currRow, currCol] = '-';
                            pond[currRow + 1, currCol] = '-';

                            if (currRow == 0)
                            {
                                if (char.IsLower(pond[size - 1, currCol]))
                                {
                                    lastCollectedBranch = pond[size - 1, currCol];
                                    AddBranch(branches, lastCollectedBranch, ref branchesLeft);
                                }

                                pond[size - 1, currCol] = 'B';
                                locationOfBeaver[0] = size - 1;
                            }
                            else
                            {
                                if (char.IsLower(pond[0, currCol]))
                                {
                                    lastCollectedBranch = pond[0, currCol];
                                    AddBranch(branches, lastCollectedBranch, ref branchesLeft);
                                }

                                pond[0, currCol] = 'B';
                                locationOfBeaver[0] = 0;
                            }
                        }
                        else
                        {
                            pond[currRow + 1, currCol] = '-';
                            pond[currRow, currCol] = 'B';

                            locationOfBeaver[0] = currRow;
                        }
                    }
                }
                else if (command == "down")
                {
                    currRow++;

                    if (currRow >= size)
                    {
                        if (branches.Count > 0)
                        {
                            branches[lastCollectedBranch]--;

                            if (branches[lastCollectedBranch] == 0)
                            {
                                branches.Remove(lastCollectedBranch);
                            }
                        }
                    }
                    else
                    {
                        if (char.IsLower(pond[currRow, currCol]))
                        {
                            lastCollectedBranch = pond[currRow, currCol];
                            AddBranch(branches, lastCollectedBranch, ref branchesLeft);

                            pond[currRow - 1, currCol] = '-';
                            pond[currRow, currCol] = 'B';

                            locationOfBeaver[0] = currRow;
                        }
                        else if (pond[currRow, currCol] == 'F')
                        {
                            pond[currRow, currCol] = '-';
                            pond[currRow - 1, currCol] = '-';

                            if (currRow == size - 1)
                            {
                                if (char.IsLower(pond[0, currCol]))
                                {
                                    lastCollectedBranch = pond[0, currCol];
                                    AddBranch(branches, lastCollectedBranch, ref branchesLeft);
                                }

                                pond[0, currCol] = 'B';
                                locationOfBeaver[0] = 0;
                            }
                            else
                            {
                                if (char.IsLower(pond[size - 1, currCol]))
                                {
                                    lastCollectedBranch = pond[size - 1, currCol];
                                    AddBranch(branches, lastCollectedBranch, ref branchesLeft);
                                }

                                pond[size - 1, currCol] = 'B';
                                locationOfBeaver[0] = size - 1;
                            }
                        }
                        else
                        {
                            pond[currRow - 1, currCol] = '-';
                            pond[currRow, currCol] = 'B';

                            locationOfBeaver[0] = currRow;
                        }
                    }
                }
                else if (command == "left")
                {
                    currCol--;

                    if (currCol < 0)
                    {
                        if (branches.Count > 0)
                        {
                            branches[lastCollectedBranch]--;

                            if (branches[lastCollectedBranch] == 0)
                            {
                                branches.Remove(lastCollectedBranch);
                            }
                        }
                    }
                    else
                    {
                        if (char.IsLower(pond[currRow, currCol]))
                        {
                            lastCollectedBranch = pond[currRow, currCol];
                            AddBranch(branches, lastCollectedBranch, ref branchesLeft);

                            pond[currRow, currCol + 1] = '-';
                            pond[currRow, currCol] = 'B';

                            locationOfBeaver[1] = currCol;
                        }
                        else if (pond[currRow, currCol] == 'F')
                        {
                            pond[currRow, currCol] = '-';
                            pond[currRow, currCol + 1] = '-';

                            if (currCol == 0)
                            {
                                if (char.IsLower(pond[currRow, size - 1]))
                                {
                                    lastCollectedBranch = pond[currRow, size - 1];
                                    AddBranch(branches, lastCollectedBranch, ref branchesLeft);
                                }

                                pond[currRow, size - 1] = 'B';
                                locationOfBeaver[1] = size - 1;
                            }
                            else
                            {
                                if (char.IsLower(pond[currRow, 0]))
                                {
                                    lastCollectedBranch = pond[currRow, 0];
                                    AddBranch(branches, lastCollectedBranch, ref branchesLeft);
                                }

                                pond[currRow, 0] = 'B';
                                locationOfBeaver[1] = 0;
                            }
                        }
                        else
                        {
                            pond[currRow, currCol + 1] = '-';
                            pond[currRow, currCol] = 'B';

                            locationOfBeaver[1] = currCol;
                        }
                    }
                }
                else if (command == "right")
                {
                    currCol++;

                    if (currCol >= size)
                    {
                        if (branches.Count > 0)
                        {
                            branches[lastCollectedBranch]--;

                            if (branches[lastCollectedBranch] == 0)
                            {
                                branches.Remove(lastCollectedBranch);
                            }
                        }
                    }
                    else
                    {
                        if (char.IsLower(pond[currRow, currCol]))
                        {
                            lastCollectedBranch = pond[currRow, currCol];
                            AddBranch(branches, lastCollectedBranch, ref branchesLeft);

                            pond[currRow, currCol - 1] = '-';
                            pond[currRow, currCol] = 'B';

                            locationOfBeaver[1] = currCol;
                        }
                        else if (pond[currRow, currCol] == 'F')
                        {
                            pond[currRow, currCol] = '-';
                            pond[currRow, currCol - 1] = '-';

                            if (currCol == size - 1)
                            {
                                if (char.IsLower(pond[currRow, 0]))
                                {
                                    lastCollectedBranch = pond[currRow, 0];
                                    AddBranch(branches, lastCollectedBranch, ref branchesLeft);
                                }

                                pond[currRow, 0] = 'B';
                                locationOfBeaver[1] = 0;
                            }
                            else
                            {
                                if (char.IsLower(pond[currRow, size - 1]))
                                {
                                    lastCollectedBranch = pond[currRow, size - 1];
                                    AddBranch(branches, lastCollectedBranch, ref branchesLeft);
                                }

                                pond[currRow, size - 1] = 'B';
                                locationOfBeaver[1] = size - 1;
                            }
                        }
                        else
                        {
                            pond[currRow, currCol - 1] = '-';
                            pond[currRow, currCol] = 'B';

                            locationOfBeaver[1] = currCol;
                        }
                    }
                }

                if (branchesLeft == 0)
                {
                    break;
                }

                command = Console.ReadLine();
            }

            if (branchesLeft == 0)
            {
                Console.WriteLine($"The Beaver successfully collect {branches.Values.Sum()} wood branches: {string.Join(", ", branches.Keys)}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {branchesLeft} branches left.");
            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(pond[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        static void AddBranch(Dictionary<char, int> branches, char branch, ref int branchesLeft)
        {
            if (!branches.ContainsKey(branch))
            {
                branches.Add(branch, 0);
            }

            branches[branch]++;
            branchesLeft--;
        }
    }
}
