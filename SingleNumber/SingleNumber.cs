using System.Linq;

namespace LeetCode.SingleNumber
{
    public class Solution
    {
        public int SingleNumber(int[] nums)
        {
            return nums.Aggregate((num1, num2) => num1 ^ num2);
        }
    }
}