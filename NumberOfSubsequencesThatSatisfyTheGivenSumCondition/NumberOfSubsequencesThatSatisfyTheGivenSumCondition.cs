using System;

namespace LeetCode.NumberOfSubsequencesThatSatisfyTheGivenSumCondition
{
    public class Solution
    {
        public int NumSubseq(int[] nums, int target)
        {
            Array.Sort(nums);
            int i = 0, j = nums.Length - 1;
            long count = 0;
            while (i <= j)
            {
                while (i <= j && nums[i] + nums[j] > target) j--;
                while (i <= j && nums[i] + nums[j] <= target) count = (count + Pow(j - i++)) % 1000000007;
            }
            return (int)count;
        }

        private static long Pow(int n)
        {
            long pow = 1, x = 2;
            while (n > 0)
            {
                pow = (n & 1) == 0 ? pow : pow * x % 1000000007;
                x = x * x % 1000000007;
                n >>= 1;
            }
            return pow;
        }
    }
}