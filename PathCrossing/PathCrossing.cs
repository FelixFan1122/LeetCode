using System;
using System.Collections.Generic;

namespace LeetCode.PathCrossing
{
    public class Solution
    {
        public bool IsPathCrossing(string path)
        {
            var coordinates = new HashSet<Tuple<int, int>>();
            var current = new Tuple<int, int>(0, 0);
            coordinates.Add(current);
            foreach (var direction in path)
            {
                switch (direction)
                {
                    case 'N':
                        current = new Tuple<int, int>(current.Item1, current.Item2 + 1);
                        break;
                    case 'S':
                        current = new Tuple<int, int>(current.Item1, current.Item2 - 1);
                        break;
                    case 'E':
                        current = new Tuple<int, int>(current.Item1 + 1, current.Item2);
                        break;
                    case 'W':
                        current = new Tuple<int, int>(current.Item1 - 1, current.Item2);
                        break;
                    default:
                        break;
                }

                if (coordinates.Contains(current))
                {
                    return true;
                }

                coordinates.Add(current);
            }

            return false;
        }
    }
}