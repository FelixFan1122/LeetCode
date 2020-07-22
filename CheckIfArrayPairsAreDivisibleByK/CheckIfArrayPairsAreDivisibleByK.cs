using System.Collections.Generic;

namespace LeetCode.CheckIfArrayPairsAreDivisibleByK
{
    public class Solution
    {
        public bool CanArrange(int[] arr, int k)
        {
            var remainders = new Dictionary<int, int>();
            for (var i = 0; i < arr.Length; i++)
            {
                var remainder = ((arr[i] % k) + k) % k;
                if (!remainders.ContainsKey(remainder)) remainders.Add(remainder, 0);
                remainders[remainder]++;
            }
            for (var i = 1; i < k; i++)
            {
                if (remainders.ContainsKey(i) && !remainders.ContainsKey(k - i) ||
                    !remainders.ContainsKey(i) && remainders.ContainsKey(k - i) ||
                    remainders.ContainsKey(i) && remainders.ContainsKey(k - i) && remainders[i] != remainders[k - i]) return false;
            }
            return (!remainders.ContainsKey(0) || remainders[0] % 2 == 0) &&
                (k % 2 != 0 || !remainders.ContainsKey(k / 2) || remainders[k / 2] % 2 == 0);
        }
    }
}