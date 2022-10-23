using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.EnergyDrinks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] caffeineMilligrams = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] energyDrinks = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int caffeineIntake = 0;
            Stack<int> caffeine = new Stack<int>(caffeineMilligrams);
            Queue<int> energy = new Queue<int>(energyDrinks);

            while (caffeine.Count > 0 && energy.Count > 0)
            {
                var currCaffeine = caffeine.Peek();
                var currEnergy = energy.Peek();

                var result = currCaffeine * currEnergy;

                if (result + caffeineIntake <= 300)
                {
                    caffeineIntake += result;
                    caffeine.Pop();
                    energy.Dequeue();
                }
                else
                {
                    caffeine.Pop();
                    energy.Dequeue();
                    energy.Enqueue(currEnergy);

                    if (caffeineIntake >= 30)
                    {
                        caffeineIntake -= 30;
                    }
                    else
                    {
                        caffeineIntake = 0;
                    }
                }
            }

            if (energy.Count > 0)
            {
                Console.WriteLine($"Drinks left: {string.Join(", ", energy)}");
            }
            else
            {
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            }

            Console.WriteLine($"Stamat is going to sleep with {caffeineIntake} mg caffeine.");
        }
    }
}
