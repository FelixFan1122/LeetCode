namespace LeetCode.RotateArray
{
    public class Solution
    {
        public void Rotate(int[] nums, int k)
        {
            if (nums == null || nums.Length < 2 || k <= 0)
            {
                return;
            }

            var count = 0;
            var start = -1;
            while (count < nums.Length)
            {
                start++;
                var current = start;
                var currentNum = nums[current];
                int next;
                int nextNum;
                do
                {
                    next = (current + k) % nums.Length;
                    nextNum = nums[next];
                    nums[next] = currentNum;
                    current = next;
                    currentNum = nextNum;
                    count++;
                } while (current != start);
            }
        }
    }
}