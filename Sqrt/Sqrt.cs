using System;

namespace LeetCode.Sqrt
{
    public class Solution
    {
        public int MySqrt(int x)
        {
            if (x < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (x < 2)
            {
                return x;
            }

            double a = x;
            double b = (a + x / a) / 2.0;
            while (Math.Abs(a - b) >= 1)
            {
                a = b;
                b = (a + x / a) / 2.0;
            }

            return Convert.ToInt32(Math.Floor(b));
        }
    }
}