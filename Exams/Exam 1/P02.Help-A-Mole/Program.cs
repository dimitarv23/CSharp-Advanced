using System;

namespace P02.Help_A_Mole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] field = new char[n, n];
            int[] moleLocation = new int[2];
            int moleCoins = 0;

            for (int row = 0; row < n; row++)
            {
                char[] currRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    field[row, col] = currRow[col];

                    if (currRow[col] == 'M')
                    {
                        moleLocation[0] = row;
                        moleLocation[1] = col;
                    }
                }
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                bool moleHasMoved = true;
                int previousRow = moleLocation[0];
                int previousCol = moleLocation[1];

                if (command == "up")
                {
                    moleLocation[0]--;

                    if (!IsCommandValid(field, moleLocation))
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                        moleHasMoved = false;
                        moleLocation[0]++;
                    }
                }
                else if (command == "down")
                {
                    moleLocation[0]++;

                    if (!IsCommandValid(field, moleLocation))
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                        moleHasMoved = false;
                        moleLocation[0]--;
                    }
                }
                else if (command == "left")
                {
                    moleLocation[1]--;

                    if (!IsCommandValid(field, moleLocation))
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                        moleHasMoved = false;
                        moleLocation[1]++;
                    }
                }
                else if (command == "right")
                {
                    moleLocation[1]++;

                    if (!IsCommandValid(field, moleLocation))
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                        moleHasMoved = false;
                        moleLocation[1]--;
                    }
                }

                if (moleHasMoved)
                {
                    char currMove = field[moleLocation[0], moleLocation[1]];

                    field[previousRow, previousCol] = '-';
                    field[moleLocation[0], moleLocation[1]] = 'M';

                    if (currMove == 'S')
                    {
                        field[moleLocation[0], moleLocation[1]] = '-';

                        int[] specialLocation = PositionOfSpecial(field);
                        field[specialLocation[0], specialLocation[1]] = 'M';
                        moleLocation[0] = specialLocation[0];
                        moleLocation[1] = specialLocation[1];
                        moleCoins -= 3;
                    }
                    else if (char.IsDigit(currMove))
                    {
                        moleCoins += int.Parse(currMove.ToString());

                        if (moleCoins >= 25)
                        {
                            Console.WriteLine("Yay! The Mole survived another game!");
                            Console.WriteLine($"The Mole managed to survive with a total of {moleCoins} points.");
                            break;
                        }
                    }
                }

                command = Console.ReadLine();
            }

            if (command == "End")
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {moleCoins} points.");
            }

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col]);

                }

                Console.WriteLine();
            }
        }

        static bool IsCommandValid(char[,] field, int[] moleLocation)
        {
            if (moleLocation[0] >= 0 && moleLocation[0] < field.GetLength(0)
                && moleLocation[1] >= 0 && moleLocation[1] < field.GetLength(1))
            {
                return true;
            }

            return false;
        }

        static int[] PositionOfSpecial(char[,] field)
        {
            int[] position = new int[2];

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col] == 'S')
                    {
                        position[0] = row;
                        position[1] = col;
                    }
                }
            }

            return position;
        }
    }
}
