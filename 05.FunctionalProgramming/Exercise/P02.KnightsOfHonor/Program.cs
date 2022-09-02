using System;

namespace P02.KnightsOfHonor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] knights = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Action<string> printKnights = k => Console.WriteLine($"Sir {k}");

            foreach (var knight in knights)
            {
                printKnights(knight);
            }
        }
    }
}
