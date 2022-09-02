using System;
using System.Linq;

namespace P03.CustomMinFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> getSmallestNum = GetMinNumber;
            Action<int> printSmallestNum = x => Console.WriteLine(x);

            printSmallestNum(getSmallestNum(numbers));
        }

        static int GetMinNumber(int[] numbers)
        {
            int min = int.MaxValue;

            foreach (var number in numbers)
            {
                if (number < min)
                {
                    min = number;
                }
            }

            return min;
        }
    }
}
