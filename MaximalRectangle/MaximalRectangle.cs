using System;

namespace LeetCode.MaximalRectangle
{
    public class Solution
    {
        public int MaximalRectangle(char[][] matrix)
        {
            if (matrix == null || matrix.Length == 0)
            {
                return 0;
            }

            var heights = new int[matrix[0].Length];
            var max = 0;
            var lris = new LargestRectangleInHistogram.Solution();
            for (var i = 0; i < matrix.Length; i++)
            {
                for (var j = 0; j < matrix[0].Length; j++)
                {
                    heights[j] = matrix[i][j] == '0' ? 0 : heights[j] + 1;
                }

                max = Math.Max(max, lris.LargestRectangleArea(heights));
            }

            return max;
        }
    }
}