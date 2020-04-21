using System.Collections.Generic;

namespace LeetCode.FourSumII
{
    public class Solution
    {
        public int FourSumCount(int[] A, int[] B, int[] C, int[] D)
        {
            var twoSums = new Dictionary<int, int>();
            foreach (var a in A)
            {
                foreach (var b in B)
                {
                    if (!twoSums.ContainsKey(a + b))
                    {
                        twoSums[a + b] = 0;
                    }

                    twoSums[a + b] += 1;
                }
            }

            var count = 0;
            foreach (var c in C)
            {
                foreach (var d in D)
                {
                    if (twoSums.ContainsKey(-c - d))
                    {
                        count += twoSums[-c - d];
                    }
                }
            }

            return count;
        }
    }
}