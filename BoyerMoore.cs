using System;

namespace LeetCode
{
    public class BoyerMoore
    {
        private readonly int[] right;
        private readonly string pattern;

        public BoyerMoore(string pattern, int alphabet)
        {
            if (pattern == null || pattern.Length == 0)
            {
                throw new ArgumentException(nameof(pattern));
            }

            if (alphabet <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(alphabet));
            }

            this.pattern = pattern;
            right = new int[alphabet];
            Array.Fill(right, -1);
            for (var i = 0; i < pattern.Length; i++)
            {
                right[pattern[i]] = i;
            }
        }

        public int Search(string text)
        {
            if (text == null)
            {
                return -1;
            }

            int skip;
            for (var i = 0; i <= text.Length - pattern.Length; i += skip)
            {
                var j = pattern.Length - 1;
                while (j >= 0 && text[i + j] == pattern[j])
                {
                    j--;
                }

                if (j < 0)
                {
                    return i;
                }

                skip = j - right[text[i + j]];
                if (skip <= 0)
                {
                    skip = 1;
                }
            }

            return -1;
        }
    }
}