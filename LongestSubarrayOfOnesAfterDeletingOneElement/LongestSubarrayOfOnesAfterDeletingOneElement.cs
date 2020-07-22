using System;

namespace LeetCode.LongestSubarrayOfOnesAfterDeletingOneElement
{
    public class Solution
    {
        public int LongestSubarray(int[] nums)
        {
            int left = 0, right = 0, max = 0, count = 0;
            while (right < nums.Length)
            {
                if (nums[right] == 0) count++;
                while (count > 1) if (nums[left++] == 0) count--;
                max = Math.Max(max, right++ - left);
            }
            return max;
        }
    }
}