using System;
using System.Collections.Generic;

namespace LeetCode.DivideTwoIntegers
{
    public class Solution
    {
        public int Divide(int dividend, int divisor)
        {
            if (divisor == int.MinValue)
            {
                return dividend == int.MinValue ? 1 : 0;
            }

            if (dividend == int.MinValue && divisor == -1)
            {
                return int.MaxValue;
            }

            var isNegative = ((dividend ^ divisor) & 1 << 31) != 0;
            var multiples = new Stack<int>();
            var quotient = 0;
            divisor = Math.Abs(divisor);
            if (dividend == int.MinValue)
            {
                quotient += 1;
                dividend += divisor;
            }

            dividend = Math.Abs(dividend);
            while (divisor <= dividend)
            {
                multiples.Push(divisor);
                if (divisor >= int.MaxValue >> 1)
                {
                    break;
                }

                divisor += divisor;
            }

            while (multiples.Count > 0)
            {
                var multiple = multiples.Pop();
                if (multiple <= dividend)
                {
                    quotient += 1 << multiples.Count;
                    dividend -= multiple;
                }
            }

            if (isNegative)
            {
                quotient = -quotient;
            }

            return quotient;
        }
    }
}