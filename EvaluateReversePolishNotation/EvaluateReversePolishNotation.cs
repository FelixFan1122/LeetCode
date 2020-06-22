using System;
using System.Collections.Generic;

namespace LeetCode.EvaluateReversePolishNotation
{
    public class Solution
    {
        public int EvalRPN(string[] tokens)
        {
            if (tokens == null)
            {
                throw new ArgumentNullException(nameof(tokens));
            }

            var operands = new Stack<int>();
            int left;
            int right;
            foreach (var token in tokens)
            {
                switch (token)
                {
                    case "+":
                        right = operands.Pop();
                        left = operands.Pop();
                        operands.Push(left + right);
                        break;
                    case "-":
                        right = operands.Pop();
                        left = operands.Pop();
                        operands.Push(left - right);
                        break;
                    case "*":
                        right = operands.Pop();
                        left = operands.Pop();
                        operands.Push(left * right);
                        break;
                    case "/":
                        right = operands.Pop();
                        left = operands.Pop();
                        operands.Push(left / right);
                        break;
                    default:
                        operands.Push(int.Parse(token));
                        break;
                }
            }

            return operands.Pop();
        }
    }
}