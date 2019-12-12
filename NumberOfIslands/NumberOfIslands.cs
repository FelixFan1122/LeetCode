namespace NumberOfIslands
{
    public class Solution
    {
        private const char Land = '1';
        private const char Water = '0';

        private static readonly int[][] Directions = new[]
        {
        new[] { 0, -1 },
        new[] { 0, 1 },
        new[] { -1, 0 },
        new[] { 1, 0 }
    };

        public int NumIslands(char[][] grid)
        {
            var num = 0;
            for (var i = 0; i < grid.Length; i++)
            {
                for (var j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == Land)
                    {
                        MarkIsland(grid, i, j);
                        num++;
                    }
                }
            }

            return num;
        }

        private void MarkIsland(char[][] grid, int i, int j)
        {
            grid[i][j] = Water;
            foreach (var direction in Directions)
            {
                var ii = i + direction[0];
                var jj = j + direction[1];
                if (ii >= 0 && ii < grid.Length && jj >= 0 && jj < grid[i].Length && grid[ii][jj] == Land)
                {
                    MarkIsland(grid, ii, jj);
                }
            }
        }
    }
}