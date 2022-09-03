using System;
using System.Collections.Generic;
using System.Linq;

namespace P11.TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine()
                .Split()
                .ToList();

            Func<string, int, bool> isSumMoreThanN = DetermineSum;
            Func<List<string>, Func<string, int, bool>, int, string> getFirstEncounter = GetFirstEncounter;

            string firstOccurrence = getFirstEncounter(names, isSumMoreThanN, n);

            if (firstOccurrence != null)
            {
                Console.WriteLine(firstOccurrence);
            }
        }

        static string GetFirstEncounter(List<string> names, Func<string, int, bool> isSumMoreThanN, int n)
        {
            foreach (var name in names)
            {
                if (isSumMoreThanN(name, n))
                {
                    return name;
                }
            }

            return null;
        }

        static bool DetermineSum(string text, int n)
        {
            //Whether the sum of the text is more than or equal to N
            Func<string, int, int, int> calculateSum = CalculateTextSum;
            int sumOfChars = calculateSum(text, 0, 0);

            return sumOfChars >= n;
        }

        static int CalculateTextSum(string text, int sum, int index)
        {
            //Calculates the sum of all the chars in a text
            sum += text[index];
            index++;

            if (index < text.Length)
            {
                return CalculateTextSum(text, sum, index);
            }

            return sum;
        }
    }
}
