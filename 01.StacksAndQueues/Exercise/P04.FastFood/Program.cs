using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());

            int[] orders = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Console.WriteLine(orders.Max());

            Queue<int> ordersQueue = new Queue<int>(orders);

            while (ordersQueue.Count > 0)
            {
                if (foodQuantity >= ordersQueue.Peek())
                {
                    foodQuantity -= ordersQueue.Dequeue();
                }
                else
                {
                    break;
                }
            }

            if (ordersQueue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", ordersQueue)}");
            }
        }
    }
}
