using System.Linq;

namespace LeetCode.TargetSum
{
    public class Solution
    {
        public int FindTargetSumWays(int[] nums, int S)
        {
            var sum = nums.Sum();
            if (sum < S)
            {
                return 0;
            }

            var target = sum + S;
            if (target % 2 != 0)
            {
                return 0;
            }

            return FindSubsetSumWays(nums, target / 2);
        }

        private int FindSubsetSumWays(int[] nums, int target)
        {
            var sums = new int[target + 1];
            sums[0] = 1;
            foreach (var num in nums)
            {
                for (var i = target; i >= num; i--)
                {
                    sums[i] += sums[i - num];
                }
            }

            return sums[target];
        }
    }
}