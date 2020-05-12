using System;
using System.Collections.Generic;

namespace LeetCode.CombinationSum
{
    public class Solution
    {
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            var combinations = new List<IList<int>>();
            if (candidates == null || candidates.Length == 0 || target <= 0)
            {
                return combinations;
            }

            Array.Sort(candidates);

            CombinationSum(candidates, target, 0, new List<int>(), combinations);

            return combinations;
        }

        private void CombinationSum(int[] candidates, int target, int start, IList<int> combination, IList<IList<int>> combinations)
        {
            if (target == 0)
            {
                combinations.Add(new List<int>(combination));
            }
            else
            {
                for (var i = start; i < candidates.Length && candidates[i] <= target; i++)
                {
                    combination.Add(candidates[i]);
                    CombinationSum(candidates, target - candidates[i], i, combination, combinations);
                    combination.RemoveAt(combination.Count - 1);
                }
            }
        }
    }
}