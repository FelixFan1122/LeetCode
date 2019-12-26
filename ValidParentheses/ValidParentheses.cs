using System.Collections.Generic;

namespace LeetCode.ValidParentheses
{
    public class Solution
    {
        public bool IsValid(string s)
        {
            if (s == null)
            {
                return true;
            }

            var parentheses = new Stack<char>();
            foreach (var character in s)
            {
                if (character == '(' || character == '{' || character == '[')
                {
                    parentheses.Push(character);
                }
                else
                {
                    if (parentheses.Count == 0 ||
                        character == ')' && parentheses.Peek() != '(' ||
                        character == '}' && parentheses.Peek() != '{' ||
                        character == ']' && parentheses.Peek() != '[')
                    {
                        return false;
                    }

                    parentheses.Pop();
                }
            }

            return parentheses.Count == 0;
        }
    }
}