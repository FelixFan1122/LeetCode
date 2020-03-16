using System;

namespace LeetCode
{
    public static class SubstringSearchBruteForce
    {
        public static int Search(string haystack, string needle)
        {
            if (haystack == null)
            {
                throw new ArgumentNullException(nameof(haystack));
            }

            if (needle == null)
            {
                throw new ArgumentNullException(nameof(needle));
            }

            if (needle.Length == 0)
            {
                return 0;
            }

            var i = 0;
            var j = 0;
            while (i < haystack.Length && j < needle.Length)
            {
                if (haystack[i] == needle[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    i = i - j + 1;
                    j = 0;
                }
            }

            return j == needle.Length ? i - j : -1;
        }
    }
}