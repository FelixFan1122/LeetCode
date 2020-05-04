using System.Collections.Generic;

namespace LeetCode.TopKFrequentElements
{
    public class Solution
    {
        public IList<int> TopKFrequent(int[] nums, int k)
        {
            var topKFrequent = new List<int>();
            if (nums == null)
            {
                return topKFrequent;
            }

            var frequencies = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (!frequencies.ContainsKey(num))
                {
                    frequencies[num] = 0;
                }

                frequencies[num] += 1;
            }

            var frequencyBuckets = new List<int>[nums.Length + 1];
            foreach (var numFrequency in frequencies)
            {
                if (frequencyBuckets[numFrequency.Value] == null)
                {
                    frequencyBuckets[numFrequency.Value] = new List<int>();
                }

                frequencyBuckets[numFrequency.Value].Add(numFrequency.Key);
            }

            for (var i = frequencyBuckets.Length - 1; i >= 0; i--)
            {
                if (frequencyBuckets[i] == null)
                {
                    continue;
                }

                foreach (var num in frequencyBuckets[i])
                {
                    topKFrequent.Add(num);
                    if (topKFrequent.Count == k)
                    {
                        return topKFrequent;
                    }
                }
            }

            return topKFrequent;
        }
    }
}