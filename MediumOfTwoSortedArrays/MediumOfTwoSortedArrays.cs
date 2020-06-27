using System;

namespace LeetCode.MediumOfTwoSortedArrays
{
    public class Solution
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            if (nums1 == null)
            {
                throw new ArgumentNullException(nameof(nums1));
            }

            if (nums2 == null)
            {
                throw new ArgumentNullException(nameof(nums2));
            }

            if (nums1.Length == 0 && nums2.Length == 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            int[] smaller = nums1;
            int[] bigger = nums2;
            if (nums1.Length > nums2.Length)
            {
                smaller = nums2;
                bigger = nums1;
            }

            var start = 0;
            var end = smaller.Length;
            while (start <= end)
            {
                var i = (start + end) / 2;
                var j = (smaller.Length + bigger.Length + 1) / 2 - i;
                if (i < smaller.Length && smaller[i] < bigger[j - 1])
                {
                    start = i + 1;
                }
                else if (i > 0 && smaller[i - 1] > bigger[j])
                {
                    end = i - 1;
                }
                else
                {
                    var maxLeft = Math.Max(i == 0 ? int.MinValue : smaller[i - 1], j == 0 ? int.MinValue : bigger[j - 1]);
                    if ((smaller.Length + bigger.Length) % 2 == 1)
                    {
                        return maxLeft;
                    }

                    var minRight = Math.Min(i == smaller.Length ? int.MaxValue : smaller[i], j == bigger.Length ? int.MaxValue : bigger[j]);
                    return (maxLeft + minRight) / 2.0;
                }
            }

            throw new Exception("Unreachable code.");
        }
    }
}