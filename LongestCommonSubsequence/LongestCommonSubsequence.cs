using System;

namespace LongestCommonSubsequence
{
    public class Solution
    {
        public int LongestCommonSubsequence(string text1, string text2)
        {
            if (string.IsNullOrEmpty(text1) || string.IsNullOrEmpty(text2))
            {
                return 0;
            }

            var shorter = text1.Length < text2.Length ? text1 : text2;
            var longer = text1.Length < text2.Length ? text2 : text1;
            var lcs = new int[2, shorter.Length];
            for (var i = 0; i < shorter.Length; i++)
            {
                lcs[0, i] = shorter[i] == longer[0] ? 1 : (i == 0 ? 0 : lcs[0, i - 1]);
            }

            for (var i = 1; i < longer.Length; i++)
            {
                lcs[i % 2, 0] = longer[i] == shorter[0] ? 1 : lcs[(i - 1) % 2, 0];
                for (var j = 1; j < shorter.Length; j++)
                {
                    lcs[i % 2, j] = longer[i] == shorter[j] ? lcs[(i - 1) % 2, j - 1] + 1 : Math.Max(lcs[(i - 1) % 2, j], lcs[i % 2, j - 1]);
                }
            }

            return lcs[(longer.Length - 1) % 2, shorter.Length - 1];
        }
    }
}