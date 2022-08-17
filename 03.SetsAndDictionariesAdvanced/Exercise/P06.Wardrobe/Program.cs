using System;
using System.Collections.Generic;

namespace P06.Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> clothes = new Dictionary<string, Dictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine()
                    .Split(" -> ");
                string color = info[0];
                string[] items = info[1].Split(",");

                if (!clothes.ContainsKey(color))
                {
                    clothes.Add(color, new Dictionary<string, int>());
                }

                foreach (var item in items)
                {
                    if (!clothes[color].ContainsKey(item))
                    {
                        clothes[color].Add(item, 0);
                    }

                    clothes[color][item]++;
                }
            }

            string[] searched = Console.ReadLine().Split();
            string searchedColor = searched[0];
            string searchedCloth = searched[1];

            foreach (var cloth in clothes)
            {
                Console.WriteLine($"{cloth.Key} clothes:");

                foreach (var item in cloth.Value)
                {
                    Console.Write($"* {item.Key} - {item.Value}");

                    if (cloth.Key == searchedColor && item.Key == searchedCloth)
                    {
                        Console.Write(" (found!)");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
