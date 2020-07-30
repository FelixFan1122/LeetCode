using System;

namespace LeetCode.MinimumDifferenceBetweenLargestAndSmallestValueInThreeMoves
{
    public class Solution
    {
        public int MinDifference(int[] nums)
        {
            if (nums.Length < 5) return 0;
            if (nums.Length < 9) Array.Sort(nums);
            else
            {
                QuickSelect(nums, 0, nums.Length - 1, 4);
                QuickSelect(nums, 5, nums.Length - 1, nums.Length - 4);
                Array.Sort(nums, 0, 4);
                Array.Sort(nums, nums.Length - 4, 4);
            }
            var min = int.MaxValue;
            for (var i = 0; i < 4; i++)
            {
                min = Math.Min(min, nums[nums.Length - 4 + i] - nums[i]);
            }
            return min;
        }

        private static void QuickSelect(int[] nums, int left, int right, int k)
        {
            var rand = new Random();
            while (left < right)
            {
                var pivot = rand.Next(left, right);
                pivot = Partition(nums, left, right, pivot);
                if (pivot < k) left = pivot + 1;
                else if (pivot == k) return;
                else right = pivot - 1;
            }
        }

        private static int Partition(int[] nums, int left, int right, int pivotIndex)
        {
            var pivotValue = nums[pivotIndex];
            Swap(nums, pivotIndex, right);
            var storeIndex = left;
            for (var i = left; i < right; i++) if (nums[i] < pivotValue) Swap(nums, i, storeIndex++);
            Swap(nums, storeIndex, right);
            return storeIndex;
        }

        private static void Swap(int[] nums, int i, int j)
        {
            var temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
}