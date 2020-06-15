using System.Collections.Generic;

namespace LeetCode.ValidateBinarySearchTree
{
    public class Solution
    {
        public bool IsValidBST(TreeNode root)
        {
            var toTraverse = new Stack<TreeNode>();
            var previous = double.MinValue;
            while (root != null || toTraverse.Count > 0)
            {
                while (root != null)
                {
                    toTraverse.Push(root);
                    root = root.left;
                }

                root = toTraverse.Pop();
                if (root.val <= previous)
                {
                    return false;
                }

                previous = root.val;
                root = root.right;
            }

            return true;
        }
    }
}