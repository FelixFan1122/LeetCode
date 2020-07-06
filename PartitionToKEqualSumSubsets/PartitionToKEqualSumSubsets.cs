using System.Linq;

namespace LeetCode.PartitionToKEqualSumSubsets
{
    public class Solution
    {
        public bool CanPartitionKSubsets(int[] nums, int k)
        {
            var sum = nums.Sum();
            if (sum % k != 0)
            {
                return false;
            }

            return CanPartitionKSubsets(nums, k, 0, sum / k, 0, 0, new bool[nums.Length]);
        }

        private bool CanPartitionKSubsets(int[] nums, int k, int currentSum, int target, int currentNumbers, int start, bool[] used)
        {
            if (k == 1)
            {
                return true;
            }

            if (currentSum == target && currentNumbers > 0)
            {
                return CanPartitionKSubsets(nums, k - 1, 0, target, 0, 0, used);
            }

            for (var i = start; i < nums.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    if (CanPartitionKSubsets(nums, k, currentSum + nums[i], target, currentNumbers + 1, i + 1, used))
                    {
                        return true;
                    }

                    used[i] = false;
                }
            }

            return false;
        }
    }
}