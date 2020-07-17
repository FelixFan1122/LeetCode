using System;
using System.Linq;

namespace LeetCode.MinimumNumberOfDaysToMakeMBouquets
{
    public class Solution
    {
        public int MinDays(int[] bloomDay, int m, int k)
        {
            if (bloomDay.Length < m * k)
            {
                return -1;
            }

            var days = bloomDay.Distinct().ToArray();
            Array.Sort(days);
            int left = 0, right = days.Length - 1;
            while (left < right)
            {
                var mid = left + (right - left) / 2;
                var bouquets = MakeBouquets(bloomDay, days[mid], k);
                if (bouquets < m)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return days[left];
        }

        private static int MakeBouquets(int[] bloomDays, int day, int k)
        {
            int bouquets = 0, flowers = 0;
            foreach (var bloomDay in bloomDays)
            {
                if (bloomDay > day)
                {
                    flowers = 0;
                }
                else
                {
                    flowers++;
                    if (flowers == k)
                    {
                        bouquets++;
                        flowers = 0;
                    }
                }
            }

            return bouquets;
        }
    }
}