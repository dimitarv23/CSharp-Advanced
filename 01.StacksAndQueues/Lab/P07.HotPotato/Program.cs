using System;
using System.Collections.Generic;

namespace P07.HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Queue<string> kids = new Queue<string>(names);

            int n = int.Parse(Console.ReadLine());
            int counter = 0;

            while (kids.Count > 1)
            {
                string currKid = kids.Dequeue();
                counter++;

                if (counter == n)
                {
                    Console.WriteLine($"Removed {currKid}");
                    counter = 0;
                }
                else
                {
                    kids.Enqueue(currKid);
                }
            }

            Console.WriteLine($"Last is {kids.Peek()}");
        }
    }
}
