using System;

namespace P02.TheBattleOfTheFiveArmies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int armyEnergy = int.Parse(Console.ReadLine());
            int numRows = int.Parse(Console.ReadLine());

            string currRow = Console.ReadLine();
            int numCols = currRow.Length;

            char[,] world = new char[numRows, numCols];
            int[] positionOfArmy = new int[2];

            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    world[row, col] = currRow[col];

                    if (currRow[col] == 'A')
                    {
                        positionOfArmy[0] = row;
                        positionOfArmy[1] = col;
                    }
                }

                if (row < numRows - 1)
                {
                    currRow = Console.ReadLine();
                }
            }

            bool hasWon = false;

            while (!hasWon && armyEnergy > 0)
            {
                string[] cmdArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = cmdArgs[0];
                int orcsRow = int.Parse(cmdArgs[1]);
                int orcsCol = int.Parse(cmdArgs[2]);

                if (IsPositionValid(numRows, numCols, orcsRow, orcsCol))
                {
                    world[orcsRow, orcsCol] = 'O';
                }

                hasWon = MoveArmy(world, ref positionOfArmy[0], ref positionOfArmy[1], action, ref armyEnergy);
            }

            if (hasWon)
            {
                Console.WriteLine($"The army managed to free the Middle World! Armor left: {armyEnergy}");
            }
            else
            {
                world[positionOfArmy[0], positionOfArmy[1]] = 'X';
                Console.WriteLine($"The army was defeated at {positionOfArmy[0]};{positionOfArmy[1]}.");
            }

            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    Console.Write(world[row, col]);
                }

                Console.WriteLine();
            }
        }

        static bool MoveArmy(char[,] world, ref int armyRow, ref int armyCol, string direction, ref int armyEnergy)
        {
            //Returns true if the army has reached the winning location, else - false

            world[armyRow, armyCol] = '-';
            armyEnergy--;

            switch (direction)
            {
                case "up": armyRow--; break;
                case "down": armyRow++; break;
                case "left": armyCol--; break;
                case "right": armyCol++; break;
                default: break;
            }

            if (IsPositionValid(world.GetLength(0), world.GetLength(1), armyRow, armyCol))
            {
                if (world[armyRow, armyCol] == 'O')
                {
                    armyEnergy -= 2;

                    if (armyEnergy <= 0)
                    {
                        return false;
                    }
                }
                else if (world[armyRow, armyCol] == 'M')
                {
                    world[armyRow, armyCol] = '-';
                    return true;
                }
            }
            else
            {
                switch (direction)
                {
                    case "up": armyRow++; break;
                    case "down": armyRow--; break;
                    case "left": armyCol++; break;
                    case "right": armyCol--; break;
                    default: break;
                }
            }

            world[armyRow, armyCol] = 'A';
            return false;
        }

        static bool IsPositionValid(int numRows, int numCols, int row, int col)
        {
            if (row < 0 || row >= numRows
                || col < 0 || col >= numCols)
            {
                return false;
            }

            return true;
        }
    }
}
