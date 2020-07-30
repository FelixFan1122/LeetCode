using System.Collections.Generic;

namespace LeetCode.NumberOfGoodPairs
{
    public class Solution
    {
        public int NumIdenticalPairs(int[] nums)
        {
            var count = new Dictionary<int, int>();
            for (var i = 0; i < nums.Length; i++)
            {
                if (!count.ContainsKey(nums[i])) count.Add(nums[i], 0);
                count[nums[i]]++;
            }
            var pairs = 0;
            foreach (var num in count.Values) pairs += num * (num - 1) / 2;
            return pairs;
        }
    }
}