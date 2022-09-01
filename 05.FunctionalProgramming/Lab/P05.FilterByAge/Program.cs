using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace P05.FilterByAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, int> pairs = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string[] pair = Console.ReadLine()
                    .Split(", ");

                if (!pairs.ContainsKey(pair[0]))
                {
                    pairs.Add(pair[0], int.Parse(pair[1]));
                }
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            //By default => condition is "older"
            Func<int, bool> checkFunc = x => x >= age;

            if (condition == "younger")
            {
                checkFunc = x => x < age;
            }

            foreach (var pair in pairs
                         .Where(x => checkFunc(x.Value)))
            {
                if (format == "name")
                {
                    Console.WriteLine($"{pair.Key}");
                }
                else if (format == "age")
                {
                    Console.WriteLine($"{pair.Value}");
                }
                else if (format == "name age")
                {
                    Console.WriteLine($"{pair.Key} - {pair.Value}");
                }
            }
        }
    }
}