using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.SongsQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            Queue<string> playlist = new Queue<string>(songs);

            while (playlist.Count > 0)
            {
                List<string> cmdArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                string action = cmdArgs[0];

                if (action == "Play")
                {
                    playlist.Dequeue();
                }
                else if (action == "Add")
                {
                    cmdArgs.RemoveAt(0);
                    string newSong = string.Join(" ", cmdArgs);

                    if (playlist.Contains(newSong))
                    {
                        Console.WriteLine($"{newSong} is already contained!");
                    }
                    else
                    {
                        playlist.Enqueue(newSong);
                    }
                }
                else if (action == "Show")
                {
                    Console.WriteLine(string.Join(", ", playlist));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
