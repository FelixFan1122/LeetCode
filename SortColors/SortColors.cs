namespace LeetCode.SortColors
{
    public class Solution
    {
        private const int Red = 0;
        private const int White = 1;
        private const int Blue = 2;

        public void SortColors(int[] nums)
        {
            var redIndex = 0;
            var whiteIndex = 0;
            var blueIndex = 0;
            foreach (var num in nums)
            {
                nums[blueIndex] = Blue;
                blueIndex++;
                if (num == White)
                {
                    nums[whiteIndex] = White;
                    whiteIndex++;
                }
                else if (num == Red)
                {
                    nums[whiteIndex] = White;
                    nums[redIndex] = Red;
                    whiteIndex++;
                    redIndex++;
                }
            }
        }
    }
}