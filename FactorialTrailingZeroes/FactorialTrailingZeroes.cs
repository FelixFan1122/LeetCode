namespace LeetCode.FactorialTrailingZeroes
{
    public class Solution
    {
        public int TrailingZeroes(int n)
        {
            var count = 0;
            while (n > 0)
            {
                count += n / 5;
                n /= 5;
            }

            return count;
        }
    }
}