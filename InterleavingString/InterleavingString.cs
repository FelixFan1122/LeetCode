using System;

namespace LeetCode.InterleavingString
{
    public class Solution
    {
        public bool IsInterleave(string s1, string s2, string s3)
        {
            if (s3 == null)
            {
                throw new ArgumentNullException(nameof(s3));
            }

            if (s1 == null)
            {
                if (s2 == null)
                {
                    throw new ArgumentException();
                }
                else
                {
                    return s2 == s3;
                }
            }

            if (s2 == null)
            {
                return s1 == s3;
            }

            if (s1.Length + s2.Length != s3.Length)
            {
                return false;
            }

            if (s1.Length > s2.Length)
            {
                var temp = s1;
                s1 = s2;
                s2 = temp;
            }

            if (s1.Length == 0)
            {
                return s2 == s3;
            }

            var dp = new bool[s1.Length + 1];
            dp[0] = true;
            for (var i = 1; i <= s1.Length; i++)
            {
                dp[i] = dp[i - 1] && s1[i - 1] == s3[i - 1];
            }

            for (var i = 1; i <= s2.Length; i++)
            {
                dp[0] = dp[0] && s2[i - 1] == s3[i - 1];
                for (var j = 1; j <= s1.Length; j++)
                {
                    dp[j] = (dp[j - 1] && s1[j - 1] == s3[i + j - 1]) || (dp[j] && s2[i - 1] == s3[i + j - 1]);
                }
            }

            return dp[dp.Length - 1];
        }
    }
}