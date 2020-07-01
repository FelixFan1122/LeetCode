using System;
using System.Collections.Generic;

namespace LeetCode.DecodeString
{
    public class Solution
    {
        private const char Opening = '[';
        private const char Closing = ']';
        public string DecodeString(string s)
        {
            if (s == null)
            {
                return "";
            }

            var i = 0;
            var decoded = "";
            var encoded = new Stack<string>();
            var times = new Stack<int>();
            while (i < s.Length)
            {
                if (s[i] == Opening)
                {
                    encoded.Push(decoded);
                    decoded = "";
                    i++;
                }
                else if (s[i] == Closing)
                {
                    var prefix = encoded.Pop();
                    var time = times.Pop();
                    for (var j = 0; j < time; j++)
                    {
                        prefix += decoded;
                    }

                    decoded = prefix;
                    i++;
                }
                else if (Char.IsDigit(s, i))
                {
                    var time = s[i++] - '0';
                    while (Char.IsDigit(s, i))
                    {
                        time = time * 10 + s[i++] - '0';
                    }

                    times.Push(time);
                }
                else
                {
                    decoded += s[i++];
                }
            }

            return decoded;
        }
    }
}