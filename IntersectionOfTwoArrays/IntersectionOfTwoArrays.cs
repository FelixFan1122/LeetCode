using System.Collections.Generic;

namespace LeetCode.IntersectionOfTwoArrays
{
    public class Solution
    {
        public int[] Intersection(int[] nums1, int[] nums2)
        {
            if (nums1 == null || nums2 == null)
            {
                return new int[0];
            }

            var set = new HashSet<int>(nums1);
            var intersection = new List<int>();
            foreach (var num in nums2)
            {
                if (set.Contains(num))
                {
                    intersection.Add(num);
                    set.Remove(num);
                }
            }

            return intersection.ToArray();
        }
    }
}