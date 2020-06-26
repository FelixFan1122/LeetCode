namespace LeetCode.FindMinimumInRotatedSortedArray
{
    public class Solution
    {
        public int FindMin(int[] nums)
        {
            var start = 0;
            var end = nums.Length - 1;
            while (start < end)
            {
                if (nums[start] < nums[end])
                {
                    break;
                }

                var mid = (start + end) / 2;
                if (nums[mid] > nums[end])
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid;
                }
            }

            return nums[start];
        }
    }
}