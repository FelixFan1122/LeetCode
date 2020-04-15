namespace LeetCode.FindTheDuplicateNumber
{
    public class Solution
    {
        public int FindDuplicate(int[] nums)
        {
            var tortoise = nums[nums[0]];
            var hare = nums[nums[nums[0]]];
            while (tortoise != hare)
            {
                tortoise = nums[tortoise];
                hare = nums[nums[hare]];
            }

            hare = nums[0];
            while (tortoise != hare)
            {
                tortoise = nums[tortoise];
                hare = nums[hare];
            }

            return hare;
        }
    }
}