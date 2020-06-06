namespace LeetCode.BestTimeToBuyAndSellStockII
{
    public class Solution
    {
        public int MaxProfit(int[] prices)
        {
            if (prices == null || prices.Length < 2)
            {
                return 0;
            }

            var profit = 0;
            var i = 1;
            int min;
            while (i < prices.Length)
            {
                while (i < prices.Length && prices[i] <= prices[i - 1])
                {
                    i++;
                }

                min = prices[i - 1];
                while (i < prices.Length && prices[i] >= prices[i - 1])
                {
                    i++;
                }

                profit += prices[i - 1] - min;
            }

            return profit;
        }
    }
}