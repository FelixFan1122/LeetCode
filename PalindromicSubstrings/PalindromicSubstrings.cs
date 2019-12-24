using System.Linq;

namespace LeetCode.PalindromicSubstrings
{
    public class Solution
    {
        public int CountSubstrings(string s)
        {
            return new Manacher(s).LongestPalindromicStrings.Sum(l => (l + 1) / 2);
        }
    }
}