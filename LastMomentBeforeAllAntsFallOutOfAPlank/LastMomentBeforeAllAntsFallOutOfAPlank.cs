using System;
using System.Linq;

namespace LeetCode.LastMomentBeforeAllAntsFallOutOfAPlank
{
    public class Solution
    {
        public int GetLastMoment(int n, int[] left, int[] right)
        {
            return Math.Max(left.Length == 0 ? 0 : left.Max(), right.Length == 0 ? 0 : n - right.Min());
        }
    }
}