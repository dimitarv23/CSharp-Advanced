using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace P04.ProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> shops = new Dictionary<string, Dictionary<string, double>>();

            string command = Console.ReadLine();
            while (command != "Revision")
            {
                string[] cmdArgs = command.Split(", ");
                string shopName = cmdArgs[0];
                string product = cmdArgs[1];
                double price = double.Parse(cmdArgs[2]);

                if (!shops.ContainsKey(shopName))
                {
                    shops.Add(shopName, new Dictionary<string, double>());
                }

                shops[shopName].Add(product, price);
                command = Console.ReadLine();
            }

            foreach (var shop in shops
                         .OrderBy(x => x.Key))
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
