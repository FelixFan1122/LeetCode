using System;
using System.Collections.Generic;

namespace LeetCode.MaxPointsOnALine
{
    public class Solution
    {
        public int MaxPoints(int[][] points)
        {
            if (points == null)
            {
                return 0;
            }

            if (points.Length < 3)
            {
                return points.Length;
            }

            var duplicates = 0;
            var max = 0;
            var lines = new Dictionary<Tuple<int, int>, int>(points.Length);
            for (var i = 0; i < points.Length - 2; i++)
            {
                duplicates = 0;
                lines.Clear();
                for (var j = i + 1; j < points.Length; j++)
                {
                    var x = points[j][0] - points[i][0];
                    var y = points[j][1] - points[i][1];
                    if (x == 0 && y == 0)
                    {
                        duplicates++;
                    }
                    else
                    {
                        var gcd = GetGcd(x, y);
                        var key = new Tuple<int, int>(x / gcd, y / gcd);
                        if (!lines.ContainsKey(key))
                        {
                            lines[key] = 0;
                        }

                        lines[key]++;
                    }
                }

                var lineMax = 0;
                foreach (var line in lines.Values)
                {
                    if (line > lineMax)
                    {
                        lineMax = line;
                    }
                }

                if (1 + duplicates + lineMax > max)
                {
                    max = 1 + duplicates + lineMax;
                }
            }

            return max;
        }

        private int GetGcd(int x, int y)
        {
            return y == 0 ? x : GetGcd(y, x % y);
        }
    }
}