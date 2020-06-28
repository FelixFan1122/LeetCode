namespace LeetCode.MaximumSubArray
{
    public class Solution
    {
        public int MaxSubArray(int[] nums)
        {
            var maxSum = nums[0];
            var currentSum = nums[0];
            for (var i = 1; i < nums.Length; i++)
            {
                if (currentSum < 0)
                {
                    currentSum = nums[i];
                }
                else
                {
                    currentSum += nums[i];
                }

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                }
            }

            return maxSum;
        }
    }
}