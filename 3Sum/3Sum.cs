using System;
using System.Collections.Generic;

namespace LeetCode.ThreeSum
{
    public class Solution
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var triplets = new List<IList<int>>();
            if (nums == null || nums.Length < 3)
            {
                return triplets;
            }

            Array.Sort(nums);
            for (var i = 0; i < nums.Length - 2; i++)
            {
                foreach (var tuples in TwoSum(nums, -nums[i], i + 1))
                {
                    triplets.Add(new List<int>() { nums[i], tuples[0], tuples[1] });
                }

                while (i < nums.Length - 2 && nums[i + 1] == nums[i])
                {
                    i++;
                }
            }

            return triplets;
        }

        public List<int[]> TwoSum(int[] numbers, int target, int start)
        {
            var pairs = new List<int[]>();
            if (numbers == null || start < 0 || numbers.Length - start < 2)
            {
                return pairs;
            }

            var left = start;
            var right = numbers.Length - 1;
            while (left < right)
            {
                if (numbers[left] + numbers[right] == target)
                {
                    pairs.Add(new[] { numbers[left], numbers[right] });
                    left++;
                    right--;
                    while (left < right && numbers[left] == numbers[left - 1])
                    {
                        left++;
                    }

                    while (left < right && numbers[right] == numbers[right + 1])
                    {
                        right--;
                    }
                }
                else if (numbers[left] + numbers[right] < target)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            return pairs;
        }
    }
}