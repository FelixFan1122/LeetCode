using System;

namespace BurstBalloons
{
    public class Solution
    {
        public int MaxCoins(int[] nums)
        {
            if (nums == null)
            {
                return 0;
            }

            var maxCoins = new int[nums.Length + 2, nums.Length + 2];
            for (var size = 2; size < maxCoins.GetLength(0); size++)
            {
                for (var i = 0; i < maxCoins.GetLength(0) - size; i++)
                {
                    var j = i + size;
                    for (var k = i + 1; k < j; k++)
                    {
                        maxCoins[i, j] = Math.Max(maxCoins[i, j], maxCoins[i, k] + (i == 0 ? 1 : nums[i - 1]) * nums[k - 1] * (j == nums.Length + 1 ? 1 : nums[j - 1]) + maxCoins[k, j]);
                    }
                }
            }

            return maxCoins[0, maxCoins.GetLength(1) - 1];
        }
    }
}