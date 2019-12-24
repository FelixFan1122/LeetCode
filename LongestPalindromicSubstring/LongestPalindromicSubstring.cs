namespace LeetCode.LongestPalindromicSubstring
{
    public class Solution
    {
        public string LongestPalindrome(string s)
        {
            if (s == null || s.Length == 0)
            {
                return "";
            }

            return new Manacher(s).LongestPalindromicString;
        }
    }
}