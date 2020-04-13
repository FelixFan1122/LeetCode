using System.Collections.Generic;

namespace LeetCode.CountOfSmallerNumbersAfterSelf
{
    public class Solution
    {
        public IList<int> CountSmaller(int[] nums)
        {
            if (nums == null)
            {
                return new int[0];
            }

            if (nums.Length == 1)
            {
                return new[] { 0 };
            }

            var indices = new KeyValuePair<int, int>[nums.Length];
            for (var i = 0; i < nums.Length; i++)
            {
                indices[i] = new KeyValuePair<int, int>(i, nums[i]);
            }

            var auxiliary = new KeyValuePair<int, int>[indices.Length];
            var smaller = new int[nums.Length];
            for (var size = 1; size < indices.Length; size += size)
            {
                for (var i = 0; i < indices.Length - size;)
                {
                    var j = i + size;
                    var mid = j;
                    var end = j + size >= indices.Length ? indices.Length : j + size;
                    for (var k = i; k < end; k++)
                    {
                        if (i >= mid)
                        {
                            auxiliary[k] = indices[j];
                            j++;
                        }
                        else if (j >= end)
                        {
                            auxiliary[k] = indices[i];
                            i++;
                        }
                        else if (indices[i].Value <= indices[j].Value)
                        {
                            auxiliary[k] = indices[i];
                            i++;
                        }
                        else
                        {
                            auxiliary[k] = indices[j];
                            j++;
                            for (var l = i; l < mid; l++)
                            {
                                smaller[indices[l].Key]++;
                            }
                        }
                    }

                    for (var m = mid - size; m < end; m++)
                    {
                        indices[m] = auxiliary[m];
                    }

                    i = mid + size;
                }
            }

            return smaller;
        }
    }
}