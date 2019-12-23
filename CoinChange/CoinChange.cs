using System;
using System.Collections.Generic;

namespace LeetCode.CoinChange
{
    public class Solution
    {
        public int CoinChange(int[] coins, int amount)
        {
            if (coins == null || coins.Length == 0)
            {
                return -1;
            }

            var coinChanges = new Dictionary<int, int>();
            Array.Sort(coins);
            var coinChange = CoinChange(coins, amount, coinChanges);
            if (coinChange == int.MaxValue)
            {
                coinChange = -1;
            }

            return coinChange;
        }

        private int CoinChange(int[] coins, int amount, Dictionary<int, int> coinChanges)
        {
            if (amount == 0)
            {
                return 0;
            }

            if (coinChanges.ContainsKey(amount))
            {
                return coinChanges[amount];
            }

            var min = int.MaxValue;
            var i = 0;
            while (i < coins.Length && coins[i] <= amount)
            {
                var coinChange = CoinChange(coins, amount - coins[i], coinChanges);
                if (coinChange != int.MaxValue)
                {
                    min = Math.Min(min, 1 + coinChange);
                }

                i++;
            }

            coinChanges[amount] = min;
            return min;
        }
    }
}