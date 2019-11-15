using System.Collections.Generic;

namespace FindAllNumbersDisappearedInAnArray
{
    public class Solution
    {
        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            var disappeared = new List<int>();
            if (nums == null)
            {
                return disappeared;
            }

            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] != i + 1)
                {
                    var j = nums[i];
                    var temp = nums[j - 1];
                    while (nums[j - 1] != j)
                    {
                        nums[j - 1] = j;
                        j = temp;
                        temp = nums[j - 1];
                    }
                }
            }

            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] != i + 1)
                {
                    disappeared.Add(i + 1);
                }
            }

            return disappeared;
        }
    }
}