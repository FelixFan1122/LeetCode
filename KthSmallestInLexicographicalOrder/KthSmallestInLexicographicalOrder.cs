using System;

namespace LeetCode.KthSmallestInLexicographicalOrder
{
    public class Solution
    {
        public int FindKthNumber(int n, int k)
        {
            var current = 1;
            k--;
            while (k > 0)
            {
                var childCount = GetChildNodeCount(n, current);
                if (childCount > k)
                {
                    current *= 10;
                    k--;
                }
                else
                {
                    current++;
                    k -= childCount;
                }
            }

            return current;
        }

        private int GetChildNodeCount(int n, long current)
        {
            var count = 0;
            var upperBound = current + 1;
            while (current <= n)
            {
                count += (int)(upperBound - current);
                current *= 10;
                upperBound = Math.Min(upperBound * 10, n + 1);
            }

            return count;
        }
    }
}