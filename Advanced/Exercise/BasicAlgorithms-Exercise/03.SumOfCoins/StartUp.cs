namespace SumOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<int> coins = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int targetSum = int.Parse(Console.ReadLine());
            Dictionary<int, int> usedCoins = ChooseCoins(coins, targetSum);
            Console.WriteLine($"Number of coins to take: {usedCoins.Sum(c => c.Value)}");
            foreach (var coin in usedCoins)
            {
                Console.WriteLine($"{coin.Value} coin(s) with value {coin.Key}");
            }
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            Dictionary<int, int> usedCoins = new Dictionary<int, int>();

            List<int> sortedCoins = coins.OrderByDescending(x => x).ToList();
            for (int i = 0; i < sortedCoins.Count; i++)
            {
                while (targetSum - sortedCoins[i] >= 0)
                {
                    targetSum -= sortedCoins[i];
                    if (!usedCoins.ContainsKey(sortedCoins[i]))
                    {
                        usedCoins.Add(sortedCoins[i], 0);
                    }
                    usedCoins[sortedCoins[i]]++;
                }
                if (targetSum == 0)
                {
                    break;
                }
            }

            return usedCoins;
        }
    }
}