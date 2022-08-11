using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clothesValues = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rackCapacity = int.Parse(Console.ReadLine());

            int currSum = 0;
            int racksCount = 0;
            Stack<int> clothes = new Stack<int>(clothesValues);

            while (clothes.Count > 0)
            {
                if (currSum + clothes.Peek() <= rackCapacity)
                {
                    currSum += clothes.Pop();
                }
                else if (currSum + clothes.Peek() > rackCapacity)
                {
                    racksCount++;
                    currSum = 0;
                }
            }

            if (currSum > 0)
            {
                racksCount++;
            }

            Console.WriteLine(racksCount);
        }
    }
}
