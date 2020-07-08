using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.BasicCalculatorII
{
    public class Solution
    {
        public int Calculate(string s)
        {
            var current = 0;
            var currentOperator = '#';
            var isNegative = false;
            var operands = new Stack<int>();
            var i = 0;
            while (i < s.Length)
            {
                if (Char.IsDigit(s[i]))
                {
                    var j = i + 1;
                    while (j < s.Length && Char.IsDigit(s[j]))
                    {
                        j++;
                    }

                    if (currentOperator == '*')
                    {
                        current *= int.Parse(s.Substring(i, j - i));
                    }
                    else if (currentOperator == '/')
                    {
                        current /= int.Parse(s.Substring(i, j - i));
                    }
                    else
                    {
                        current = int.Parse(s.Substring(i, j - i));
                    }

                    i = j;
                }
                else if (s[i] == '+' || s[i] == '-' || s[i] == '*' || s[i] == '/')
                {
                    if (s[i] == '+' || s[i] == '-')
                    {
                        operands.Push(isNegative ? -current : current);
                        isNegative = s[i] == '-';
                    }

                    currentOperator = s[i];
                    i++;
                }
                else
                {
                    i++;
                }
            }

            operands.Push(isNegative ? -current : current);

            return operands.Sum();
        }
    }
}