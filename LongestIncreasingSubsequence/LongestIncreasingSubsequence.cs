using System.Collections.Generic;

namespace LeetCode.LongestIncreasingSubsequence
{
    public class Solution
    {
        public int LengthOfLIS(int[] nums)
        {
            if (nums == null)
            {
                return 0;
            }

            var tails = new List<int>();
            foreach (var num in nums)
            {
                var index = tails.BinarySearch(num);
                if (index < 0)
                {
                    index = ~index;
                    if (index == tails.Count)
                    {
                        tails.Add(num);
                    }
                    else
                    {
                        tails[index] = num;
                    }
                }
            }

            return tails.Count;
        }
    }
}