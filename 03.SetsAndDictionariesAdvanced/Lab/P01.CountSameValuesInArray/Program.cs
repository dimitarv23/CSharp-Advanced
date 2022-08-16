using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.CountSameValuesInArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> occurencies = new Dictionary<double, int>();

            double[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            foreach (var number in numbers)
            {
                if (occurencies.ContainsKey(number))
                {
                    occurencies[number]++;
                }
                else
                {
                    occurencies[number] = 1;
                }
            }

            foreach (var occurence in occurencies)
            {
                Console.WriteLine($"{occurence.Key} - {occurence.Value} times");
            }
        }
    }
}
