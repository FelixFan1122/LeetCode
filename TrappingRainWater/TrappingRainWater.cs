namespace LeetCode.TrappingRainWater
{
    public class Solution
    {
        public int Trap(int[] height)
        {
            if (height == null)
            {
                return 0;
            }

            var left = 0;
            var right = height.Length - 1;
            var leftMax = 0;
            var rightMax = 0;
            var water = 0;
            while (left < right)
            {
                if (height[left] < height[right])
                {
                    if (leftMax < height[left])
                    {
                        leftMax = height[left];
                    }
                    else
                    {
                        water += leftMax - height[left];
                    }

                    left++;
                }
                else
                {
                    if (rightMax < height[right])
                    {
                        rightMax = height[right];
                    }
                    else
                    {
                        water += rightMax - height[right];
                    }

                    right--;
                }
            }

            return water;
        }
    }
}