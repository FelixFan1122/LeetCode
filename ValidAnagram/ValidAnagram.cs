using System.Collections.Generic;

namespace LeetCode.ValidAnagram
{
    public class Solution
    {
        public bool IsAnagram(string s, string t)
        {
            if (s == null || t == null)
            {
                return false;
            }

            var dict = new Dictionary<char, int>();
            foreach (var character in s)
            {
                if (!dict.ContainsKey(character))
                {
                    dict[character] = 0;
                }

                dict[character]++;
            }

            foreach (var character in t)
            {
                if (!dict.ContainsKey(character) || dict[character] == 0)
                {
                    return false;
                }

                dict[character]--;
            }

            foreach (var remaining in dict.Values)
            {
                if (remaining > 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}