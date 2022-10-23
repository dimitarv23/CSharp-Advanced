using System;
using System.Linq;

namespace P02.SuperMario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int livesOfMario = int.Parse(Console.ReadLine());
            int rowsOfMaze = int.Parse(Console.ReadLine());
            int[] positionOfMario = new int[2];

            char[][] maze = new char[rowsOfMaze][];

            for (int row = 0; row < rowsOfMaze; row++)
            {
                char[] currRow = Console.ReadLine().ToCharArray();
                maze[row] = currRow;

                if (currRow.Contains('M'))
                {
                    positionOfMario[0] = row;
                    positionOfMario[1] = Array.IndexOf(currRow, 'M');
                }
            }

            bool hasWon = false;

            while (livesOfMario > 0 && !hasWon)
            {
                string[] command = Console.ReadLine().Split();
                string direction = command[0];
                int spawnRow = int.Parse(command[1]);
                int spawnCol = int.Parse(command[2]);

                maze[spawnRow][spawnCol] = 'B';

                int row = positionOfMario[0];
                int col = positionOfMario[1];

                MoveInDirection(maze, direction, ref row, ref col);
                livesOfMario--;

                if (!IsMarioInside(maze, row, col))
                {
                    continue;
                }

                if (maze[row][col] == 'B')
                {
                    livesOfMario -= 2;
                }
                else if (maze[row][col] == 'P')
                {
                    hasWon = true;
                }

                maze[positionOfMario[0]][positionOfMario[1]] = '-';

                positionOfMario[0] = row;
                positionOfMario[1] = col;

                maze[positionOfMario[0]][positionOfMario[1]] = 'M';
            }

            if (hasWon)
            {
                maze[positionOfMario[0]][positionOfMario[1]] = '-';
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {livesOfMario}");
            }
            else
            {
                maze[positionOfMario[0]][positionOfMario[1]] = 'X';
                Console.WriteLine($"Mario died at {positionOfMario[0]};{positionOfMario[1]}.");
            }

            for (int row = 0; row < maze.Length; row++)
            {
                for (int col = 0; col < maze[row].Length; col++)
                {
                    Console.Write(maze[row][col]);
                }

                Console.WriteLine();
            }
        }

        static bool IsMarioInside(char[][] jagged, int row, int col)
        {
            if (row < 0 || row >= jagged.Length)
            {
                return false;
            }

            if (col < 0 || col >= jagged[row].Length)
            {
                return false;
            }

            return true;
        }

        static void MoveInDirection(char[][] maze, string direction, ref int row, ref int col)
        {
            if (direction == "W")
            {
                row--;
            }
            else if (direction == "S")
            {
                row++;
            }
            else if (direction == "A")
            {
                col--;
            }
            else if (direction == "D")
            {
                col++;
            }
        }
    }
}
