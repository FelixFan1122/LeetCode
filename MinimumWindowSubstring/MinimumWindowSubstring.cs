using System.Collections.Generic;

namespace LeetCode.MinimumWindowSubstring
{
    public class Solution
    {
        public string MinWindow(string s, string t)
        {
            if (s == null || t == null || t.Length == 0 || s.Length < t.Length)
            {
                return string.Empty;
            }

            var target = GenerateDictionary(t);

            var window = InitializeCounter(target);
            var count = 0;
            var minLeft = -1;
            var min = s.Length;
            var left = 0;
            var right = 0;
            while (right < s.Length)
            {
                if (target.ContainsKey(s[right]))
                {
                    window[s[right]]++;
                    if (window[s[right]] == target[s[right]])
                    {
                        count++;
                        if (count == target.Count)
                        {
                            while (count == target.Count)
                            {
                                if (window.ContainsKey(s[left]))
                                {
                                    if (window[s[left]] == target[s[left]])
                                    {
                                        count--;
                                    }

                                    window[s[left]]--;
                                }

                                left++;
                            }

                            if (right - left + 2 <= min)
                            {
                                min = right - left + 2;
                                minLeft = left - 1;
                            }
                        }
                    }
                }

                right++;
            }

            return minLeft < 0 ? string.Empty : s.Substring(minLeft, min);
        }

        private static Dictionary<char, int> GenerateDictionary(string target)
        {
            var dictionary = new Dictionary<char, int>();
            foreach (var character in target)
            {
                if (!dictionary.ContainsKey(character))
                {
                    dictionary[character] = 0;
                }

                dictionary[character]++;
            }

            return dictionary;
        }

        private static Dictionary<TKey, int> InitializeCounter<TKey>(Dictionary<TKey, int> source)
        {
            var counter = new Dictionary<TKey, int>(source.Count);
            foreach (var key in source.Keys)
            {
                counter[key] = 0;
            }

            return counter;
        }
    }
}