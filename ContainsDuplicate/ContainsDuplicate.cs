using System.Collections.Generic;

namespace LeetCode.ContainsDuplicate
{
    public class Solution
    {
        public bool ContainsDuplicate(int[] nums)
        {
            var uniques = new HashSet<int>();
            foreach (var num in nums)
            {
                if (uniques.Contains(num))
                {
                    return true;
                }

                uniques.Add(num);
            }

            return false;
        }
    }
}