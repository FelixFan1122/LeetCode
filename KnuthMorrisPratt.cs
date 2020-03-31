using System;

namespace LeetCode
{
    public class KnuthMorrisPratt
    {
        private int[,] dfa;

        public KnuthMorrisPratt(string pattern, int alphabet)
        {
            if (pattern == null || pattern.Length == 0)
            {
                throw new ArgumentException(nameof(pattern));
            }

            if (alphabet <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(alphabet));
            }

            dfa = new int[alphabet, pattern.Length];
            dfa[(int)pattern[0], 0] = 1;
            var restart = 0;
            for (var i = 1; i < pattern.Length; i++)
            {
                var character = (int)pattern[i];
                for (var j = 0; j < alphabet; j++)
                {
                    dfa[j, i] = dfa[j, restart];
                }

                dfa[character, i] = i + 1;
                restart = dfa[character, restart];
            }
        }

        public int Search(string text)
        {
            if (text == null)
            {
                return -1;
            }

            var patternLength = dfa.GetLength(1);

            var i = 0;
            var j = 0;
            while (i < text.Length && j < patternLength)
            {
                j = dfa[(int)text[i], j];
                i++;
            }

            return j == patternLength ? i - patternLength : -1;
        }
    }
}