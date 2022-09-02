using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;

namespace P05.AppliedArithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<List<int>> add = n =>
            {
                for (int i = 0; i < n.Count; i++)
                {
                    n[i]++;
                }
            };

            Action<List<int>> multiply = n =>
            {
                for (int i = 0; i < n.Count; i++)
                {
                    n[i] *= 2;
                }
            };

            Action<List<int>> subtract = n =>
            {
                for (int i = 0; i < n.Count; i++)
                {
                    n[i]--;
                }
            };

            Action<List<int>> print = n => Console.WriteLine(string.Join(" ", n));
            
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();
            while (command != "end")
            {
                if (command == "add")
                {
                    add(numbers);
                }
                else if (command == "multiply")
                {
                    multiply(numbers);
                }
                else if (command == "subtract")
                {
                    subtract(numbers);
                }
                else if (command == "print")
                {
                    print(numbers);
                }

                command = Console.ReadLine();
            }
        }
    }
}
