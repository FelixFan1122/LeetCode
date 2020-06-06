namespace LeetCode.BestTimeToBuyAndSellStock
{
    public class Solution
    {
        public int MaxProfit(int[] prices)
        {
            if (prices == null || prices.Length == 0)
            {
                return 0;
            }

            var maxProfit = 0;
            var min = prices[0];
            foreach (var price in prices)
            {
                if (price < min)
                {
                    min = price;
                }
                else if (price - min > maxProfit)
                {
                    maxProfit = price - min;
                }
            }

            return maxProfit;
        }
    }
}