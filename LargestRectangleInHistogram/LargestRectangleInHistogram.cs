using System.Collections.Generic;

namespace LeetCode.LargestRectangleInHistogram
{
    public class Solution
    {
        public int LargestRectangleArea(int[] heights)
        {
            if (heights == null || heights.Length == 0)
            {
                return 0;
            }

            var rectangle = new Stack<int>();
            var i = 0;
            var max = 0;
            while (i < heights.Length)
            {
                if (rectangle.Count == 0 || heights[rectangle.Peek()] <= heights[i])
                {
                    rectangle.Push(i);
                    i++;
                }
                else
                {
                    var lowest = rectangle.Pop();
                    var area = heights[lowest] * (rectangle.Count == 0 ? i : i - rectangle.Peek() - 1);
                    if (area > max)
                    {
                        max = area;
                    }
                }
            }

            while (rectangle.Count > 0)
            {
                var lowest = rectangle.Pop();
                var area = heights[lowest] * (rectangle.Count == 0 ? i : i - rectangle.Peek() - 1);
                if (area > max)
                {
                    max = area;
                }
            }

            return max;
        }
    }
}