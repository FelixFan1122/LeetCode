using System.Collections.Generic;

namespace LeetCode.GenerateParentheses
{
    public class Solution
    {
        public IList<string> GenerateParenthesis(int n)
        {
            var permutations = new List<string>();
            GenerateParenthesis(n - 1, n, "(", permutations);

            return permutations;
        }

        private void GenerateParenthesis(int left, int right, string current, IList<string> result)
        {
            if (left == 0 && right == 0)
            {
                result.Add(current);
            }
            else
            {
                if (left == 0)
                {
                    GenerateParenthesis(left, right - 1, current + ")", result);
                }
                else if (left == right)
                {
                    GenerateParenthesis(left - 1, right, current + "(", result);
                }
                else
                {
                    GenerateParenthesis(left - 1, right, current + "(", result);
                    GenerateParenthesis(left, right - 1, current + ")", result);
                }
            }
        }
    }
}