using System;

namespace LeetCode.BinaryTreeMaximumPathSum
{
    public class Solution
    {
        private int max = int.MinValue;
        public int MaxPathSum(TreeNode root)
        {
            GetPathSum(root);
            return max;
        }

        private int GetPathSum(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }

            var left = GetPathSum(node.left);
            var right = GetPathSum(node.right);
            var sum = node.val;
            if (left > 0)
            {
                sum += left;
            }

            if (right > 0)
            {
                sum += right;
            }

            if (max < sum)
            {
                max = sum;
            }

            return node.val + Math.Max(0, Math.Max(left, right));
        }
    }
}