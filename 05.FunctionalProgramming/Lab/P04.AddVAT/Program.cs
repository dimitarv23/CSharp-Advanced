using System;
using System.Linq;

namespace P04.AddVAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, double> ParseElement = x => double.Parse(x);

            double[] prices = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(ParseElement)
                .ToArray();

            Func<double, double> AddVAT = x => x * 1.2;
            double[] pricesAfterVAT = prices.Select(AddVAT).ToArray();

            Action<double> printPricesAfterVAT = x => Console.WriteLine($"{x:f2}");

            foreach (var price in pricesAfterVAT)
            {
                printPricesAfterVAT(price);
            }
        }
    }
}