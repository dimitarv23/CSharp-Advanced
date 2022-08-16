using System;
using System.Collections.Generic;

namespace P05.CitiesByContinentAndCountry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> locations = new Dictionary<string, Dictionary<string, List<string>>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] location = Console.ReadLine().Split();
                string continent = location[0];
                string country = location[1];
                string city = location[2];

                if (!locations.ContainsKey(continent))
                {
                    locations.Add(continent, new Dictionary<string, List<string>>());
                }

                if (!locations[continent].ContainsKey(country))
                {
                    locations[continent][country] = new List<string>();
                }

                locations[continent][country].Add(city);
            }

            foreach (var location in locations)
            {
                Console.WriteLine($"{location.Key}:");

                foreach (var country in location.Value)
                {
                    Console.WriteLine($"{country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
