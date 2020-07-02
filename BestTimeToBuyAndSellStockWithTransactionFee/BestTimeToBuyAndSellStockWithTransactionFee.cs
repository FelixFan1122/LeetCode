using System;

namespace LeetCode.BestTimeToBuyAndSellStockWithTransactionFee
{
    public class Solution
    {
        public int MaxProfit(int[] prices, int fee)
        {
            if (prices == null)
            {
                return 0;
            }

            var noneHold = 0;
            var hold = int.MinValue;
            foreach (var price in prices)
            {
                var previousNoneHold = noneHold;
                noneHold = Math.Max(noneHold, hold + price);
                hold = Math.Max(hold, previousNoneHold - price - fee);
            }

            return noneHold;
        }
    }
}