namespace LeetCode.CountBits
{
    public class Solution {
        public int[] CountBits(int num) {
            if (num == 0)
            {
                return new[] { 0 };
            }

            if (num == 1)
            {
                return new[] { 0, 1 };
            }

            var bitCounts = new int[num + 1];
            bitCounts[0] = 0;
            bitCounts[1] = 1;
            int i = 2;
            while (i <= bitCounts.Length / 2)
            {
                var original = i;
                for (var j = 0; j < original; i++, j++)
                {
                    bitCounts[i] = bitCounts[j] + 1;
                }
            }

            for (var k = 0; i < bitCounts.Length; i++, k++)
            {
                bitCounts[i] = bitCounts[k] + 1;
            }

            return bitCounts;
        }
    }
}