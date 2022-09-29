using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.SumOfCoins
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<int> coins = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToList();
            int targetSum = int.Parse(Console.ReadLine());

            Dictionary<int, int> chosenCoins = ChooseCoins(coins, targetSum);

            Console.WriteLine($"Number of coins to take: {chosenCoins.Values.Sum()}");

            foreach (var coin in chosenCoins)
            {
                Console.WriteLine($"{coin.Value} coin(s) with value {coin.Key}");
            }
        }

        public static Dictionary<int, int> ChooseCoins(List<int> coins, int targetSum)
        {
            var chosenCoins = new Dictionary<int, int>();
            coins = coins.OrderByDescending(x => x).ToList();

            int currSum = 0;
            int coinIndex = 0;

            while (currSum < targetSum && coinIndex < coins.Count)
            {
                int currCoin = coins[coinIndex];
                int remainingSum = targetSum - currSum;
                int numberOfCoins = remainingSum / currCoin;
                currSum += currCoin * numberOfCoins;

                if (currSum <= targetSum && numberOfCoins > 0)
                {
                    if (!chosenCoins.ContainsKey(currCoin))
                    {
                        chosenCoins.Add(currCoin, 0);
                    }

                    chosenCoins[currCoin] += numberOfCoins;
                }

                coinIndex++;
            }

            if (currSum != targetSum)
            {
                throw new InvalidOperationException();
            }

            return chosenCoins;
        }
    }
}
