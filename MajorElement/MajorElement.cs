using System;

namespace LeetCode.MajorElement
{
    public class Solution
    {
        public int MajorityElement(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                throw new ArgumentException();
            }

            var candidate = nums[0];
            var count = 1;
            for (var i = 1; i < nums.Length; i++)
            {
                if (count == 0)
                {
                    candidate = nums[i];
                }

                count += nums[i] == candidate ? 1 : -1;
            }

            return candidate;
        }
    }
}