using System;
using System.Collections.Generic;

namespace P04.EvenTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> occurencies = new Dictionary<int, int>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int currNum = int.Parse(Console.ReadLine());

                if (!occurencies.ContainsKey(currNum))
                {
                    occurencies.Add(currNum, 0);
                }

                occurencies[currNum]++;
            }

            foreach (var occurence in occurencies)
            {
                if (occurence.Value % 2 == 0)
                {
                    Console.WriteLine(occurence.Key);
                }
            }
        }
    }
}
