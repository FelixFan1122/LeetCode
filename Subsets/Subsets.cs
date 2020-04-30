using System.Collections.Generic;

namespace LeetCode.Subsets
{
    public class Solution
    {
        private static readonly bool[] candidates = new[] { false, true };

        public IList<IList<int>> Subsets(int[] nums)
        {
            var subsets = new List<IList<int>>();
            if (nums == null)
            {
                return subsets;
            }

            Subsets(nums, 0, subsets, new bool[nums.Length]);

            return subsets;
        }

        private void Subsets(int[] nums, int index, IList<IList<int>> subsets, bool[] isInSet)
        {
            if (index == nums.Length)
            {
                var subset = new List<int>();
                for (var i = 0; i < isInSet.Length; i++)
                {
                    if (isInSet[i])
                    {
                        subset.Add(nums[i]);
                    }
                }

                subsets.Add(subset);
            }
            else
            {
                for (var i = 0; i < Solution.candidates.Length; i++)
                {
                    isInSet[index] = Solution.candidates[i];
                    Subsets(nums, index + 1, subsets, isInSet);
                }
            }
        }
    }
}