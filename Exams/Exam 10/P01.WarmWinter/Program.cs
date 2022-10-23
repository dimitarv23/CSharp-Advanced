using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.WarmWinter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] hatsPrices = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] scarvesPrices = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var sets = new List<int>();
            Stack<int> hats = new Stack<int>(hatsPrices);
            Queue<int> scarves = new Queue<int>(scarvesPrices);

            while (hats.Count > 0 && scarves.Count > 0)
            {
                var hat = hats.Pop();
                var scarf = scarves.Peek();

                if (hat > scarf)
                {
                    sets.Add(hat + scarf);
                    scarves.Dequeue();
                }
                else if (hat == scarf)
                {
                    scarves.Dequeue();
                    hat++;
                    hats.Push(hat);
                }
            }

            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            Console.WriteLine(string.Join(" ", sets));
        }
    }
}
