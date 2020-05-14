using System;

namespace LeetCode.ValidPalindrome
{
    public class Solution
    {
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