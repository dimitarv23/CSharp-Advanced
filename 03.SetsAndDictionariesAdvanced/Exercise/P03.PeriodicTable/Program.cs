using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> elements = new HashSet<string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] chemicalCompounds = Console.ReadLine()
                    .Split();

                foreach (var element in chemicalCompounds)
                {
                    if (!elements.Contains(element))
                    {
                        elements.Add(element);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", elements.OrderBy(x => x)));
        }
    }
}
