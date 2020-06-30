using System.Collections.Generic;

namespace LeetCode.ReverseString
{
    public class Solution
    {
        public string ReverseString(string s)
        {
            return new string(new Stack<char>(s).ToArray());
        }
    }
}