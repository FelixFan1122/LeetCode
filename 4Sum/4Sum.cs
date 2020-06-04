using System;
using System.Collections.Generic;

namespace LeetCode.FourSum
{
    public class Solution
    {
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            var quadruplets = new List<IList<int>>();
            if (nums == null || nums.Length < 4)
            {
                return quadruplets;
            }

            Array.Sort(nums);
            for (var i = 0; i < nums.Length - 3; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                {
                    continue;
                }

                foreach (var triplet in ThreeSum(nums, target - nums[i], i + 1))
                {
                    quadruplets.Add(new List<int>() { nums[i], triplet[0], triplet[1], triplet[2] });
                }
            }

            return quadruplets;
        }

        public IList<IList<int>> ThreeSum(int[] nums, int target, int start)
        {
            var triplets = new List<IList<int>>();
            if (nums == null || start < 0 || nums.Length - start < 3)
            {
                return triplets;
            }

            for (var i = start; i < nums.Length - 2; i++)
            {
                foreach (var tuple in TwoSum(nums, target - nums[i], i + 1))
                {
                    triplets.Add(new List<int>() { nums[i], tuple[0], tuple[1] });
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