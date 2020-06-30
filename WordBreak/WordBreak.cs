using System.Collections.Generic;

namespace LeetCode.WordBreak
{
    public class Solution
    {
        private const char Separator = ' ';
        public bool WordBreak(string s, IList<string> wordDict)
        {
            return new WordBreakII.Solution().WordBreak(s, wordDict).Count > 0;
        }
    }
}