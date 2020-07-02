using System;

namespace LeetCode.MaximalSquare
{
    public class Solution
    {
        public int MaximalSquare(char[][] matrix)
        {
            if (matrix == null || matrix.Length == 0)
            {
                return 0;
            }

            var max = 0;
            var lengths = new int[2, matrix[0].Length];
            for (var i = 0; i < matrix[0].Length; i++)
            {
                lengths[0, i] = matrix[0][i] == '0' ? 0 : 1;
                max = Math.Max(max, lengths[0, i]);
            }

            for (var i = 1; i < matrix.Length; i++)
            {
                lengths[i % 2, 0] = matrix[i][0] == '0' ? 0 : 1;
                max = Math.Max(max, lengths[i % 2, 0]);
                for (var j = 1; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] == '0')
                    {
                        lengths[i % 2, j] = 0;
                    }
                    else
                    {
                        lengths[i % 2, j] = Math.Min(Math.Min(lengths[(i - 1) % 2, j], lengths[i % 2, j - 1]), lengths[(i - 1) % 2, j - 1]) + 1;
                        max = Math.Max(max, lengths[i % 2, j]);
                    }
                }
            }

            return max * max;
        }
    }
}