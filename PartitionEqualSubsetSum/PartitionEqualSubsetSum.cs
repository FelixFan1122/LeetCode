namespace LeetCode.PartitionEqualSubsetSum
{
    public class Solution
    {
        public bool CanPartition(int[] nums)
        {
            return new PartitionToKEqualSumSubsets.Solution().CanPartitionKSubsets(nums, 2);
        }
    }
}