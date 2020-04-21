namespace LeetCode.ReverseInteger
{
    public class Solution
    {
        public int Reverse(int x)
        {
            var reverse = 0;
            while (x != 0)
            {
                var tail = x % 10;
                if ((reverse > int.MaxValue / 10 || (reverse == int.MaxValue / 10 && tail > 7)) ||
                    (reverse < int.MinValue / 10 || (reverse == int.MinValue / 10 && tail < -8)))
                {
                    return 0;
                }

                reverse = reverse * 10 + tail;
                x /= 10;
            }

            return reverse;
        }
    }
}