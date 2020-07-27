using System.Collections.Generic;

namespace LeetCode.StoneGameIV
{
    public class Solution
    {
        public bool WinnerSquareGame(int n)
        {
            var squares = new List<int>();
            var memo = new int[n + 1];
            for (var i = 1; i * i <= n; i++)
            {
                squares.Add(i * i);
                memo[i * i] = 1;
            }
            return WinnerSquareGame(n, memo, squares) == 1;
        }

        private int WinnerSquareGame(int n, int[] memo, List<int> squares)
        {
            if (memo[n] == 0)
            {
                for (var i = 0; i < squares.Count && squares[i] < n; i++)
                {
                    if (WinnerSquareGame(n - squares[i], memo, squares) == 2)
                    {
                        memo[n] = 1;
                    }
                }
                if (memo[n] == 0) memo[n] = 2;
            }
            return memo[n];
        }
    }
}