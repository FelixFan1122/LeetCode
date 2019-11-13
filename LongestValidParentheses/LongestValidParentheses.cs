using System;

namespace LongestValidParentheses
{
    public class Solution
    {
        private const char Opening = '(';
        private const char Closing = ')';
        public int LongestValidParentheses(string s)
        {
            if (s == null)
            {
                return 0;
            }

            var opening = 0;
            var closing = 0;
            var max = 0;
            foreach (var parenthesis in s)
            {
                if (parenthesis == Opening)
                {
                    opening++;
                }
                else
                {
                    if (opening == closing)
                    {
                        opening = 0;
                        closing = 0;
                    }
                    else
                    {
                        closing++;
                        if (opening == closing)
                        {
                            max = Math.Max(max, opening + closing);
                        }
                    }
                }
            }

            opening = 0;
            closing = 0;
            for (var i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == Closing)
                {
                    closing++;
                }
                else
                {
                    if (opening == closing)
                    {
                        opening = 0;
                        closing = 0;
                    }
                    else
                    {
                        opening++;
                        if (opening == closing)
                        {
                            max = Math.Max(max, opening + closing);
                        }
                    }
                }
            }

            return max;
        }
    }
}