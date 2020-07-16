using System;

namespace LeetCode.FindTwoNonOverlappingSubArraysEachWithTargetSum
{
    public class Solution
    {
        public int MinSumOfLengths(int[] arr, int target)
        {
            int left = 0, right = 0, sum = 0, min = int.MaxValue, min2 = int.MaxValue;
            var mins = new int[arr.Length];
            Array.Fill(mins, int.MaxValue);
            while (right < arr.Length)
            {
                sum += arr[right];
                while (sum > target)
                {
                    sum -= arr[left++];
                }
                if (sum == target)
                {
                    min = Math.Min(min, right - left + 1);
                    min2 = left == 0 || mins[left - 1] == int.MaxValue ? int.MaxValue : Math.Min(min2, right - left + 1 + mins[left - 1]);
                }
                mins[right++] = min;
            }
            return min2 == int.MaxValue ? -1 : min2;
        }
    }
}