using System;
using System.Collections.Generic;

namespace LeetCode.MaxValueofEquation
{
    public class Solution
    {
        public int FindMaxValueOfEquation(int[][] points, int k)
        {
            var max = int.MinValue;
            var window = new LinkedList<Tuple<int, int>>();
            for (var i = 0; i < points.Length; i++)
            {
                while (window.Count > 0 && window.First.Value.Item1 < points[i][0] - k) window.RemoveFirst();
                if (window.Count > 0) max = Math.Max(max, points[i][0] + points[i][1] + window.First.Value.Item2);
                while (window.Count > 0 && window.Last.Value.Item2 <= points[i][1] - points[i][0]) window.RemoveLast();
                window.AddLast(new Tuple<int, int>(points[i][0], points[i][1] - points[i][0]));
            }
            return max;
        }
    }
}