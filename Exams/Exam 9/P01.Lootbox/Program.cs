using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace P01.Lootbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstLootBox = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] secondLootBox = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int claimed = 0;
            Queue<int> lootBox1 = new Queue<int>(firstLootBox);
            Stack<int> lootBox2 = new Stack<int>(secondLootBox);

            while (lootBox1.Count > 0 && lootBox2.Count > 0)
            {
                int value1 = lootBox1.Peek();
                int value2 = lootBox2.Pop();

                int sum = value1 + value2;

                if (sum % 2 == 0)
                {
                    claimed += sum;
                    lootBox1.Dequeue();
                }
                else
                {
                    lootBox1.Enqueue(value2);
                }
            }

            if (lootBox1.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (claimed >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimed}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimed}");
            }
        }
    }
}
