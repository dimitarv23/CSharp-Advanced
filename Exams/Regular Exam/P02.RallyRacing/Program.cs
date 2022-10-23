using System;
using System.Linq;

namespace P02.RallyRacing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string racingNumber = Console.ReadLine();
            char[,] route = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                char[] currRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < size; col++)
                {
                    route[row, col] = currRow[col];


                }
            }

            int passedKm = 0;
            int[] positionOfRaceCar = new int[2] { 0, 0 };
            bool hasWon = false;

            string command = Console.ReadLine();
            while (command != "End" && !hasWon)
            {
                int row = positionOfRaceCar[0];
                int col = positionOfRaceCar[1];

                if (command == "up")
                {
                    row--;
                }
                else if (command == "down")
                {
                    row++;
                }
                else if (command == "left")
                {
                    col--;
                }
                else if (command == "right")
                {
                    col++;
                }

                if (route[row, col] == 'T')
                {
                    GoingIntoTunnel(route, ref row, ref col);
                    passedKm += 20;
                }
                else if (route[row, col] == 'F')
                {
                    hasWon = true;
                }

                positionOfRaceCar[0] = row;
                positionOfRaceCar[1] = col;
                passedKm += 10;

                if (!hasWon)
                {
                    command = Console.ReadLine();
                }
            }

            if (hasWon)
            {
                Console.WriteLine($"Racing car {racingNumber} finished the stage!");
            }
            else
            {
                Console.WriteLine($"Racing car {racingNumber} DNF.");
            }

            Console.WriteLine($"Distance covered {passedKm} km.");

            route[positionOfRaceCar[0], positionOfRaceCar[1]] = 'C';

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(route[row, col]);
                }

                Console.WriteLine();
            }
        }

        static void GoingIntoTunnel(char[,] route, ref int row, ref int col)
        {
            route[row, col] = '.';


            for (int currRow = 0; currRow < route.GetLength(0); currRow++)
            {
                for (int currCol = 0; currCol < route.GetLength(1); currCol++)
                {
                    if (route[currRow, currCol] == 'T')
                    {
                        route[currRow, currCol] = '.';
                        row = currRow;
                        col = currCol;
                        return;
                    }
                }
            }
        }
    }
}
