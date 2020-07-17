using System;

namespace LeetCode.AllocateMailboxes
{
    public class Solution
    {
        public int MinDistance(int[] houses, int k)
        {
            Array.Sort(houses);
            var distances = new int[houses.Length, houses.Length];
            for (var i = 0; i < houses.Length; i++) for (var j = 0; j < houses.Length; j++) for (var l = i; l <= j; l++) distances[i, j] += Math.Abs(houses[l] - houses[i + (j - i) / 2]);
            var mins = new int[k + 1, houses.Length];
            for (var i = 0; i < houses.Length; i++) mins[1, i] = distances[i, houses.Length - 1];
            for (var i = 2; i <= k; i++)
            {
                for (var j = 0; j < houses.Length; j++)
                {
                    mins[i, j] = int.MaxValue;
                    for (var l = j; l <= houses.Length - i; l++)
                    {
                        mins[i, j] = Math.Min(mins[i, j], distances[j, l] + mins[i - 1, l + 1]);
                    }
                }
            }
            return mins[k, 0];
        }
    }
}