using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace LeetCode.TheSkylineProblem
{
    public class Solution
    {
        public IList<IList<int>> GetSkyline(int[][] buildings)
        {
            var points = buildings.SelectMany((building) => new[]
            {
                new Point { IsLeft = true, Other = building[1], X = building[0], Y = building[2] },
                new Point { IsLeft = false, X = building[1], Y = building[2] }
            }).OrderBy((point) => point, new PointComparer());

            var current = new MaxPriorityQueue<Point>();
            var skyline = new List<IList<int>>();
            foreach (var point in points)
            {
                if (point.IsLeft)
                {
                    if (!current.IsEmpty && point.Y <= current.Max.Y)
                    {
                        while (!current.IsEmpty && current.Max.Other < point.X)
                        {
                            current.DeleteMax();
                        }
                    }

                    if (current.IsEmpty || point.Y > current.Max.Y)
                    {
                        skyline.Add(new[] { point.X, point.Y });
                    }

                    current.Add(point);
                }
                else
                {
                    while (!current.IsEmpty && current.Max.Other <= point.X)
                    {
                        current.DeleteMax();
                    }

                    var height = current.IsEmpty ? 0 : current.Max.Y;
                    if (height != skyline[skyline.Count - 1][1])
                    {
                        skyline.Add(new[] { point.X, current.IsEmpty ? 0 : current.Max.Y });
                    }
                }
            }

            return skyline;
        }

        private class Point : IComparable<Point>
        {
            public bool IsLeft { get; set; }
            public int Other { get; set; }
            public int X { get; set; }
            public int Y { get; set; }

            public int CompareTo([AllowNull] Point other)
            {
                return this.Y == other.Y ? other.Other - this.Other : this.Y - other.Y;
            }
        }

        private class PointComparer : IComparer<Point>
        {
            public int Compare([AllowNull] Point point1, [AllowNull] Point point2)
            {
                if (point1.X != point2.X)
                {
                    return point1.X - point2.X;
                }

                if (point1.IsLeft != point2.IsLeft)
                {
                    return point1.IsLeft ? -1 : 1;
                }

                return point1.IsLeft ? point2.Y - point1.Y : point1.Y - point2.Y;
            }
        }
    }
}