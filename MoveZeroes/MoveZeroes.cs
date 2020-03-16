namespace LeetCode.MoveZeroes
{
    public class Solution
    {
        public void MoveZeroes(int[] nums)
        {
            if (nums == null)
            {
                return;
            }

            var index = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[index] = nums[i];
                    index++;
                }
            }

            while (index < nums.Length)
            {
                nums[index] = 0;
                index++;
            }
        }
    }
}