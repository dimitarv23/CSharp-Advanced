using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.BakeryShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] watersAmounts = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            double[] flourAmounts = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            var products = new Dictionary<string, int>();
            Queue<double> waters = new Queue<double>(watersAmounts);
            Stack<double> flours = new Stack<double>(flourAmounts);

            while (waters.Count > 0 && flours.Count > 0)
            {
                double currWater = waters.Peek();
                double currFlour = flours.Peek();

                double totalAmount = currWater + currFlour;
                double percentageWater = currWater / totalAmount * 100;

                if (percentageWater == 50)
                {
                    IncreaseProduct(products, "Croissant");
                }
                else if (percentageWater == 40)
                {
                    IncreaseProduct(products, "Muffin");
                }
                else if (percentageWater == 30)
                {
                    IncreaseProduct(products, "Baguette");
                }
                else if (percentageWater == 20)
                {
                    IncreaseProduct(products, "Bagel");
                }
                else
                {
                    waters.Dequeue();
                    flours.Pop();

                    IncreaseProduct(products, "Croissant");

                    currFlour -= currWater;
                    flours.Push(currFlour);
                    continue;
                }

                waters.Dequeue();
                flours.Pop();
            }

            foreach (var product in products
                .OrderByDescending(p => p.Value)
                .ThenBy(p => p.Key))
            {
                Console.WriteLine($"{product.Key}: {product.Value}");
            }

            Console.WriteLine($"Water left: {(waters.Count == 0 ? "None" : string.Join(", ", waters))}");
            Console.WriteLine($"Flour left: {(flours.Count == 0 ? "None" : string.Join(", ", flours))}");
        }
        static void IncreaseProduct(Dictionary<string, int> products, string product)
        {
            if (!products.ContainsKey(product))
            {
                products.Add(product, 0);
            }

            products[product]++;
        }
    }
}
