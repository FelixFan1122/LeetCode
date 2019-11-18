using System.Collections.Generic;

namespace SubarraySumEqualsK
{
    public class Solution
    {
        public int SubarraySum(int[] nums, int k)
        {
            if (nums == null)
            {
                return 0;
            }

            var count = 0;
            var sum = 0;
            var sums = new Dictionary<int, int>();
            sums.Add(0, 1);
            foreach (var num in nums)
            {
                sum += num;
                if (sums.ContainsKey(sum - k))
                {
                    count += sums[sum - k];
                }

                if (!sums.ContainsKey(sum))
                {
                    sums.Add(sum, 0);
                }

                sums[sum]++;
            }

            return count;
        }
    }
}