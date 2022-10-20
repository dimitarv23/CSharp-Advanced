using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace P01.BirthdayCelebration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] guestsCapacities = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] foodPlates = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> guests = new Queue<int>(guestsCapacities);
            Stack<int> plates = new Stack<int>(foodPlates);
            int wastedFood = 0;

            while (guests.Count > 0 && plates.Count > 0)
            {
                var guest = guests.Peek();

                FeedGuest(guest, plates, ref wastedFood);
                guests.Dequeue();
            }

            if (guests.Count == 0)
            {
                Console.WriteLine($"Plates: {string.Join(" ", plates)}");
            }
            else if (plates.Count == 0)
            {
                Console.WriteLine($"Guests: {string.Join(" ", guests)}");
            }

            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }

        static void FeedGuest(int guest, Stack<int> plates, ref int wastedFood)
        {
            if (plates.Count == 0)
            {
                return;
            }

            var plate = plates.Pop();

            if (guest - plate <= 0)
            {
                wastedFood += plate - guest;
                return;
            }

            guest -= plate;
            FeedGuest(guest, plates, ref wastedFood);
        }
    }
}
