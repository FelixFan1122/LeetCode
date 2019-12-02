namespace FindPeakElement
{
    public class Solution
    {
        public int FindPeakElement(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return -1;
            }

            var left = 0;
            var right = nums.Length - 1;
            while (left < right)
            {
                var mid = (left + right) / 2;
                if (nums[mid] < nums[mid + 1])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return left;
        }
    }
}