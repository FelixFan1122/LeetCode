using System;

namespace LeetCode.LongestIncreasingPathInAMatrix
{
    public class Solution
    {
        private static int[][] directions = new[] { new[] { 0, 1 }, new[] { 1, 0 }, new[] { 0, -1 }, new[] { -1, 0 } };

        public int LongestIncreasingPath(int[][] matrix)
        {
            if (!IsValid(matrix))
            {
                return 0;
            }

            var paths = InitializePaths(matrix);
            for (var i = 0; i < matrix.Length; i++)
            {
                for (var j = 0; j < matrix[i].Length; j++)
                {
                    if (paths[i][j] > 0)
                    {
                        continue;
                    }

                    GetLongestPath(matrix, paths, i, j);
                }
            }

            var max = 0;
            for (var i = 0; i < paths.Length; i++)
            {
                for (var j = 0; j < paths[i].Length; j++)
                {
                    if (paths[i][j] > max)
                    {
                        max = paths[i][j];
                    }
                }
            }

            return max;
        }

        private int GetLongestPath(int[][] matrix, int[][] paths, int i, int j)
        {
            if (paths[i][j] > 0)
            {
                return paths[i][j];
            }

            var max = 0;
            for (var k = 0; k < directions.Length; k++)
            {
                var ii = i + directions[k][0];
                var jj = j + directions[k][1];
                if (ii >= 0 && ii < matrix.Length && jj >= 0 && jj < matrix[i].Length && matrix[ii][jj] > matrix[i][j])
                {
                    max = Math.Max(max, GetLongestPath(matrix, paths, ii, jj));
                }
            }

            max += 1;

            paths[i][j] = max;

            return max;
        }

        private int[][] InitializePaths(int[][] matrix)
        {
            var paths = new int[matrix.Length][];
            for (var i = 0; i < matrix.Length; i++)
            {
                paths[i] = new int[matrix[0].Length];
                for (var j = 0; j < paths[i].Length; j++)
                {
                    paths[i][j] = 0;
                }
            }

            return paths;
        }

        private bool IsValid(int[][] matrix)
        {
            if (matrix == null || matrix.Length == 0)
            {
                return false;
            }

            foreach (var row in matrix)
            {
                if (row.Length != matrix[0].Length)
                {
                    return false;
                }
            }

            return true;
        }
    }
}