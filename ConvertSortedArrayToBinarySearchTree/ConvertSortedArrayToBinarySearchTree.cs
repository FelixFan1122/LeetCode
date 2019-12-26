namespace LeetCode.ConvertSortedArrayToBinarySearchTree
{
    public class Solution
    {
        public TreeNode SortedArrayToBST(int[] nums)
        {
            if (nums == null)
            {
                return null;
            }

            return SortedArrayToBst(nums, 0, nums.Length - 1);
        }

        private TreeNode SortedArrayToBst(int[] nums, int start, int end)
        {
            if (start > end)
            {
                return null;
            }

            var mid = (start + end) / 2;
            var node = new TreeNode(nums[mid]);
            node.left = SortedArrayToBst(nums, start, mid - 1);
            node.right = SortedArrayToBst(nums, mid + 1, end);

            return node;
        }
    }
}