using System;
using System.Collections.Generic;

namespace RemoveInvalidParentheses
{
    public class Solution
    {
        private static readonly Tuple<char, char> leftToRight = new Tuple<char, char>('(', ')');
        private static readonly Tuple<char, char> rightToLeft = new Tuple<char, char>(')', '(');
        public IList<string> RemoveInvalidParentheses(string s)
        {
            var valid = new List<string>();
            RemoveInvalidParentheses(s, valid, 0, 0, leftToRight);
            return valid;
        }

        private void RemoveInvalidParentheses(string s, IList<string> valid, int current, int start, Tuple<char, char> parentheses)
        {
            if (current >= s.Length)
            {
                var reverse = s.ToCharArray();
                Array.Reverse(reverse);
                if (parentheses == leftToRight)
                {
                    RemoveInvalidParentheses(new string(reverse), valid, 0, 0, rightToLeft);
                }
                else
                {
                    valid.Add(new string(reverse));
                }
            }
            else
            {
                var count = 0;
                var i = current;
                while (i < s.Length)
                {
                    if (s[i] == parentheses.Item1)
                    {
                        count++;
                    }
                    else if (s[i] == parentheses.Item2)
                    {
                        if (count == 0)
                        {
                            break;
                        }
                        else
                        {
                            count--;
                        }
                    }

                    i++;
                }

                if (i < s.Length)
                {
                    var candidates = new List<int>();
                    for (var j = start; j <= i; j++)
                    {
                        if (s[j] == parentheses.Item2 && (j == start || s[j - 1] != parentheses.Item2))
                        {
                            candidates.Add(j);
                        }
                    }

                    foreach (var candidate in candidates)
                    {
                        RemoveInvalidParentheses(s.Remove(candidate, 1), valid, i, candidate, parentheses);
                    }
                }
                else
                {
                    RemoveInvalidParentheses(s, valid, i, s.Length, parentheses);
                }
            }
        }
    }
}