using System.Collections.Generic;

namespace LeetCode
{
    public static class Solution
    {
        public static string ReverseString(string s) => new string(new Stack<char>(s).ToArray());
    }
}