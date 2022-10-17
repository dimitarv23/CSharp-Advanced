using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.TilesMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var whiteTileLocations = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var greyTileLocations = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Dictionary<string, int> locations = new Dictionary<string, int>();
            Stack<int> whiteTiles = new Stack<int>(whiteTileLocations);
            Queue<int> greyTiles = new Queue<int>(greyTileLocations);

            while (whiteTiles.Count > 0 && greyTiles.Count > 0)
            {
                var currWhiteTile = whiteTiles.Peek();
                var currGreyTile = greyTiles.Peek();

                if (currWhiteTile == currGreyTile)
                {
                    var newTile = currWhiteTile + currGreyTile;
                    EqualTiles(locations, newTile);

                    whiteTiles.Pop();
                    greyTiles.Dequeue();
                }
                else
                {
                    var whiteTile = whiteTiles.Pop();
                    whiteTiles.Push(whiteTile / 2);

                    var greyTile = greyTiles.Dequeue();
                    greyTiles.Enqueue(greyTile);
                }
            }

            Console.WriteLine($"White tiles left: {(whiteTiles.Count == 0 ? "none" : string.Join(", ", whiteTiles))}");
            Console.WriteLine($"Grey tiles left: {(greyTiles.Count == 0 ? "none" : string.Join(", ", greyTiles))}");

            foreach (var location in locations
                .OrderByDescending(l => l.Value)
                .ThenBy(l => l.Key))
            {
                Console.WriteLine($"{location.Key}: {location.Value}");
            }
        }

        static void EqualTiles(Dictionary<string, int> locations, int newTile)
        {
            switch (newTile)
            {
                case 40:
                    if (!locations.ContainsKey("Sink"))
                    {
                        locations.Add("Sink", 0);
                    }

                    locations["Sink"]++;
                    break;
                case 50:
                    if (!locations.ContainsKey("Oven"))
                    {
                        locations.Add("Oven", 0);
                    }

                    locations["Oven"]++;
                    break;
                case 60:
                    if (!locations.ContainsKey("Countertop"))
                    {
                        locations.Add("Countertop", 0);
                    }

                    locations["Countertop"]++;
                    break;
                case 70:
                    if (!locations.ContainsKey("Wall"))
                    {
                        locations.Add("Wall", 0);
                    }

                    locations["Wall"]++;
                    break;
                default:
                    if (!locations.ContainsKey("Floor"))
                    {
                        locations.Add("Floor", 0);
                    }

                    locations["Floor"]++;
                    break;
            }
        }
    }
}
