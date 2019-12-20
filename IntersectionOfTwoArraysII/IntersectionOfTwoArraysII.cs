using System.Collections.Generic;

namespace LeetCode.IntersectionOfTwoArraysII
{
    public class Solution
    {
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            if (nums1 == null || nums2 == null)
            {
                return new int[0];
            }

            var counter = new Dictionary<int, int>();
            foreach (var num in nums1)
            {
                if (!counter.ContainsKey(num))
                {
                    counter[num] = 0;
                }

                counter[num]++;
            }

            var intersection = new List<int>();
            foreach (var num in nums2)
            {
                if (counter.ContainsKey(num) && counter[num] > 0)
                {
                    intersection.Add(num);
                    counter[num]--;
                }
            }

            return intersection.ToArray();
        }
    }
}