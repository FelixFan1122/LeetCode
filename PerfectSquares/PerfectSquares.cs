using System;

namespace PerfectSquares
{
    public class Solution
    {
        public int NumSquares(int n)
        {
            if (IsPerfectSquare(n))
            {
                return 1;
            }

            for (var i = 1; i <= Math.Sqrt(n); i++)
            {
                if (IsPerfectSquare(n - i * i))
                {
                    return 2;
                }
            }

            return IsNotSumOfThreeSquares(n) ? 4 : 3;
        }

        private bool IsPerfectSquare(int n)
        {
            var squareRoot = (int)Math.Sqrt(n);
            return n == squareRoot * squareRoot;
        }

        private bool IsNotSumOfThreeSquares(int n)
        {
            while (n % 4 == 0)
            {
                n /= 4;
            }

            return (n - 7) % 8 == 0;
        }
    }
}