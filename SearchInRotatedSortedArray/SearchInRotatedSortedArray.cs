namespace LeetCode.SearchInRotatedSortedArray
{
    public class Solution
    {
        public int Search(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
            {
                return -1;
            }

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

            if (target > nums[nums.Length - 1])
            {
                end = start - 1;
                start = 0;
            }
            else
            {
                end = nums.Length - 1;
            }

            while (start <= end)
            {
                var mid = (start + end) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (nums[mid] < target)
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }

            return -1;
        }
    }
}