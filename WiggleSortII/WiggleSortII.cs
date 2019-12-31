namespace LeetCode.WiggleSortII
{
    public class Solution
    {
        public void WiggleSort(int[] nums)
        {
            var median = new KthLargestElementInAnArray.Solution()
                .FindKthLargest(nums, (nums.Length + 1) / 2);

            var i = 0;
            var j = 0;
            var k = nums.Length - 1;
            while (j <= k)
            {
                var jj = (j * 2 + 1) % (nums.Length | 1);
                if (nums[jj] < median)
                {
                    var kk = (k * 2 + 1) % (nums.Length | 1);
                    var temp = nums[jj];
                    nums[jj] = nums[kk];
                    nums[kk] = temp;
                    k--;
                }
                else if (nums[jj] == median)
                {
                    j++;
                }
                else
                {
                    var ii = (i * 2 + 1) % (nums.Length | 1);
                    var temp = nums[jj];
                    nums[jj] = nums[ii];
                    nums[ii] = temp;
                    i++;
                    j++;
                }
            }
        }
    }
}