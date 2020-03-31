namespace LeetCode.FirstMissingPositive
{
    public class Solution
    {
        public int FirstMissingPositive(int[] nums)
        {
            if (nums == null)
            {
                return 1;
            }

            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] < 1 || nums[i] > nums.Length)
                {
                    continue;
                }

                var current = nums[i];
                while (current >= 1 && current <= nums.Length && nums[current - 1] != current)
                {
                    var next = nums[current - 1];
                    nums[current - 1] = current;
                    current = next;
                }
            }

            var firstMissingPositive = 1;
            while (firstMissingPositive <= nums.Length && nums[firstMissingPositive - 1] == firstMissingPositive)
            {
                firstMissingPositive++;
            }

            return firstMissingPositive;
        }
    }
}