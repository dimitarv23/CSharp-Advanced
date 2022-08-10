using System;
using System.Collections.Generic;

namespace P08.TrafficJam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> cars = new Queue<string>();
            int n = int.Parse(Console.ReadLine());
            int counterPassed = 0;

            string command = Console.ReadLine();
            while (command != "end")
            {
                if (command == "green")
                {
                    for (int i = 0; i < n && cars.Count > 0; i++)
                    {
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        counterPassed++;
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"{counterPassed} cars passed the crossroads.");
        }
    }
}
