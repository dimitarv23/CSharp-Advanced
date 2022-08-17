using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> occurencies = new Dictionary<char, int>();
            string input = Console.ReadLine();

            foreach (var ch in input)
            {
                if (!occurencies.ContainsKey(ch))
                {
                    occurencies.Add(ch, 0);
                }

                occurencies[ch]++;
            }

            foreach (var occurence in occurencies.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{occurence.Key}: {occurence.Value} time/s");
            }
        }
    }
}
