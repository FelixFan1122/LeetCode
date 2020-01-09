namespace LeetCode.MergeSortedArray
{
    public class Solution
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            if (m < 0 || n <= 0)
            {
                return;
            }

            m--;
            n--;
            var tail = m + n + 1;
            while (n >= 0)
            {
                if (m < 0 || nums1[m] <= nums2[n])
                {
                    nums1[tail--] = nums2[n--];
                }
                else
                {
                    nums1[tail--] = nums1[m--];
                }
            }
        }
    }
}