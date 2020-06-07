namespace LeetCode.TwoSumII
{
    public class Solution
    {
        public int[] TwoSum(int[] numbers, int target)
        {
            if (numbers == null || numbers.Length < 2)
            {
                return new[] { -1, -1 };
            }

            var left = 0;
            var right = numbers.Length - 1;

            while (left < right)
            {
                if (numbers[left] + numbers[right] == target)
                {
                    return new[] { left + 1, right + 1 };
                }
                else if (numbers[left] + numbers[right] < target)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            return new[] { -1, -1 };
        }
    }
}