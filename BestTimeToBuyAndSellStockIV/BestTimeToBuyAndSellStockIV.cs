using System;
using System.Collections.Generic;

namespace BestTimeToBuyAndSellStockIV
{
    public class Solution
    {
        public int MaxProfit(int k, int[] prices)
        {
            var peak = 0;
            var valley = 0;
            var candidates = new Stack<Tuple<int, int>>();
            var profits = new MaxPriorityQueue<int>(prices.Length);
            while (peak < prices.Length)
            {
                for (valley = peak; valley < prices.Length - 1 && prices[valley] >= prices[valley + 1]; valley++);
                for (peak = valley + 1; peak < prices.Length && prices[peak] >= prices[peak - 1]; peak++);
                while (candidates.Count > 0 && prices[valley] < prices[candidates.Peek().Item1])
                {
                    profits.Add(prices[candidates.Peek().Item2 - 1] - prices[candidates.Peek().Item1]);
                    candidates.Pop();
                }

                while (candidates.Count > 0 && prices[peak - 1] >= prices[candidates.Peek().Item2 - 1])
                {
                    profits.Add(prices[candidates.Peek().Item2 - 1] - prices[valley]);
                    valley = candidates.Peek().Item1;
                    candidates.Pop();
                }

                candidates.Push(new Tuple<int, int>(valley, peak));
            }

            while (candidates.Count > 0)
            {
                profits.Add(prices[candidates.Peek().Item2 - 1] - prices[candidates.Peek().Item1]);
                candidates.Pop();
            }

            var max = 0;
            for (; k > 0 && !profits.IsEmpty; k--)
            {
                max += profits.DeleteMax();
            }

            return max;
        }
    }
}