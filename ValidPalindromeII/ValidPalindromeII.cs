using System;

namespace LeetCode.ValidPalindromeII
{
    public class Solution
    {
        public bool ValidPalindrome(string s)
        {
            if (s == null || s.Length == 0)
            {
                return false;
            }

            var start = 0;
            var end = s.Length - 1;
            while (start < end)
            {
                if (s[start] != s[end])
                {
                    return IsPalindrome(s.Substring(start, end - start)) || IsPalindrome(s.Substring(start + 1, end - start));
                }

                start++;
                end--;
            }

            return true;
        }

        public bool IsPalindrome(string s)
        {
            if (s == null)
            {
                return false;
            }

            var start = 0;
            var end = s.Length - 1;
            while (start < end)
            {
                while (start < end && !Char.IsLetterOrDigit(s[start]))
                {
                    start++;
                }

                while (start < end && !Char.IsLetterOrDigit(s[end]))
                {
                    end--;
                }

                if (start < end && Char.ToLower(s[start]) != Char.ToLower(s[end]))
                {
                    return false;
                }

                start++;
                end--;
            }

            return true;
        }
    }
}