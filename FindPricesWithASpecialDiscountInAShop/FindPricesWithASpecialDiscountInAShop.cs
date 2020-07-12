namespace LeetCode.FindPricesWithASpecialDiscountInAShop
{
    public class Solution
    {
        public int[] FinalPrices(int[] prices)
        {
            var final = new int[prices.Length];
            for (var i = 0; i < prices.Length; i++)
            {
                var j = i + 1;
                while (j < prices.Length && prices[j] > prices[i])
                {
                    j++;
                }

                final[i] = prices[i] - (j < prices.Length ? prices[j] : 0);
            }

            return final;
        }
    }
}