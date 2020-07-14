using System.Collections.Generic;

namespace LeetCode.NextGreaterElementII
{
    public class Solution
    {
        public int[] NextGreaterElements(int[] nums)
        {
            var candidates = new Stack<int>();
            var nextGreater = new int[nums.Length];
            for (var i = nums.Length * 2 - 1; i >= 0; i--)
            {
                while (candidates.Count > 0 && nums[candidates.Peek()] <= nums[i % nums.Length]) candidates.Pop();
                nextGreater[i % nums.Length] = candidates.Count == 0 ? -1 : nums[candidates.Peek()];
                candidates.Push(i % nums.Length);
            }

            return nextGreater;
        }
    }
}