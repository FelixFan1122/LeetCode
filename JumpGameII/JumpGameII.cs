using System;

namespace JumpGameII
{
    public class Solution
    {
        public int Jump(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return -1;
            }

            if (nums.Length == 1)
            {
                return 0;
            }

            var jumps = 0;
            var left = 0;
            var right = 0;
            while (right < nums.Length - 1)
            {
                var max = right;
                for (var i = left; i <= right; i++)
                {
                    max = Math.Max(max, i + nums[i]);
                }

                if (max == right)
                {
                    return -1;
                }

                jumps++;
                left = right + 1;
                right = max;
            }

            return jumps;
        }
    }
}