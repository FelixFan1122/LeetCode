namespace LeetCode.SlidingWindowMaximum
{
    public class Solution
    {
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (nums == null || nums.Length < k || k <= 0)
            {
                return new int[0];
            }

            var max = new int[nums.Length - k + 1];
            var window = new Deque<int>(k);
            for (var i = 0; i < k; i++)
            {
                while (!window.IsEmpty && nums[window.PeekRear()] <= nums[i])
                {
                    window.RemoveRear();
                }

                window.AddRear(i);
            }

            max[0] = nums[window.PeekFront()];
            for (var i = k; i < nums.Length; i++)
            {
                if (window.PeekFront() == i - k)
                {
                    window.RemoveFront();
                }

                while (!window.IsEmpty && nums[window.PeekRear()] <= nums[i])
                {
                    window.RemoveRear();
                }

                window.AddRear(i);
                max[i - k + 1] = nums[window.PeekFront()];
            }

            return max;
        }
    }
}