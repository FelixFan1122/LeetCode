namespace LeetCode.UniquePathsII
{
    public class Solution
    {
        private const int Empty = 0;
        private const int Obstacle = 1;

        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            if (obstacleGrid == null || obstacleGrid.Length == 0)
            {
                return 0;
            }

            var m = obstacleGrid[0].Length;
            foreach (var row in obstacleGrid)
            {
                if (row.Length != m)
                {
                    return -1;
                }
            }

            if (m == 0)
            {
                return 0;
            }

            if (obstacleGrid[0][0] == Obstacle)
            {
                return 0;
            }

            obstacleGrid[0][0] = 1;
            for (var i = 1; i < m; i++)
            {
                obstacleGrid[0][i] = obstacleGrid[0][i] == Obstacle ? 0 : obstacleGrid[0][i - 1];
            }

            for (var i = 1; i < obstacleGrid.Length; i++)
            {
                obstacleGrid[i][0] = obstacleGrid[i][0] == Obstacle ? 0 : obstacleGrid[i - 1][0];
            }

            for (var i = 1; i < obstacleGrid.Length; i++)
            {
                for (var j = 1; j < m; j++)
                {
                    obstacleGrid[i][j] = obstacleGrid[i][j] == Obstacle ? 0 : obstacleGrid[i - 1][j] + obstacleGrid[i][j - 1];
                }
            }

            return obstacleGrid[obstacleGrid.Length - 1][m - 1];
        }
    }
}