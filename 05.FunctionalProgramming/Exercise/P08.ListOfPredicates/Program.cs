using System;
using System.Collections.Generic;
using System.Linq;

namespace P08.ListOfPredicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int endOfRange = int.Parse(Console.ReadLine());
            var dividers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Distinct()
                .ToList();
            var numbers = Enumerable.Range(1, endOfRange).ToList();

            Predicate<int> removeCommonDividors = x => x == 0 || x == 1;
            dividers.RemoveAll(removeCommonDividors);
            
            List<Predicate<int>> predicates = new List<Predicate<int>>();

            foreach (var divider in dividers)
            {
                Predicate<int> predicate = x => x % divider == 0;
                predicates.Add(predicate);
            }

            var output = new List<int>();
            
            foreach (var number in numbers)
            {
                bool canBeDividedByAll = true;

                foreach (var predicate in predicates)
                {
                    if (!predicate(number))
                    {
                        canBeDividedByAll = false;
                        break;
                    }
                }

                if (canBeDividedByAll)
                {
                    output.Add(number);
                }
            }

            Console.WriteLine(string.Join(" ", output));
        }
    }
}
