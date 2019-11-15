using System;

namespace ShortestUnsortedContinuousSubarray
{
    public class Solution
    {
        public int FindUnsortedSubarray(int[] nums)
        {
            if (nums == null)
            {
                return 0;
            }

            var start = -1;
            var end = -2;
            var max = int.MinValue;
            var min = int.MaxValue;
            for (var i = 0; i < nums.Length; i++)
            {
                max = Math.Max(max, nums[i]);
                min = Math.Min(min, nums[nums.Length - 1 - i]);
                start = nums[nums.Length - 1 - i] > min ? nums.Length - 1 - i : start;
                end = nums[i] < max ? i : end;
            }

            return end - start + 1;
        }
    }
}