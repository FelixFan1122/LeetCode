using System.Collections.Generic;

namespace LeetCode.NextGreaterElementI
{
    public class Solution
    {
        public int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            var previous = new Stack<int>();
            var nextGreaterElements2 = new Dictionary<int, int>();
            foreach (var num in nums2)
            {
                while (previous.Count > 0 && previous.Peek() < num)
                {
                    nextGreaterElements2.Add(previous.Pop(), num);
                }

                previous.Push(num);
            }

            var nextGreaterElements1 = new int[nums1.Length];
            for (var i = 0; i < nums1.Length; i++)
            {
                nextGreaterElements1[i] = nextGreaterElements2.ContainsKey(nums1[i]) ? nextGreaterElements2[nums1[i]] : -1;
            }

            return nextGreaterElements1;
        }
    }
}