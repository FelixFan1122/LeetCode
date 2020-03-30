using System.Linq;

namespace LeetCode.FirstUniqueCharacterInAString
{
    public class Solution
    {
        public int FirstUniqChar(string s)
        {
            if (s == null)
            {
                return -1;
            }

            var firstAppearances = new int[26];
            for (var i = 0; i < firstAppearances.Length; i++)
            {
                firstAppearances[i] = s.Length;
            }

            for (var i = 0; i < s.Length; i++)
            {
                var character = s[i] - 'a';
                if (firstAppearances[character] == s.Length)
                {
                    firstAppearances[character] = i;
                }
                else
                {
                    firstAppearances[character] = s.Length + 1;
                }
            }

            var first = firstAppearances.Min();
            return first < s.Length ? first : -1;
        }
    }
}