namespace LeetCode.KthLargestElementInAnArray
{
    public class Solution
    {
        public int FindKthLargest(int[] nums, int k)
        {
            return QuickSelect.QuickSelect.Select(nums, 0, nums.Length - 1, nums.Length - k + 1);
        }
    }
}