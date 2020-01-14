using System.Collections.Generic;

namespace LeetCode.MajorElementII
{
    public class Solution
    {
        public IList<int> MajorityElement(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return nums;
            }

            var candidate1 = nums[0];
            var count1 = 1;
            var i = 1;
            while (i < nums.Length && nums[i] == candidate1)
            {
                i++;
                count1++;
            }

            var majorities = new List<int>();
            if (i == nums.Length)
            {
                majorities.Add(candidate1);
                return majorities;
            }

            var candidate2 = nums[i];
            var count2 = 1;
            i++;
            for (; i < nums.Length; i++)
            {
                if (nums[i] == candidate1)
                {
                    count1++;
                }
                else if (nums[i] == candidate2)
                {
                    count2++;
                }
                else if (count1 == 0)
                {
                    candidate1 = nums[i];
                    count1 = 1;
                }
                else if (count2 == 0)
                {
                    candidate2 = nums[i];
                    count2 = 1;
                }
                else
                {
                    count1--;
                    count2--;
                }
            }

            count1 = 0;
            count2 = 0;
            for (i = 0; i < nums.Length; i++)
            {
                if (nums[i] == candidate1)
                {
                    count1++;
                }
                else if (nums[i] == candidate2)
                {
                    count2++;
                }
            }

            if (count1 > nums.Length / 3)
            {
                majorities.Add(candidate1);
            }

            if (count2 > nums.Length / 3)
            {
                majorities.Add(candidate2);
            }

            return majorities;
        }
    }
}