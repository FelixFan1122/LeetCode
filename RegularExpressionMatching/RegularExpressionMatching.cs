namespace LeetCode.RegularExpressionMatching
{
    public class Solution
    {
        public bool IsMatch(string s, string p)
        {
            if (s == null || p == null)
            {
                return false;
            }

            if (p.Length == 0)
            {
                return s.Length == 0;
            }

            return new NondeterministicFiniteStateAutomata("(" + p + ")").Recognize(s);
        }
    }
}