using System.Collections.Generic;

namespace LeetCode.LongestConsecutiveSequence
{
    public class Solution
    {
        public int LongestConsecutive(int[] nums)
        {
            if (nums == null)
            {
                return 0;
            }

            var numSet = new HashSet<int>();
            foreach (var num in nums)
            {
                numSet.Add(num);
            }

            var longest = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                if (numSet.Contains(nums[i] - 1))
                {
                    continue;
                }

                var length = 1;
                while (numSet.Contains(nums[i] + length))
                {
                    length++;
                }

                if (longest < length)
                {
                    longest = length;
                }
            }

            return longest;
        }
    }
}