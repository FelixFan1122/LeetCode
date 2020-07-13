namespace LeetCode.RunningSumOf1DArray
{
    public class Solution
    {
        public int[] RunningSum(int[] nums)
        {
            var sums = new int[nums.Length];
            sums[0] = nums[0];
            for (var i = 1; i < nums.Length; i++)
            {
                sums[i] = sums[i - 1] + nums[i];
            }

            return sums;
        }
    }
}