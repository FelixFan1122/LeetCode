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

            var frequencies = new int[26];
            foreach (var character in s)
            {
                frequencies[character - 'a']++;
            }

            for (var i = 0; i < s.Length; i++)
            {
                if (frequencies[s[i] - 'a'] == 1)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}