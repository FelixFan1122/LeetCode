using System;

namespace LeetCode.TheKthFactorOfN
{
    public class Solution
    {
        public int KthFactor(int n, int k)
        {
            var i = 1;
            for (; i <= Math.Sqrt(n); i++) if (n % i == 0 && --k == 0) return i;
            for (i = i - 1 == Math.Sqrt(n) ? i - 2 : i - 1; i >= 1; i--) if (n % i == 0 && --k == 0) return n / i;
            return -1;
        }
    }
}