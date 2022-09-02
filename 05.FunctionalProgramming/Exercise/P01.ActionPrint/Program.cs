using System;

namespace P01.ActionPrint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Action<string> printResult = x => Console.WriteLine(x);

            foreach (var element in input)
            {
                printResult(element);
            }
        }
    }
}
