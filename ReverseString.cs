using System.Collections.Generic;

public static class Solution {
    public static string ReverseString(string s) => new string(new Stack<char>(s).ToArray());
}