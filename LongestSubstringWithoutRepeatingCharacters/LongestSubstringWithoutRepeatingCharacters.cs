using System.Collections.Generic;

namespace LeetCode.LongestSubstringWithoutRepeatingCharacters
{
    public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            if (s == null)
            {
                return 0;
            }

            var max = 0;
            var left = 0;
            var right = 0;
            var window = new Dictionary<char, int>();
            while (right < s.Length)
            {
                if (window.ContainsKey(s[right]))
                {
                    var duplicate = window[s[right]];
                    while (left <= duplicate)
                    {
                        window.Remove(s[left]);
                        left++;
                    }
                }
                else
                {
                    window[s[right]] = right;
                    if (max < right - left + 1)
                    {
                        max = right - left + 1;
                    }

                    right++;
                }
            }

            return max;
        }
    }
}