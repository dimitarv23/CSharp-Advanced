using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.MealPlan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] mealsArr = Console.ReadLine().Split();
            int[] caloriesArr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<string> meals = new Queue<string>(mealsArr);
            Stack<int> calories = new Stack<int>(caloriesArr);

            while (meals.Count > 0 && calories.Count > 0)
            {
                string currMeal = meals.Peek();
                int caloriesOfMeal = GetCaloriesOfAMeal(currMeal);
                int currDailyIntake = calories.Peek();

                if (currDailyIntake - caloriesOfMeal > 0)
                {
                    currDailyIntake -= caloriesOfMeal;
                    calories.Pop();
                    calories.Push(currDailyIntake);
                    meals.Dequeue();
                }
                else if (currDailyIntake - caloriesOfMeal == 0)
                {
                    calories.Pop();
                    meals.Dequeue();
                }
                else
                {
                    int remainingCalories = caloriesOfMeal - currDailyIntake;
                    calories.Pop();
                    meals.Dequeue();

                    if (calories.Count == 0)
                    {
                        break;
                    }

                    int nextDayIntake = calories.Pop();
                    calories.Push(nextDayIntake - remainingCalories);
                }
            }

            if (meals.Count == 0)
            {
                Console.WriteLine($"John had {mealsArr.Length} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", calories)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {mealsArr.Length - meals.Count} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }
        }

        static int GetCaloriesOfAMeal(string meal)
        {
            switch (meal)
            {
                case "salad": return 350;
                case "soup": return 490;
                case "pasta": return 680;
                default: return 790;
            }
        }
    }
}
