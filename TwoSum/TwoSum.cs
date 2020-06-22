using System.Collections.Generic;

namespace LeetCode.TwoSum
{
    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var dic = new Dictionary<int, int>();
            for (var i = 0; i < nums.Length; i++)
            {
                if (dic.ContainsKey(target - nums[i]))
                {
                    return new[] { dic[target - nums[i]], i };
                }
                else
                {
                    dic[nums[i]] = i;
                }
            }

            return new int[0];
        }
    }
}