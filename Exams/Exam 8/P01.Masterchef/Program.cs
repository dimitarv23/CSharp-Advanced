using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace P01.Masterchef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ingredientsValues = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] ingredientsFreshness = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var dishes = new Dictionary<string, int>();
            Queue<int> ingredients = new Queue<int>(ingredientsValues);
            Stack<int> freshnesses = new Stack<int>(ingredientsFreshness);

            while (ingredients.Count > 0 && freshnesses.Count > 0)
            {
                var ingredient = ingredients.Peek();
                var freshness = freshnesses.Peek();

                if (ingredient == 0)
                {
                    ingredients.Dequeue();
                    continue;
                }

                var result = ingredient * freshness;

                if (result == 150)
                {
                    AddDish(dishes, "Dipping sauce");
                }
                else if (result == 250)
                {
                    AddDish(dishes, "Green salad");
                }
                else if (result == 300)
                {
                    AddDish(dishes, "Chocolate cake");
                }
                else if (result == 400)
                {
                    AddDish(dishes, "Lobster");
                }
                else
                {
                    freshnesses.Pop();
                    ingredients.Dequeue();
                    ingredients.Enqueue(ingredient + 5);

                    continue;
                }

                ingredients.Dequeue();
                freshnesses.Pop();
            }

            Console.WriteLine(dishes.Count == 4 ? "Applause! The judges are fascinated by your dishes!"
                : "You were voted off. Better luck next year.");

            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            foreach (var dish in dishes.OrderBy(d => d.Key))
            {
                Console.WriteLine($" # {dish.Key} --> {dish.Value}");
            }
        }

        static void AddDish(Dictionary<string, int> dishes, string dish)
        {
            if (!dishes.ContainsKey(dish))
            {
                dishes.Add(dish, 0);
            }

            dishes[dish]++;
        }
    }
}
