using System;

namespace LeetCode.MaximumProductSubarray
{
    public class Solution
    {
        public int MaxProduct(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return -1;
            }

            var max = int.MinValue;
            var currentMax = 1;
            var currentMin = 1;
            foreach (var num in nums)
            {
                if (num > 0)
                {
                    currentMax = Math.Max(num * currentMax, num);
                    currentMin = Math.Min(num * currentMin, num);
                }
                else
                {
                    var previousMax = currentMax;
                    currentMax = Math.Max(num * currentMin, num);
                    currentMin = Math.Min(num * previousMax, num);
                }

                max = Math.Max(max, currentMax);
            }

            return max;
        }
    }
}