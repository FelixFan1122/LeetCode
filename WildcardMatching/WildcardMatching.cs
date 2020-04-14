namespace LeetCode.WildcardMatching
{
    public class Solution
    {
        public bool IsMatch(string s, string p)
        {
            return new NondeterministicFiniteStateAutomata("(" + p.Replace('?', '.').Replace("*", ".*") + ")").Recognize(s);
        }
    }
}