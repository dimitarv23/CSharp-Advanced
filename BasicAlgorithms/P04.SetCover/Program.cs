using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.SetCover
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var universe = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToList();
            int numberOfSets = int.Parse(Console.ReadLine());
            var sets = new int[numberOfSets][];

            for (int i = 0; i < sets.Length; i++)
            {
                sets[i] = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();
            }

            List<int[]> selectedSets = ChooseSets(sets.ToList(), universe.ToList());
            Console.WriteLine($"Sets to take ({selectedSets.Count}):");

            foreach (var set in selectedSets)
            {
                Console.WriteLine($"{{ {string.Join(", ", set)} }}");
            }
        }

        public static List<int[]> ChooseSets(List<int[]> sets, List<int> universe)
        {
            var selectedSets = new List<int[]>();

            while (universe.Count > 0)
            {
                int[] longestSet = sets
                    .OrderByDescending(s => s.Count(x => universe.Contains(x)))
                    .FirstOrDefault();

                selectedSets.Add(longestSet);
                sets.Remove(longestSet);

                foreach (var item in longestSet)
                {
                    if (universe.Contains(item))
                    {
                        universe.RemoveAll(x => x == item);
                    }
                }
            }

            return selectedSets;
        }
    }
}
