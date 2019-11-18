using System;

namespace MinimumPathSum
{
    public class Solution
    {
        public int MinPathSum(int[][] grid)
        {
            if (grid == null || grid.Length == 0 || grid[0].Length == 0)
            {
                return 0;
            }

            for (var i = 1; i < grid.Length; i++)
            {
                grid[i][0] += grid[i - 1][0];
            }

            for (var i = 1; i < grid[0].Length; i++)
            {
                grid[0][i] += grid[0][i - 1];
            }

            for (var i = 1; i < grid.Length; i++)
            {
                for (var j = 1; j < grid[i].Length; j++)
                {
                    grid[i][j] += Math.Min(grid[i - 1][j], grid[i][j - 1]);
                }
            }

            return grid[grid.Length - 1][grid[grid.Length - 1].Length - 1];
        }
    }
}