namespace LeetCode.WiggleSortII
{
    public class Solution
    {
        public void WiggleSort(int[] nums)
        {
            var median = new KthLargestElementInAnArray.Solution()
                .FindKthLargest(nums, (nums.Length + 1) / 2);

            var nextSmaller = nums.Length - 1;
            var current = 0;
            var nextBigger = 0;
            while (current <= nextSmaller)
            {
                var currentMapped = (current * 2 + 1) % (nums.Length | 1);
                if (nums[currentMapped] < median)
                {
                    var nextSmallerMapped = (nextSmaller * 2 + 1) % (nums.Length | 1);
                    var temp = nums[currentMapped];
                    nums[currentMapped] = nums[nextSmallerMapped];
                    nums[nextSmallerMapped] = temp;
                    nextSmaller--;
                }
                else if (nums[currentMapped] == median)
                {
                    current++;
                }
                else
                {
                    var nextBiggerMapped = (nextBigger * 2 + 1) % (nums.Length | 1);
                    var temp = nums[currentMapped];
                    nums[currentMapped] = nums[nextBiggerMapped];
                    nums[nextBiggerMapped] = temp;
                    nextBigger++;
                    current++;
                }
            }
        }
    }
}