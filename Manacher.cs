using System;

namespace LeetCode
{
    public class Manacher
    {
        private readonly int[] longestPalindromicStrings;
        private int longestPalindromicStringCenter = 0;
        private int longestPalindromicStringLength = 1;
        public Manacher (string text)
        {
            if (text == null || text.Length == 0)
            {
                throw new ArgumentNullException(nameof(text));
            }

            longestPalindromicStrings = new int[text.Length * 2 + 1];
            longestPalindromicStrings[0] = 0;
            longestPalindromicStrings[1] = 1;
            var centerRightPosition = 2;
            var currentCenterPosition = 1;
            for (var i = 2; i < longestPalindromicStrings.Length; i++)
            {
                if (i < centerRightPosition)
                {
                    longestPalindromicStrings[i] = Math.Min(centerRightPosition - i, longestPalindromicStrings[currentCenterPosition * 2 - i]);
                }

                while (i - longestPalindromicStrings[i] > 0 &&
                    i + longestPalindromicStrings[i] + 1 < longestPalindromicStrings.Length &&
                    ((i + longestPalindromicStrings[i] + 1) % 2 == 0 || text[(i + longestPalindromicStrings[i] + 1) / 2] == text[(i - longestPalindromicStrings[i] - 1) / 2]))
                {
                    longestPalindromicStrings[i]++;
                }

                if (longestPalindromicStrings[i] > longestPalindromicStringLength)
                {
                    longestPalindromicStringCenter = i;
                    longestPalindromicStringLength = longestPalindromicStrings[i];
                }

                if (i + longestPalindromicStrings[i] > centerRightPosition)
                {
                    currentCenterPosition = i;
                    centerRightPosition = i + longestPalindromicStrings[i];
                }
            }

            LongestPalindromicString = text.Substring((longestPalindromicStringCenter - longestPalindromicStringLength) / 2, longestPalindromicStringLength);
        }

        public string LongestPalindromicString { get; private set; }

        public int[] LongestPalindromicStrings
        {
            get
            {
                return longestPalindromicStrings;
            }
        }
    }
}