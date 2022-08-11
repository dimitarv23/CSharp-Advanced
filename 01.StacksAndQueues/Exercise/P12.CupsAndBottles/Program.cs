using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;

namespace P12.CupsAndBottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] cupsCapacities = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] filledBottles = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> cups = new Queue<int>(cupsCapacities);
            Stack<int> bottles = new Stack<int>(filledBottles);
            int wastedLiters = 0;

            while (bottles.Count > 0)
            {
                if (cups.Count == 0)
                {
                    break;
                }

                int currCup = cups.Dequeue();

                while (currCup > 0)
                {
                    if (bottles.Count == 0)
                    {
                        break;
                    }

                    int currBottle = bottles.Pop();

                    if (currBottle >= currCup)
                    {
                        wastedLiters += currBottle - currCup;
                        currCup = 0;
                        continue;
                    }

                    currCup -= currBottle;
                }
            }

            if (bottles.Count == 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }
            else if (cups.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedLiters}");
        }
    }
}
