using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.BaristaContest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var coffeeDrinks = new Dictionary<int, string>()
            {
                { 50, "Cortado" },
                { 75, "Espresso" },
                { 100, "Capuccino" },
                { 150, "Americano" },
                { 200, "Latte" }
            };

            int[] coffeeQuantities = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int[] milkQuantities = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            var coffeesMade = new Dictionary<string, int>();
            var caffeine = new Queue<int>(coffeeQuantities);
            var milk = new Stack<int>(milkQuantities);

            while (caffeine.Count > 0 && milk.Count > 0)
            {
                int sum = caffeine.Peek() + milk.Peek();

                if (coffeeDrinks.ContainsKey(sum))
                {
                    string coffee = coffeeDrinks[sum];
                    caffeine.Dequeue();
                    milk.Pop();

                    if (!coffeesMade.ContainsKey(coffee))
                    {
                        coffeesMade.Add(coffee, 0);
                    }

                    coffeesMade[coffee]++;
                }
                else
                {
                    caffeine.Dequeue();
                    int currMilk = milk.Pop();
                    currMilk -= 5;
                    milk.Push(currMilk);
                }
            }

            if (caffeine.Count == 0 && milk.Count == 0)
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            Console.WriteLine($"Coffee left: {(caffeine.Count == 0 ? "none" : string.Join(", ", caffeine))}");
            Console.WriteLine($"Milk left: {(milk.Count == 0 ? "none" : string.Join(", ", milk))}");

            foreach (var coffee in coffeesMade
                .OrderBy(c => c.Value).ThenByDescending(c => c.Key))
            {
                Console.WriteLine($"{coffee.Key}: {coffee.Value}");
            }
        }
    }
}
