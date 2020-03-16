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

            for (var i = 0; i <= haystack.Length - needle.Length; i++)
            {
                var j = 0;
                while (j < needle.Length && haystack[i + j] == needle[j])
                {
                    j++;
                }

                if (j == needle.Length)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}