namespace LeetCode.Pow
{
    public class Solution
    {
        public double MyPow(double x, int n)
        {
            var compensation = n == int.MinValue ? 1 / x : 1;
            if (n < 0)
            {
                x = 1 / x;
                n = n == int.MinValue ? int.MaxValue : -n;
            }

            double power = 1;
            while (n > 0)
            {
                if ((n & 1) > 0)
                {
                    power *= x;
                }

                x *= x;
                n /= 2;
            }

            return power * compensation;
        }
    }
}