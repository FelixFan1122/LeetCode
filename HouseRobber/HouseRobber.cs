using System;

namespace HouseRobber
{
    public class Solution
    {
        public int Rob(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            if (nums.Length == 1)
            {
                return nums[0];
            }

            var previousPrevious = nums[0];
            var previous = Math.Max(nums[0], nums[1]);
            var current = previous;
            for (var i = 2; i < nums.Length; i++)
            {
                current = Math.Max(nums[i] + previousPrevious, previous);
                previousPrevious = previous;
                previous = current;
            }

            return current;
        }
    }
}