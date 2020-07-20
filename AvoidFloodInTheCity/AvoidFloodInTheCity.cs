using System.Collections.Generic;

namespace LeetCode.AvoidFloodInTheCity
{
    public class Solution
    {
        public int[] AvoidFlood(int[] rains)
        {
            var drains = new int[rains.Length];
            var previousRains = new Dictionary<int, int>();
            var sunnys = new SortedSet<int>();
            for (var i = 0; i < rains.Length; i++)
            {
                if (rains[i] == 0)
                {
                    drains[i] = 1;
                    sunnys.Add(i);
                }
                else
                {
                    if (previousRains.ContainsKey(rains[i]))
                    {
                        var candidates = sunnys.GetViewBetween(previousRains[rains[i]], i - 1);
                        if (candidates.Count == 0)
                        {
                            return new int[0];
                        }
                        else
                        {
                            var drain = candidates.Min;
                            drains[drain] = rains[i];
                            previousRains[rains[i]] = i;
                            sunnys.Remove(drain);
                        }
                    }
                    else
                    {
                        previousRains.Add(rains[i], i);
                    }

                    drains[i] = -1;
                }
            }

            return drains;
        }
    }
}