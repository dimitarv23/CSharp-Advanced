using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Security.Cryptography;

namespace P01.Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] steelAmounts = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] carbonAmounts = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var swords = new Dictionary<string, int>();
            Queue<int> steel = new Queue<int>(steelAmounts);
            Stack<int> carbon = new Stack<int>(carbonAmounts);

            while (steel.Count > 0 && carbon.Count > 0)
            {
                int currSteel = steel.Peek();
                int currCarbon = carbon.Peek();

                int sum = currSteel + currCarbon;

                if (sum == 70)
                {
                    ForgeSword(swords, "Gladius");
                }
                else if (sum == 80)
                {
                    ForgeSword(swords, "Shamshir");
                }
                else if (sum == 90)
                {
                    ForgeSword(swords, "Katana");
                }
                else if (sum == 110)
                {
                    ForgeSword(swords, "Sabre");
                }
                else if (sum == 150)
                {
                    ForgeSword(swords, "Broadsword");
                }
                else
                {
                    steel.Dequeue();
                    var carbonToEdit = carbon.Pop();
                    carbonToEdit += 5;
                    carbon.Push(carbonToEdit);
                    continue;
                }

                steel.Dequeue();
                carbon.Pop();
            }

            if (swords.Count == 0)
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }
            else
            {
                Console.WriteLine($"You have forged {swords.Values.Sum()} swords.");
            }

            Console.WriteLine($"Steel left: {(steel.Count == 0 ? "none" : string.Join(", ", steel))}");
            Console.WriteLine($"Carbon left: {(carbon.Count == 0 ? "none" : string.Join(", ", carbon))}");

            foreach (var sword in swords
                .OrderBy(s => s.Key))
            {
                Console.WriteLine($"{sword.Key}: {sword.Value}");
            }
        }

        static void ForgeSword(Dictionary<string, int> swords, string sword)
        {
            if (!swords.ContainsKey(sword))
            {
                swords.Add(sword, 0);
            }

            swords[sword]++;
        }
    }
}
