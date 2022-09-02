using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace P06.ReverseAndExclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int dividor = int.Parse(Console.ReadLine());

            Predicate<int> condition = x => x % dividor == 0;
            numbers.RemoveAll(condition);

            Action<List<int>, List<int>, int> reverseList = Reverse;

            List<int> outputList = new List<int>();
            reverseList(numbers, outputList, numbers.Count - 1);

            Console.WriteLine(string.Join(" ", outputList));
        }

        static void Reverse(List<int> numbers, List<int> result, int index)
        {
            result.Add(numbers[index]);

            if (index > 0)
            {
                Reverse(numbers, result, --index);
            }
        }
    }
}