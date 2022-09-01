using System;
using System.Linq;

namespace P02.SumNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> ParseElement = x => int.Parse(x);
            Func<int[], int> CountElements = x => x.Length;
            Func<int[], long> SumElements = x => x.Sum();

            int[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(ParseElement)
                .ToArray();

            Console.WriteLine(CountElements(numbers));
            Console.WriteLine(SumElements(numbers));
        }
    }
}
