namespace NextPermutation
{
    public class Solution
    {
        public void NextPermutation(int[] nums)
        {
            if (nums == null)
            {
                return;
            }

            var start = nums.Length - 1;
            while (start > 0 && nums[start] <= nums[start - 1])
            {
                start--;
            }

            start--;
            if (start >= 0)
            {
                var greater = nums.Length - 1;
                while (greater > start && nums[greater] <= nums[start])
                {
                    greater--;
                }

                var temp = nums[greater];
                nums[greater] = nums[start];
                nums[start] = temp;
            }

            start++;
            var end = nums.Length - 1;
            while (start < end)
            {
                var temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
                start++;
                end--;
            }
        }
    }
}