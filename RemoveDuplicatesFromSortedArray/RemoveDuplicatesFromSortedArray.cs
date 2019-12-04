namespace RemoveDuplicatesFromSortedArray
{
    public class Solution
    {
        public int RemoveDuplicates(int[] nums)
        {
            if (nums == null)
            {
                return -1;
            }

            var hare = 0;
            var tortoise = 0;
            while (hare < nums.Length)
            {
                if (hare == 0 || nums[hare] != nums[hare - 1])
                {
                    nums[tortoise++] = nums[hare++];
                }
                else
                {
                    hare++;
                }
            }

            return tortoise;
        }
    }
}