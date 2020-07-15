using System.Collections.Generic;

namespace LeetCode.FinalPricesWithASpecialDiscountInAShop
{
    public class Solution
    {
        public int[] FinalPrices(int[] prices)
        {
            var final = new int[prices.Length];
            var toBeDetermined = new Stack<int>();
            for (var i = 0; i < prices.Length; i++)
            {
                while (toBeDetermined.Count > 0 && prices[toBeDetermined.Peek()] >= prices[i])
                {
                    final[toBeDetermined.Peek()] = prices[toBeDetermined.Peek()] - prices[i];
                    toBeDetermined.Pop();
                }

                toBeDetermined.Push(i);
            }

            foreach (var index in toBeDetermined) final[index] = prices[index];

            return final;
        }
    }
}