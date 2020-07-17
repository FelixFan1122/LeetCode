using System;

namespace LeetCode.PaintHouseIII
{
    public class Solution
    {
        private const int Max = 1000001;
        public int MinCost(int[] houses, int[][] cost, int m, int n, int target)
        {
            var minCost = new int[m, n + 1, target + 1];
            for (var i = 0; i < m; i++) for (var j = 0; j <= n; j++) for (var k = 0; k <= target; k++) minCost[i, j, k] = Max;
            if (houses[0] == 0) for (var i = 1; i <= n; i++) minCost[0, i, 1] = cost[0][i - 1];
            else minCost[0, houses[0], 1] = 0;
            for (var i = 1; i < m; i++)
            {
                if (houses[i] == 0)
                {
                    for (var j = 1; j <= n; j++)
                    {
                        for (var k = 1; k <= target; k++)
                        {
                            for (var l = 1; l <= n; l++)
                            {
                                minCost[i, j, k] = Math.Min(minCost[i, j, k], cost[i][j - 1] + minCost[i - 1, l, j == l ? k : k - 1]);
                            }
                        }
                    }
                }
                else
                {
                    for (var k = 1; k <= target; k++)
                    {
                        for (var l = 1; l <= n; l++)
                        {
                            minCost[i, houses[i], k] = Math.Min(minCost[i, houses[i], k], minCost[i - 1, l, l == houses[i] ? k : k - 1]);
                        }
                    }
                }
            }
            var min = Max;
            for (var i = 1; i <= n; i++) min = Math.Min(min, minCost[m - 1, i, target]);
            return min < Max ? min : -1;
        }
    }
}