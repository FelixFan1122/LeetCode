using System;
using System.Collections.Generic;

namespace LeetCode.PermutationsII
{
    public class Solution
    {
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            if (nums == null)
            {
                throw new System.ArgumentNullException();
            }

            var permutations = new List<IList<int>>();
            var isInPermutation = new bool[nums.Length];
            for (var i = 0; i < isInPermutation.Length; i++)
            {
                isInPermutation[i] = false;
            }

            Array.Sort(nums);

            PermuteUnique(nums, new List<int>(), isInPermutation, permutations);

            return permutations;
        }

        private void PermuteUnique(int[] nums, List<int> permutation, bool[] isInPermutation, List<IList<int>> permutations)
        {
            if (permutation.Count == nums.Length)
            {
                permutations.Add(new List<int>(permutation));
            }
            else
            {
                var i = 0;
                while (i < isInPermutation.Length)
                {
                    if (!isInPermutation[i])
                    {
                        permutation.Add(nums[i]);
                        isInPermutation[i] = true;
                        PermuteUnique(nums, permutation, isInPermutation, permutations);
                        permutation.RemoveAt(permutation.Count - 1);
                        isInPermutation[i] = false;
                        while (i < nums.Length - 1 && nums[i + 1] == nums[i])
                        {
                            i++;
                        }
                    }

                    i++;
                }
            }
        }
    }
}