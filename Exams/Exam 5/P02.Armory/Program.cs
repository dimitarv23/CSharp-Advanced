using System;

namespace P02.Armory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] armory = new char[n, n];
            int[] officerPosition = new int[2];

            for (int row = 0; row < n; row++)
            {
                string currRow = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    armory[row, col] = currRow[col];

                    if (currRow[col] == 'A')
                    {
                        officerPosition[0] = row;
                        officerPosition[1] = col;

                        armory[row, col] = '-';
                    }
                }
            }

            bool isOfficerOut = false;
            int worthOfSwords = 0;

            while (worthOfSwords < 65)
            {
                string command = Console.ReadLine();
                int currRow = officerPosition[0];
                int currCol = officerPosition[1];

                switch (command)
                {
                    case "up": currRow--; break;
                    case "down": currRow++; break;
                    case "left": currCol--; break;
                    case "right": currCol++; break;
                    default: break;
                }

                isOfficerOut = IsOfficerOut(currRow, currCol, n);
                if (isOfficerOut)
                {
                    break;
                }

                if (char.IsDigit(armory[currRow, currCol]))
                {
                    int digit = int.Parse(armory[currRow, currCol].ToString());
                    worthOfSwords += digit;

                    armory[currRow, currCol] = '-';
                }
                else if (armory[currRow, currCol] == 'M')
                {
                    armory[currRow, currCol] = '-';
                    int[] mirrorPosition = GetPositionOfOtherMirror(armory);
                    currRow = mirrorPosition[0];
                    currCol = mirrorPosition[1];
                    armory[currRow, currCol] = '-';
                }

                officerPosition[0] = currRow;
                officerPosition[1] = currCol;
            }

            if (isOfficerOut)
            {
                Console.WriteLine("I do not need more swords!");
            }
            else
            {
                Console.WriteLine("Very nice swords, I will come back for more!");
                armory[officerPosition[0], officerPosition[1]] = 'A';
            }

            Console.WriteLine($"The king paid {worthOfSwords} gold coins.");

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(armory[row, col]);
                }

                Console.WriteLine();
            }
        }

        static bool IsOfficerOut(int row, int col, int size)
        {
            if (row < 0 || row >= size
                || col < 0 || col >= size)
            {
                return true;
            }

            return false;
        }

        static int[] GetPositionOfOtherMirror(char[,] armory)
        {
            int[] mirrorLocation = new int[2];
            bool isFound = false;

            for (int row = 0; row < armory.GetLength(0); row++)
            {
                for (int col = 0; col < armory.GetLength(1); col++)
                {
                    if (armory[row, col] == 'M')
                    {
                        mirrorLocation[0] = row;
                        mirrorLocation[1] = col;
                        break;
                    }
                }

                if (isFound)
                {
                    break;
                }
            }

            return mirrorLocation;
        }
    }
}
