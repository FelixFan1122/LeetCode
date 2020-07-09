using System;

namespace LeetCode.ClimbingStairs
{
    public class Solution
    {
        public int ClimbStairs(int n)
        {
            return (int)((Math.Pow(1 + Math.Sqrt(5), n + 1) - Math.Pow(1 - Math.Sqrt(5), n + 1)) / (Math.Pow(2, n + 1) * Math.Sqrt(5)));
        }
    }
}