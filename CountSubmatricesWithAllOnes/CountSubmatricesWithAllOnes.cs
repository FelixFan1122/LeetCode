using System.Collections.Generic;

namespace LeetCode.CountSubmatricesWithAllOnes
{
    public class Solution
    {
        public int NumSubmat(int[][] mat)
        {
            var count = 0;
            var counts = new int[mat[0].Length];
            var heights = new int[mat[0].Length];
            var previousLowers = new Stack<int>(mat[0].Length);
            for (var i = 0; i < mat.Length; i++)
            {
                previousLowers.Clear();
                for (var j = 0; j < mat[0].Length; j++)
                {
                    heights[j] = mat[i][j] == 0 ? 0 : heights[j] + 1;
                    while (previousLowers.Count > 0 && heights[previousLowers.Peek()] > heights[j]) previousLowers.Pop();
                    if (previousLowers.Count == 0)
                    {
                        counts[j] = heights[j] * (j + 1);
                    }
                    else
                    {
                        counts[j] = counts[previousLowers.Peek()] + heights[j] * (j - previousLowers.Peek());
                    }
                    count += counts[j];
                    previousLowers.Push(j);
                }
            }
            return count;
        }
    }
}