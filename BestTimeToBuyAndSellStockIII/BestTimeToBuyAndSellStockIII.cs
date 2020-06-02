using System;

namespace LeetCode.BestTimeToBuyAndSellStockIII
{
    public class Solution
    {
        public int MaxProfit(int[] prices)
        {
            if (prices == null)
            {
                return 0;
            }

            var min1 = int.MaxValue;
            var min2 = int.MaxValue;
            var profit1 = 0;
            var profit2 = 0;
            foreach (var price in prices)
            {
                min1 = Math.Min(min1, price);
                profit1 = Math.Max(profit1, price - min1);
                min2 = Math.Min(min2, price - profit1);
                profit2 = Math.Max(profit2, price - min2);
            }

            return profit2;
        }
    }
}