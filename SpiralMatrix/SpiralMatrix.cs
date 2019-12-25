using System.Collections.Generic;

namespace LeetCode.SpiralMatrix
{
    public class Solution
    {
        private static readonly int[][] Direction = new[]
        {
            new[] { 0, 1 },
            new[] { 1, 0 },
            new[] { 0, -1 },
            new[] { -1, 0 }
        };

        public IList<int> SpiralOrder(int[][] matrix)
        {
            if (matrix == null || matrix.Length == 0)
            {
                return new List<int>();
            }

            var visited = InitializeVisited(matrix.Length, matrix[0].Length);
            var spiral = new List<int>(matrix.Length * matrix[0].Length);
            var i = 0;
            var j = 0;
            var direction = 0;
            while (spiral.Count < spiral.Capacity)
            {
                spiral.Add(matrix[i][j]);
                visited[i][j] = true;

                var ii = i + Direction[direction][0];
                var jj = j + Direction[direction][1];
                if (ii < 0 || ii >= matrix.Length || jj < 0 || jj >= matrix[0].Length || visited[ii][jj])
                {
                    direction = (direction + 1) % Direction.Length;
                }

                i += Direction[direction][0];
                j += Direction[direction][1];
            }

            return spiral;
        }

        private bool[][] InitializeVisited(int m, int n)
        {
            var visited = new bool[m][];
            for (var i = 0; i < m; i++)
            {
                visited[i] = new bool[n];
            }

            return visited;
        }
    }
}