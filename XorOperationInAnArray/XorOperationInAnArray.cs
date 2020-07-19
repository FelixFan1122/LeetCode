namespace LeetCode.XorOperationInAnArray
{
    public class Solution
    {
        public int XorOperation(int n, int start)
        {
            var newStart = start >> 1;
            int newXor;
            if ((newStart & 1) == 0)
            {
                newXor = n >> 1 & 1;
                if ((n & 1) != 0)
                {
                    newXor ^= newStart + n - 1;
                }
            }
            else
            {
                newXor = (n & 1) == 0 ? newStart ^ ((n >> 1) - 1 & 1) ^ (newStart + n - 1) : newStart ^ (n >> 1 & 1);
            }

            return (newXor << 1) + (1 & n & start);
        }
    }
}