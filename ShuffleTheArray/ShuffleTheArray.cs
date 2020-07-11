namespace LeetCode.ShuffleTheArray
{
    public class Solution
    {
        public int[] Shuffle(int[] nums, int n)
        {
            var shuffled = new int[nums.Length];
            for (int i = 0, j = 0, k = n; j < n; i += 2, j++, k++)
            {
                shuffled[i] = nums[j];
                shuffled[i + 1] = nums[k];
            }

            return shuffled;
        }
    }
}