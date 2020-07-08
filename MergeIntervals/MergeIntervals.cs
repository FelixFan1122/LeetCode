using System;
using System.Collections.Generic;

namespace LeetCode.MergeIntervals
{
    public class Solution
    {
        public int[][] Merge(int[][] intervals)
        {
            var merged = new List<int[]>();
            if (intervals != null)
            {
                Array.Sort(intervals, (x, y) => x[0].CompareTo(y[0]));

                var i = 0;
                var j = i + 1;
                while (i < intervals.Length)
                {
                    var end = intervals[i][1];
                    while (j < intervals.Length && intervals[j][0] <= end)
                    {
                        end = Math.Max(end, intervals[j++][1]);
                    }

                    merged.Add(new[] { intervals[i][0], end });
                    i = j;
                }
            }

            return merged.ToArray();
        }
    }
}