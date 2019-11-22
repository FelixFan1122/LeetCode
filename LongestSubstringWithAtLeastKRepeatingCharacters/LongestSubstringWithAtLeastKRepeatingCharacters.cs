using System;
using System.Collections.Generic;

namespace LongestSubstringWithAtLeastKRepeatingCharacters
{
    public class Solution
    {
        public int LongestSubstring(string s, int k)
        {
            if (s == null)
            {
                return 0;
            }

            var counters = new List<int>[26];
            for (var i = 0; i < s.Length; i++)
            {
                var offset = s[i] - 'a';
                if (counters[offset] == null)
                {
                    counters[offset] = new List<int>();
                }

                counters[offset].Add(i);
            }

            return LongestSubstring(counters, k, 0, s.Length);
        }

        private int LongestSubstring(List<int>[] counters, int k, int start, int end)
        {
            if (end - start < k)
            {
                return 0;
            }

            var violatingChars = new List<int>();
            foreach (var counter in counters)
            {
                if (counter != null)
                {
                    var first = counter.BinarySearch(start);
                    if (first < 0)
                    {
                        first = ~first;
                    }

                    var last = counter.BinarySearch(end);
                    if (last < 0)
                    {
                        last = ~last;
                    }

                    if (last - first > 0 && last - first < k)
                    {
                        for (var i = first; i < last; i++)
                        {
                            violatingChars.Add(counter[i]);
                        }
                    }
                }
            }

            if (violatingChars.Count == 0)
            {
                return end - start;
            }
            else
            {
                violatingChars.Sort();
                if (violatingChars[0] > start)
                {
                    violatingChars.Insert(0, start - 1);
                }

                if (violatingChars[violatingChars.Count - 1] < end)
                {
                    violatingChars.Add(end);
                }

                var max = 0;
                for (var i = 1; i < violatingChars.Count; i++)
                {
                    max = Math.Max(max, LongestSubstring(counters, k, violatingChars[i - 1] + 1, violatingChars[i]));
                }

                return max;
            }
        }
    }
}