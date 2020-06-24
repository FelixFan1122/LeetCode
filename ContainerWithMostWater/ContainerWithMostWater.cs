using System;

namespace LeetCode.ContainerWithMostWater
{
    public class Solution
    {
        public int MaxArea(int[] height)
        {
            if (height == null || height.Length < 2)
            {
                return 0;
            }

            var left = 0;
            var right = height.Length - 1;
            var max = 0;
            while (left < right)
            {
                var area = Math.Min(height[left], height[right]) * (right - left);
                if (area > max)
                {
                    max = area;
                }

                if (height[left] < height[right])
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            return max;
        }
    }
}