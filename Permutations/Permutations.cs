using System.Collections.Generic;

namespace LeetCode.Permutations
{
    public class Solution
    {
        public IList<IList<int>> Permute(int[] nums)
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

            Permute(nums, new List<int>(), isInPermutation, permutations);

            return permutations;
        }

        private void Permute(int[] nums, List<int> permutation, bool[] isInPermutation, List<IList<int>> permutations)
        {
            if (permutation.Count == nums.Length)
            {
                permutations.Add(new List<int>(permutation));
            }
            else
            {
                for (var i = 0; i < isInPermutation.Length; i++)
                {
                    if (!isInPermutation[i])
                    {
                        permutation.Add(nums[i]);
                        isInPermutation[i] = true;
                        Permute(nums, permutation, isInPermutation, permutations);
                        permutation.RemoveAt(permutation.Count - 1);
                        isInPermutation[i] = false;
                    }
                }
            }
        }
    }
}