using System.Collections.Generic;
using System.Linq;

namespace LeetCode.LargestNumber
{
    public class Solution
    {
        public string LargestNumber(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return "";
            }

            var largest = string.Join("", nums.Select((num) => num.ToString()).OrderBy((num) => num, new Comparer()));
            return largest[0] == '0' ? "0" : largest;
        }

        private class Comparer : IComparer<string>
        {
            public int Compare(string str1, string str2)
            {
                return (str2 + str1).CompareTo(str1 + str2);
            }
        }
    }
}