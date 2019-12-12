namespace FindFirstAndLastPositionOfElementInSortedArray
{
    public class Solution
    {
        public int[] SearchRange(int[] nums, int target)
        {
            return new[] { FindIndex(nums, target, false), FindIndex(nums, target, true) };
        }

        public int FindIndex(int[] nums, int target, bool isLast)
        {
            if (nums == null || nums.Length == 0)
            {
                return -1;
            }

            var low = 0;
            var high = nums.Length - 1;
            while (low <= high)
            {
                var mid = (low + high) / 2;
                if (nums[mid] == target)
                {
                    if (isLast)
                    {
                        if (mid == nums.Length - 1 || nums[mid + 1] != target)
                        {
                            return mid;
                        }

                        low = mid + 1;
                    }
                    else
                    {
                        if (mid == 0 || nums[mid - 1] != target)
                        {
                            return mid;
                        }

                        high = mid - 1;
                    }
                }
                else if (nums[mid] > target)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return -1;
        }
    }
}