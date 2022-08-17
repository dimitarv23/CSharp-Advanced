using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] setsLengths = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            HashSet<int> matchingSet = new HashSet<int>();

            for (int i = 0; i < setsLengths[0] + setsLengths[1]; i++)
            {
                int currNum = int.Parse(Console.ReadLine());

                if (i < setsLengths[0])
                {
                    if (!firstSet.Contains(currNum))
                    {
                        firstSet.Add(currNum);
                    }
                }
                else
                {
                    if (!secondSet.Contains(currNum))
                    {
                        secondSet.Add(currNum);
                    }
                }
            }

            foreach (var num in firstSet)
            {
                if (secondSet.Contains(num))
                {
                    matchingSet.Add(num);
                }
            }

            Console.WriteLine(string.Join(" ", matchingSet));
        }
    }
}
