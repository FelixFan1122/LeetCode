namespace PlusOne
{
    public class Solution
    {
        public int[] PlusOne(int[] digits)
        {
            var carry = 1;
            var sum = new int[digits.Length];
            for (var i = digits.Length - 1; i >= 0; i--)
            {
                sum[i] = (digits[i] + carry) % 10;
                carry = (digits[i] + carry) / 10;
            }

            if (carry > 0)
            {
                sum = new int[digits.Length + 1];
                sum[0] = 1;
                for (var i = 1; i < sum.Length; i++)
                {
                    sum[i] = 0;
                }
            }

            return sum;
        }
    }
}