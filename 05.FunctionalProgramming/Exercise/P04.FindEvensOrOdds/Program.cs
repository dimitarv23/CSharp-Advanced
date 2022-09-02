using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.FindEvensOrOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> bounds = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            string command = Console.ReadLine();

            //output list
            List<int> filteredNumbers = new List<int>();

            Predicate<int> condition = x => true;

            if (command == "even")
            {
                condition = x => x % 2 == 0;
            }
            else if (command == "odd")
            {
                condition = x => x % 2 != 0;
            }

            Action<List<int>, List<int>, Predicate<int>> action = GetNumbersByCondition;
            action(filteredNumbers, bounds, condition);

            if (filteredNumbers.Count > 0)
            {
                Console.WriteLine(string.Join(" ", filteredNumbers));
            }
        }

        static void GetNumbersByCondition(List<int> output, List<int> bounds, Predicate<int> condition)
        {
            int currNum = bounds[0];

            if (condition(currNum))
            {
                output.Add(currNum);
            }

            if (bounds[0] < bounds[1])
            {
                bounds[0]++;
                GetNumbersByCondition(output, bounds, condition);
            }
        }
    }
}
