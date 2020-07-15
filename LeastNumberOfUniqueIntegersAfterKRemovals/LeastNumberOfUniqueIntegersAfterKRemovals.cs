using System.Collections.Generic;

namespace LeetCode.LeastNumberOfUniqueIntegersAfterKRemovals
{
    public class Solution
    {
        public int FindLeastNumOfUniqueInts(int[] arr, int k)
        {
            var frequencies = new Dictionary<int, int>();
            foreach (var num in arr)
            {
                if (!frequencies.ContainsKey(num))
                {
                    frequencies.Add(num, 0);
                }

                frequencies[num] += 1;
            }

            var frequencyCount = new int[arr.Length + 1];
            foreach (var frequency in frequencies.Values)
            {
                frequencyCount[frequency] += 1;
            }

            var i = 1;
            var unique = frequencies.Count;
            while (i < frequencyCount.Length && k > i * frequencyCount[i])
            {
                k -= i * frequencyCount[i];
                unique -= frequencyCount[i++];
            }

            return unique - k / i;
        }
    }
}