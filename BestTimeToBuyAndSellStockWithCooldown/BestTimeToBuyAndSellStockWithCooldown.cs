using System;

namespace LeetCode.BestTimeToBuyAndSellStockWithCooldown
{
    public class Solution
    {
        public int MaxProfit(int[] prices)
        {
            if (prices == null)
            {
                return 0;
            }

            var nonHold = 0;
            var hold = int.MinValue;
            var previousNonHold = 0;
            foreach (var price in prices)
            {
                var temp = nonHold;
                nonHold = Math.Max(nonHold, hold + price);
                hold = Math.Max(hold, previousNonHold - price);
                previousNonHold = temp;
            }

            return nonHold;
        }
    }
}