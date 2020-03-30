namespace LeetCode.ReverseBits
{
    public class Solution
    {
        public uint reverseBits(uint n)
        {
            uint reverse = 0;
            for (var i = 0; i < 32; i++)
            {
                reverse <<= 1;
                reverse |= n & 1;
                n >>= 1;
            }

            return reverse;
        }
    }
}