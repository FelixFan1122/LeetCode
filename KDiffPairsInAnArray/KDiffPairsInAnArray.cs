using System.Collections.Generic;

namespace LeetCode.KDiffPairsInAnArray
{
    public class Solution
    {
        public int FindPairs(int[] nums, int k)
        {
            if (nums == null || nums.Length < 2 || k < 0)
            {
                return 0;
            }

            if (k == 0)
            {
                return FindDuplicates(nums);
            }

            var visited = new HashSet<int>();
            var count = 0;
            foreach (var num in nums)
            {
                if (visited.Contains(num))
                {
                    continue;
                }

                if (visited.Contains(num + k))
                {
                    count++;
                }

                if (visited.Contains(num - k))
                {
                    count++;
                }

                visited.Add(num);
            }

            return count;
        }

        private int FindDuplicates(int[] nums)
        {
            var visited = new Dictionary<int, bool>();
            var count = 0;
            foreach (var num in nums)
            {
                if (visited.ContainsKey(num))
                {
                    if (!visited[num])
                    {
                        count++;
                        visited[num] = true;
                    }
                }
                else
                {
                    visited.Add(num, false);
                }
            }

            return count;
        }
    }
}